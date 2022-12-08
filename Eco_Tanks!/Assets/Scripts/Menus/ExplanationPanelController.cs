/*
* Zach Wilson
* CIS 350 - Group Project
* This script the panel on whether or not it can be disabled
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationPanelController : MonoBehaviour
{
    public static bool panelFinished = false;

    void OnEnable()
    {
        Time.timeScale = 0f;
    }
    void OnDisable()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(panelFinished)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
