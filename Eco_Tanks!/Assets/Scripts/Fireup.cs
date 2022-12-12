using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fireup : MonoBehaviour
{
    public NavMeshAgent nav;
    public PlayerController pc;
    public GameObject tankOfInterest;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LifeSpan");
    }

    public IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(25);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Contains("TankRed"))
        {
            tankOfInterest = other.gameObject;
            pc = tankOfInterest.GetComponent<PlayerController>();
            pc.StartCoroutine("FireBoost");
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Contains("TankBlue"))
        {
            tankOfInterest = other.gameObject;
            pc = tankOfInterest.GetComponent<PlayerController>();
            pc.StartCoroutine("FireBoost");

            Destroy(gameObject);
        }
    }
}
