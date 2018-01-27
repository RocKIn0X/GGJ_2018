using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SpermBot : MonoBehaviour 
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Rigidbody rigidbody;

    private const float force = 100;

    // =============
    // behaviour
    // =============
    private void OnValidate()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey("up"))
            rigidbody.AddForce(Vector3.forward * force);
        else if (Input.GetKey("left"))
            rigidbody.AddForce(Vector3.left * force);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    public bool SetTargetFinished()
    {
        return agent.hasPath;  
    }

    public void SetInitialVelocity(Vector3 velo)
    {
        rigidbody.velocity = velo;
        //agent.velocity = velo;
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }
}
