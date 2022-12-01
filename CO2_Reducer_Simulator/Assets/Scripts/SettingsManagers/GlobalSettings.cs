/*
* Zach Wilson
* CIS 350 - Group Project
* This script stores global variables for the game such as volume, muted and senstivity
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static List<KeyCode> allKeybindings = new List<KeyCode>() { RedTankForward, RedTankBack, RedTankRotateLeft, RedTankRotateRight, BlueTankForward, BlueTankBack, BlueTankRotateLeft, BlueTankRotateRight };
    //KeyCode[] allKeybindings = new KeyCode[] { };
    //Audio Settings
    public static bool bUnMuted = true;
    public static float volume = 1.0f;


    //Control Settings
    public static float mouseSense = 1.0f;
        //Red Tank Settings
    public static string Vertical1 = "Vertical";
    public static KeyCode RedTankForward = KeyCode.W;
    public static KeyCode RedTankBack = KeyCode.S;
    public static string Horizontal1 = "Horizontal";
    public static KeyCode RedTankRotateLeft = KeyCode.A;
    public static KeyCode RedTankRotateRight = KeyCode.D;
    public static KeyCode RedTankShoot = KeyCode.Space;
        //Blue Tank Settings
    public static string Vertical2 = "Vertical2";
    public static KeyCode BlueTankForward = KeyCode.UpArrow;
    public static KeyCode BlueTankBack = KeyCode.DownArrow;
    public static string Horizontal2 = "Horizontal2";
    public static KeyCode BlueTankRotateLeft = KeyCode.LeftArrow;
    public static KeyCode BlueTankRotateRight = KeyCode.RightArrow;
    public static KeyCode BlueTankShoot = KeyCode.RightShift;

    private static List<KeyCode> defaultKeybindings = allKeybindings;

    //Choose 1 or 2 players
    public static bool player2Enabled = false;
    public static bool player2AIEnabled = false;


    //Settings Related to Seeing the Tutorial on the start of the game...
    public static bool hasSeenTutorial = false;
    public static string tutorialScene;

    //Setup
    void Start()
    {
        allKeybindings.Add(RedTankForward);
        allKeybindings.Add(RedTankBack);
        allKeybindings.Add(RedTankRotateLeft);
        allKeybindings.Add(RedTankRotateRight);
        allKeybindings.Add(BlueTankForward);
        allKeybindings.Add(BlueTankBack);
        allKeybindings.Add(BlueTankRotateLeft);
        allKeybindings.Add(BlueTankRotateRight);
    }

    public static float GetAxisRaw(string axis)
    {
        if(Vertical1 == axis)
        {
            if(Input.GetKeyDown(RedTankForward))
            {
                return 1;
            }
            else if(Input.GetKeyDown(RedTankBack))
            {
                return -1;
            }
        }
        else if(Horizontal1 == axis)
        {
            if (Input.GetKeyDown(RedTankRotateLeft))
            {
                return 1;
            }
            else if (Input.GetKeyDown(RedTankRotateRight))
            {
                return -1;
            }
        }
        else if (Vertical2 == axis)
        {
            if (Input.GetKeyDown(BlueTankForward))
            {
                return 1;
            }
            else if (Input.GetKeyDown(BlueTankBack))
            {
                return -1;
            }
        }
        else if (Horizontal2 == axis)
        {
            if (Input.GetKeyDown(BlueTankRotateLeft))
            {
                return 1;
            }
            else if (Input.GetKeyDown(BlueTankRotateRight))
            {
                return -1;
            }
        }
        return 0;
    }
}