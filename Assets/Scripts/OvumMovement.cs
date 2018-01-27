using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OvumMovement : MonoBehaviour {
    public float force;

    private Rigidbody rb;
    private IEnumerator coroutine;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        coroutine = ForceToOvum();
        StartCoroutine(coroutine);
	}

    public void setForce (float f)
    {
        force = f;
    }

    IEnumerator ForceToOvum()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            rb.AddForce(force * Vector3.right * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OvumCheck")
        {
            StopCoroutine(coroutine);
        }    
    }
}
