using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermBotTail : MonoBehaviour {
    [SerializeField,Range(-1,1)]
    private float ratio;
    private float xRatio = 0;

    private const float amp = 10;
    private const float freq = 40;
	void OnValidate () {
        ApplyRatio();
	}

    private void Awake()
    {
        xRatio = Random.Range(0, 50);
    }

    // Update is called once per frame
    void Update () {
        xRatio += Time.deltaTime*freq;
        ratio = Mathf.Sin(xRatio);
        ApplyRatio();
	}

    private void ApplyRatio()
    {
        Transform currentTrans = transform;
        while (transform.childCount > 0)
        {
            currentTrans.localEulerAngles = new Vector3(0, ratio * amp, 0);
            try
            {
                currentTrans = currentTrans.GetChild(0);
            }
            catch(System.Exception e)
            {
                break;
            }
        }
    }
}
