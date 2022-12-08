/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the controls listings on the HowToPlay Screen for the Red Tank
* 
* Edit: Also added functionaility so that it could update John's in-game tutorial
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTankControlsScreen : MonoBehaviour
{
    //this is for use where we want to see just one of the strings
    [SerializeField] private bool justRotate;
    [SerializeField] private bool justMove;
    [SerializeField] private bool justShoot;

    private const string header = "Red Tank:";
    private string rotate = "A/D";
    private string move = "W/S";
    private string shoot = "E";
    private string combined;
    private Text textBox;

    void OnEnable()
    {
        textBox = GetComponent<Text>();
        getControls();
        if (!(justRotate || justMove || justShoot))
        {
            combine();
            textBox.text = combined;
        }
        else if(justRotate)
        {
            textBox.text = rotate;
        }
        else if (justMove)
        {
            textBox.text = move;
        }
        else
        {
            textBox.text = shoot;
        }
    }

    //manages setting up the control strings properly corrisponding to GlobalSettings
    void getControls()
    {
        rotate = GlobalSettings.RedTankRotateLeft.ToString() + "/" + GlobalSettings.RedTankRotateRight.ToString();
        move = GlobalSettings.RedTankForward.ToString() + "/" + GlobalSettings.RedTankBack.ToString();
        shoot = GlobalSettings.RedTankShoot.ToString() + "";
    }

    //combines the controls strings into a singular string for better readability.
    void combine()
    {
        combined = header + "\n" + rotate + "\n" + move + "\n" + shoot;
        //Debug.Log("[RedTankControlsScreen.cs] - Here: " + header + rotate + move + shoot);
    }
}
