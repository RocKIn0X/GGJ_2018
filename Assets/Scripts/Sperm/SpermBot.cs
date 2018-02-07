using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpermBot : MonoBehaviour 
{
    private const string targetTag = "Ovum";

    private const float burstVelocity = 12;
    private const float forwardForceMagnitude = 25;
    private const float sideForceMaxAmp = 150;
    private const float sideForceFrequency = 0.5f;
    private const float targetRejectionForce = 2500;

    private Rigidbody rigidbody;
    private bool started = false;

    private float sideForceAmp;
    private float xValue = 0;

    //==============
    // behaviour
    //==============
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        sideForceAmp = Random.Range(-sideForceMaxAmp, sideForceMaxAmp);
        xValue = Random.Range(0f, Mathf.PI*2);
    }

    private void Update()
    {
        if (!started)
            return;
        
        xValue += Time.deltaTime * sideForceFrequency;

        AddPushForce();
        AddSideForce(xValue);
        SetHeadBasedOnCurrentVelocity();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (Vector3.Distance(collision.gameObject.GetComponent<OvumMovement>().breakpoint.transform.position, transform.position) < 1.8f)
            {
                rigidbody.AddForce(collision.transform.forward * targetRejectionForce);
            }
            //return;
        }
    }

    //===================
    // public interfaces
    //===================
    public void Burst()
    {
        rigidbody.isKinematic = false;
        rigidbody.velocity = Vector3.forward * burstVelocity;
        started = true;
    }

    //===================
    // private helpers
    //===================
    private void AddPushForce()
    {
        Vector3 forwardForce = Vector3.forward * forwardForceMagnitude * Time.deltaTime;
        rigidbody.AddRelativeForce(forwardForce);
    }

    private void AddSideForce(float x)
    {
        Vector3 sideForce = Vector3.left * Mathf.Sin(x) * sideForceAmp * Time.deltaTime;
        rigidbody.AddRelativeForce(sideForce);
    }

    private void SetHeadBasedOnCurrentVelocity()
    {
        transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
    }
}
