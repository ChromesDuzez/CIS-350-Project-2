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
    List<KeyCode> allKeybindings = new List<KeyCode>();
    //KeyCode[] allKeybindings = new KeyCode[] { };
    //Audio Settings
    public static bool bUnMuted = true;
    public static float volume = 1.0f;


    //Control Settings
    public static float mouseSense = 1.0f;
        //Red Tank Settings
    public static KeyCode RedTankForward;
    public static KeyCode RedTankBack;
    public static KeyCode RedTankRotateLeft;
    public static KeyCode RedTankRotateRight;
        //Blue Tank Settings
    public static KeyCode BlueTankForward;
    public static KeyCode BlueTankBack;
    public static KeyCode BlueTankRotateLeft;
    public static KeyCode BlueTankRotateRight;


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
}