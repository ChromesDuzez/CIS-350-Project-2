using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Car") || other.transform.CompareTag("EV"))
        {
            Destroy(other.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }    

        Destroy(gameObject);
    }
}
