using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class TestPlayerNavigation : MonoBehaviour {
    RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent;
    [SerializeField]
    private Transform targetDestination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetDestination.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;
        }
    }
}
