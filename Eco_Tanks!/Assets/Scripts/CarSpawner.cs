using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] carPrefab;
    [SerializeField] private GameObject evPrefab;
    [SerializeField] private GameObject speedup;
    [SerializeField] private GameObject fireup;
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
        StartCoroutine("PowerupSpawn");
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

    public IEnumerator PowerupSpawn()
    {
        int waypointInd = Random.Range(0, 25);
        int powerUp = Random.Range(0, 2);

        if(powerUp == 0)
        {
            Instantiate(fireup, waypoints[waypointInd].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(speedup, waypoints[waypointInd].transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(5);
        StartCoroutine("PowerupSpawn");
    }
}
