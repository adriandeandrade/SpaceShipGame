using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaBounds : MonoBehaviour {

    Mesh mesh;
    Renderer renderer;
    Bounds meshBounds;

    [HideInInspector] public static float playAreaWidth;
    [HideInInspector] public static float playAreaHeight;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        meshBounds = renderer.bounds;

        playAreaWidth = transform.localScale.x * meshBounds.size.x;
        playAreaHeight = transform.localScale.z * meshBounds.size.z;

        print(playAreaWidth);
        print(playAreaHeight);
    }
}
