using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TestSpermBot : MonoBehaviour
{

    private const float startZ = -35;
    private const float endZ = 55;
    private const float fixedY = 5.3f;
    private const float xMagnitudeRandomRange = 40;
    private const float zMagnitudeRandomRange = 5;
    private const float minSpeed = 8, maxSpeed = 15;

    private static int initingCount = 0;

    NavMeshAgent agent;
    // Use this for initialization

    void Awake()
    {
        transform.position = new Vector3(Random.Range(-xMagnitudeRandomRange, xMagnitudeRandomRange), fixedY, startZ + Random.Range(-zMagnitudeRandomRange, zMagnitudeRandomRange));
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(init());
    }

    public IEnumerator init()
    {
        initingCount++;
        yield return null;
        agent.speed = 0;
        agent.SetDestination(new Vector3(Random.Range(-xMagnitudeRandomRange, xMagnitudeRandomRange), fixedY, endZ));
        yield return new WaitWhile(() => agent.hasPath == false);
        initingCount--;
        yield return new WaitWhile(() => initingCount > 0);
        agent.speed = Random.Range(minSpeed, maxSpeed);
    }
}
