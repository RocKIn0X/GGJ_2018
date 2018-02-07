using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour {
    private const float minScale = 0.5f, maxScale = 1.0f;

    private void Awake()
    {
        Vector3 originalScale = transform.localScale;
        originalScale *= Random.Range(minScale, maxScale); 
        transform.localScale = originalScale;
    }
}
