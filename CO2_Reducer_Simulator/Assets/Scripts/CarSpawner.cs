using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] carPrefab;
    [SerializeField] private GameObject evPrefab;
    public GameObject[] waypoints = new GameObject[25];
    [SerializeField] private float carSpawningProbability;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int phaseOneMaxVehicles;
    [SerializeField] private int phaseTwoMaxVehicles;
    [SerializeField] private int phaseThreeMaxVehicles;
    [SerializeField] private float timeUntilPhaseTwo;
    [SerializeField] private float timeUntilPhaseThree;
    private float elapsedTime;
    private float totalElapsedTime;
    private int maxVehicles;

    private void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        totalElapsedTime += elapsedTime;

        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f;

            int vehicleCount = GameObject.FindGameObjectsWithTag("Car").Length + GameObject.FindGameObjectsWithTag("EV").Length;
            if (vehicleCount < maxVehicles)
            {
                SpawnCar();
            }
        }

        if (totalElapsedTime > timeUntilPhaseThree)
            maxVehicles = phaseThreeMaxVehicles;
        else if (totalElapsedTime > timeUntilPhaseTwo)
            maxVehicles = phaseTwoMaxVehicles;
    }

    private void SpawnCar()
    {
        int randomInt = Random.Range(0, 25);

        if (Random.value < carSpawningProbability)
        {
            int randomValue = Random.Range(0, carPrefab.Length);
            Instantiate(carPrefab[randomValue], waypoints[randomInt].transform);
        }
        else
        {
            Instantiate(evPrefab, transform);
        }
        
    }
}
