using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvumManager : MonoBehaviour {
    public int numRand;

    private OvumMovement ovum;
    [SerializeField]
    private OvumMovement leftOvum, rightOvum;

    void Start()
    {
        numRand = Random.Range(0, 2);
        numRand = 0;

        if (numRand == 0) {
            leftOvum.setForceTorque(100,300);
        } else {
            rightOvum.setForceTorque(-100,300);
        }
    }
}
