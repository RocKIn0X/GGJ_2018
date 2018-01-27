using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaiveSpermBot : MonoBehaviour 
{
    [SerializeField]
    private Rigidbody rigidbody;
    private bool started = false;
    private const float force = 30;
    private const float angularMaxAmp = 50;

    private float angularAmp;

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
    }

    private void Update()
    {
        rigidbody.AddRelativeForce(Vector3.forward*force*Time.deltaTime);
        rigidbody.AddRelativeForce(new Vector3(0,0,0)*Time.deltaTime);
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
        StartCoroutine(init());
    }

    public IEnumerator init()
    {
        rigidbody.isKinematic = true;
        yield return null;
        yield return new WaitWhile(() => SpermBot.initingCount > 0);
        started = true;
        rigidbody.isKinematic = false;
    }
}
