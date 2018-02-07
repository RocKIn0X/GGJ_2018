using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SpermBotOld : MonoBehaviour 
{
    [SerializeField]
    private NavMeshAgent agent;

    private const float force = 100;
    private bool naive = false;

    // =============
    // behaviour
    // =============
    private void OnValidate()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // ================
    // public interfaces
    // ================
    private Vector3 tempTargetPos;
    private Vector3 tempExplosionForce;
    private float tempSpeed;

    public void InitEssentialValues(Vector3 targetPos, Vector3 explosionForce, float speed)
    {
        tempSpeed = speed;
        tempTargetPos = targetPos;
        tempExplosionForce = explosionForce;
    }

    public void BurstWhenReady()
    {
        StartCoroutine(init());
    }

    public bool SetTargetFinished()
    {
        return agent.hasPath;  
    }

    public static int initingCount = 0;

    public IEnumerator init()
    {
        initingCount++;
        yield return null;
        agent.speed = 0;
        agent.SetDestination(tempTargetPos);

        yield return new WaitWhile(() => !SetTargetFinished());
        initingCount--;
        yield return new WaitWhile(() => initingCount > 0);
        agent.speed = tempSpeed;
    }
}
