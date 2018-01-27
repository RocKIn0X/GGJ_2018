using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvumManager : MonoBehaviour {
    public int numRand;

    private OvumMovement ovum;

    void Start()
    {
        numRand = Random.Range(0, 2);

        transform.GetChild(numRand).gameObject.SetActive(true);
        ovum = transform.GetChild(numRand).gameObject.GetComponent<OvumMovement>();
        if (numRand == 0) {
            ovum.setForce(2500f);
        } else {
            ovum.setForce(-2500f);
        }
    }
}
