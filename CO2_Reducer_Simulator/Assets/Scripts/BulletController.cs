using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Car") || other.transform.CompareTag("EV"))
        {
            Destroy(other.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if(gameObject.tag.Equals("BulletRed"))
            {
                if (other.transform.CompareTag("Car"))
                    gm.playerOneAddPoints(1);
                else
                    gm.playerOneSubtractPoints(2);
            }
            if (gameObject.tag.Equals("BulletBlue"))
            {
                if (other.transform.CompareTag("Car"))
                    gm.playerTwoAddPoints(1);
                else
                    gm.playerTwoSubtractPoints(2);
            }
        }    

        Destroy(gameObject);
    }
}
