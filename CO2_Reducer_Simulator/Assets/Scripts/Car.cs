using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    GameObject[] waypoints;
    private NavMeshAgent agent;
    private int previousWaypointIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        GoToNextWaypoint();
    }

    public void GoToNextWaypoint()
    {
        int nextWaypointIndex = previousWaypointIndex;

        while (nextWaypointIndex == previousWaypointIndex)
        {
            nextWaypointIndex = Random.Range(0, waypoints.Length);
        }

        agent.SetDestination(waypoints[nextWaypointIndex].transform.position);
        previousWaypointIndex = nextWaypointIndex;
    }
}
