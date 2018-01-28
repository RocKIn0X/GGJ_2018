using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OvumMovement : MonoBehaviour {
    public float force;
    public float torque;

    private Rigidbody rb;
    private IEnumerator coroutine;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        coroutine = ForceToOvum();
        StartCoroutine(coroutine);
	}

    public void setForceTorque (float f, float t)
    {
        force = f;
        torque = t;
    }

    IEnumerator ForceToOvum()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            rb.AddForce(force * Vector3.right * Time.deltaTime);
            rb.AddTorque(Vector3.up*Time.deltaTime*torque);

            LimitVelo();
        }
    }

    private void LimitVelo()
    {
        if (rb.velocity.magnitude > 3)
            rb.velocity = rb.velocity / rb.velocity.magnitude * 3;
        rb.angularVelocity = new Vector3(rb.angularVelocity.x, Mathf.Clamp(rb.angularVelocity.y,-20,20), rb.angularVelocity.z);
    }
}
