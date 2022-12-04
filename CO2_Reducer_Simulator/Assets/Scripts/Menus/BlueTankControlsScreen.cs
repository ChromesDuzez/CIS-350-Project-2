/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the controls listings on the HowToPlay Screen for the Blue Tank
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTankControlsScreen : MonoBehaviour
{
    private const string header = "Blue Tank:";
    private string rotate = "A/D";
    private string move = "W/S";
    private string shoot = "E";
    private string combined;
    private Text textBox;

    void OnEnable()
    {
        textBox = GetComponent<Text>();
        getControls();
        combine();
        textBox.text = combined;
    }

    //manages setting up the control strings properly corrisponding to GlobalSettings
    void getControls()
    {
        rotate = GlobalSettings.BlueTankRotateLeft + "/" + GlobalSettings.BlueTankRotateRight;
        move = GlobalSettings.BlueTankForward + "/" + GlobalSettings.BlueTankBack;
        shoot = GlobalSettings.BlueTankShoot + "";
    }

    //combines the controls strings into a singular string for better readability.
    void combine()
    {
        combined = header + "\n" + rotate + "\n" + move + "\n" + shoot;
        //Debug.Log("[BlueTankControlsScreen.cs] - Here: " + header + rotate + move + shoot);
    }
}
