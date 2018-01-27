using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NaiveSpermBot : MonoBehaviour 
{
    [SerializeField]
    private Rigidbody rigidbody;
    private bool started = false;
    private const float force = 50;

    // =============
    // behaviour
    // =============
    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidbody.AddForce(Vector3.forward*force*Time.deltaTime);
    }

    // ================
    // public interfaces
    // ================
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
