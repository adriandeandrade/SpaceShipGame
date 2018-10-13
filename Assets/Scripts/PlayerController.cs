using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movement;

    [Header("Weapon")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float cooldown = 3f;
    private float cooldownStamp = 0f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Update()
    {
        Movement();
        CheckForBounds();

        if (cooldownStamp > 0)
            cooldownStamp -= Time.deltaTime;
        if (cooldownStamp < 0)
            cooldownStamp = 0;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownStamp == 0)
        {
            ShootBullet();
            cooldownStamp = cooldown;
        }
    }

    private void Movement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void CheckForBounds()
    {
        if (transform.position.x > PlayAreaBounds.playAreaWidth / 2)
        {
            transform.position = new Vector3(PlayAreaBounds.playAreaWidth / 2, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -PlayAreaBounds.playAreaWidth / 2)
        {
            transform.position = new Vector3(-PlayAreaBounds.playAreaWidth / 2, transform.position.y, transform.position.z);
        }

        if (transform.position.z > (PlayAreaBounds.playAreaHeight / PlayAreaBounds.playAreaHeight) / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (PlayAreaBounds.playAreaHeight / PlayAreaBounds.playAreaHeight) / 2);
        }
        else if (transform.position.z < -PlayAreaBounds.playAreaHeight / 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -PlayAreaBounds.playAreaHeight / 2);
        }
    }

    void ShootBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletInstance.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Debug.Log("Shoot");
        Destroy(bulletInstance, 10f);
    }
}
