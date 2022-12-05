/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the showing of the Info Screen upon first entry into the Main Menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreenManager : MonoBehaviour
{
    public GameObject InfoScreen;

    // Start is called before the first frame update
    void Start()
    {
        if(!GlobalSettings.hasSeenInfoCard)
        {
            InfoScreen.SetActive(true);
            GlobalSettings.hasSeenInfoCard = true;
        }
    }
}
