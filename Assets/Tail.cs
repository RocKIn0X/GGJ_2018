using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
    [SerializeField,Range(-1,1)]
    private float ratio;

    private const float amp = 10;
	void OnValidate () {
        Transform currentTrans = transform;
        while(transform.childCount > 0)
        {
            currentTrans.localEulerAngles = new Vector3(0, ratio * amp, 0);
            currentTrans = currentTrans.GetChild(0);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
