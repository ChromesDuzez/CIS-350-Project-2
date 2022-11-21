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
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Car") || other.transform.CompareTag("EV"))
        {
            Destroy(other.gameObject);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            if(gameObject.tag.Equals("BulletRed"))
            {
                gm.playerOneAddPoints(1);
            }
            if (gameObject.tag.Equals("BulletBlue"))
            {
                gm.playerTwoAddPoints(1);
            }
        }    

        Destroy(gameObject);
    }
}
