using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingButton : MonoBehaviour {

    private Vector3 startPosition;
    private const float amp = 25f;
    private const float freq = 2.25f;
    private float xRatio = 0;

    private void Awake()
    {
        startPosition = transform.position;
        xRatio = (float)transform.GetSiblingIndex()/2.0f;
    }

    private void Start()
    {
        StartCoroutine(animate());
    }

    private IEnumerator animate()
    {
        while(true)
        {
            float y = startPosition.y + Mathf.Sin(xRatio) * amp;
            Vector3 newPos = startPosition;
            newPos.y = y;
            transform.position = newPos;
            yield return null;

            xRatio += Time.deltaTime * freq;
        }
    }

}
