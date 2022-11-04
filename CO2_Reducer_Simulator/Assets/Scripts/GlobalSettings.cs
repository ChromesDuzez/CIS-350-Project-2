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
    //Audio Settings
    public static bool bUnMuted = true;
    public static float volume = 1.0f;

    //Control Settings
    public static float mouseSense = 1.0f;

    //Settings Related to Seeing the Tutorial on the start of the game...
    public static bool hasSeenTutorial = false;
    public static string tutorialScene;
}