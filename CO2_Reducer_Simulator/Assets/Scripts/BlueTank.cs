/*
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.AI;
using UnityEngine.AI;

public class BlueTank : MonoBehaviour
{
    //TODO: Set AI scripts active or inactive depending on whether or not there is a player 2
    void Awake()
    {
        if(GlobalSettings.player2Enabled)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<EnemyMobile>().enabled = false;
            gameObject.GetComponent<EnemyController>().enabled = false;
        }
        else if(GlobalSettings.player2AIEnabled)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            gameObject.GetComponent<EnemyMobile>().enabled = true;
            gameObject.GetComponent<EnemyController>().enabled = true;
        }
    }
}
