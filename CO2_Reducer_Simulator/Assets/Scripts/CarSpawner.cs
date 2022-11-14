using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private GameObject evPrefab;
    [SerializeField] private float carSpawningProbability;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxVehicles;
    private float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f;

            int vehicleCount = GameObject.FindGameObjectsWithTag("Car").Length + GameObject.FindGameObjectsWithTag("EV").Length;
            if (vehicleCount < maxVehicles)
            {
                SpawnCar();
            }
        }
    }

    private void SpawnCar()
    {
        if (Random.value < carSpawningProbability)
        {
            Instantiate(carPrefab, transform);
        }
        else
        {
            Instantiate(evPrefab, transform);
        }
        
    }
}
