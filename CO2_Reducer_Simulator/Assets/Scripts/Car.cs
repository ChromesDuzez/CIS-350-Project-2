using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }

    public void GoToNextWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
            currentWaypointIndex = 0;
    }
}
