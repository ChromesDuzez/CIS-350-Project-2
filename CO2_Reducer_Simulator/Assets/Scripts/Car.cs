using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    GameObject[] waypoints;
    private NavMeshAgent agent;
    private int previousWaypointIndex = 0;
    [SerializeField] private GameObject explosionPrefab;
    private GameManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        GoToNextWaypoint();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TankRed"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gm.playerOneSubtractPoints(1);
        }
        if (other.CompareTag("TankBlue"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gm.playerTwoSubtractPoints(1);
        }
    }
}
