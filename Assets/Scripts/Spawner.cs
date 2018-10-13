using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private int amountToSpawn;
    [SerializeField] private float spawnTimer;
    [SerializeField] private int enemySpacing;
    private float spawnStamp;
    [SerializeField] private GameObject enemyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SpawnWave();
    }

    private void SpawnWave()
    {
        Vector3 spawnPosition = new Vector3((-PlayAreaBounds.playAreaWidth / 2) + 0.5f, 1, (PlayAreaBounds.playAreaHeight / 2) - 0.5f);

        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.localRotation);
            spawnPosition.x += enemySpacing;
        }
    }

}
