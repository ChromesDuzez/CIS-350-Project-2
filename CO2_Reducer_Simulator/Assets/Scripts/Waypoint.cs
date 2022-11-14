using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("EV"))
        {
            other.gameObject.GetComponent<Car>().GoToNextWaypoint();
        }
    }
}
