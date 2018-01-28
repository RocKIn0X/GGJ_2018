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
        numRand = 0;//force to be left

        if (numRand == 0) {
            leftOvum.setForceTorque(150,300);
        } else {
            rightOvum.setForceTorque(-150,300);
        }
    }
}
