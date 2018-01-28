using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaiveSpermBot : MonoBehaviour 
{
    [SerializeField]
    private Rigidbody rigidbody;
    private bool started = false;
    private const float force = 25;
    private const float angularMaxAmp = 150;

    private float angularAmp;
    private float xRatio = 0;

    // =============
    // behaviour
    // =============
    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        angularAmp = Random.Range(-angularMaxAmp, angularMaxAmp);
        xRatio = Random.Range(0, 100);
    }

    private void Update()
    {
        xRatio += Time.deltaTime/2;
        rigidbody.AddRelativeForce(Vector3.forward*force*Time.deltaTime);
        rigidbody.AddRelativeForce(new Vector3( Mathf.Sin(xRatio)*angularAmp ,0,0)*Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
    }

    // ==================
    // public interfaces
    // ==================
    private Vector3 tempExplosionForce;

    public void InitEssentialValues(Vector3 explosionForce)
    {
        tempExplosionForce = explosionForce;
    }

    public void BurstWhenReady()
    {
        rigidbody.isKinematic = false;
        rigidbody.velocity = new Vector3(0, 0, 12);
        //StartCoroutine(init());
    }

    public IEnumerator init()
    {
        rigidbody.isKinematic = false;
        yield return null;
        //yield return new WaitWhile(() => SpermBot.initingCount > 0);
        started = true;
        //rigidbody.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ovum")
        {
            if (Vector3.Distance(collision.gameObject.GetComponent<OvumMovement>().breakpoint.transform.position, transform.position) < 2)
            {
                print("skdjfskdhjf");
                rigidbody.AddForce(collision.transform.forward * 2500);
            }
            //return;
        }
    }
}
