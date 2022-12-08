/*
* Zach Wilson
* CIS 350 - Group Project
* This script stores global variables for the game such as volume, muted and senstivity
* 
* SideNote: I am so sorry for this horrible unreadable monstrosity... I hate it so much more than you do.
* Edit: Made it less horrid but still could be improved.
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
    public static bool rebinding = false;
    public static float mouseSense = 1.0f;
        //Red Tank Settings
    public static string Vertical1 = "Vertical";
    public static KeyRef RedTankForward = new KeyRef("RedTankForward", KeyCode.W, Vertical1, 1.0f);
    public static KeyRef RedTankBack = new KeyRef("RedTankBack", KeyCode.S, Vertical1, -1.0f);
    public static string Horizontal1 = "Horizontal";
    public static KeyRef RedTankRotateLeft = new KeyRef("RedTankRotateLeft", KeyCode.A, Horizontal1, -1.0f);
    public static KeyRef RedTankRotateRight = new KeyRef("RedTankRotateRight", KeyCode.D, Horizontal1, 1.0f);
    public static KeyRef RedTankShoot = new KeyRef("RedTankShoot", KeyCode.Space);
    //Blue Tank Settings
    public static string Vertical2 = "Vertical2";
    public static KeyRef BlueTankForward = new KeyRef("BlueTankForward", KeyCode.UpArrow, Vertical2, 1.0f);
    public static KeyRef BlueTankBack = new KeyRef("BlueTankBack", KeyCode.DownArrow, Vertical2, -1.0f);
    public static string Horizontal2 = "Horizontal2";
    public static KeyRef BlueTankRotateLeft = new KeyRef("BlueTankRotateLeft", KeyCode.LeftArrow, Horizontal2, -1.0f);
    public static KeyRef BlueTankRotateRight = new KeyRef("BlueTankRotateRight", KeyCode.RightArrow, Horizontal2, 1.0f);
    public static KeyRef BlueTankShoot = new KeyRef("BlueTankShoot", KeyCode.RightShift);

    public static List<KeyRef> allKeybindings = new List<KeyRef>() { RedTankForward, RedTankBack, RedTankRotateLeft, RedTankRotateRight, RedTankShoot, BlueTankForward, BlueTankBack, BlueTankRotateLeft, BlueTankRotateRight, BlueTankShoot };

    //Choose 1 or 2 players
    public static bool player2Enabled = false;
    public static bool player2AIEnabled = false;


    //Settings Related to Seeing the Tutorial on the start of the game...
    public static bool hasSeenInfoCard = false;
    public static bool hasSeenTutorial = false;
    public static string tutorialScene;

    public static float GetAxisRaw(string axis)
    {
        foreach(KeyRef keybinding in allKeybindings)
        {
            if(keybinding.Category == axis)
            {
                if (Input.GetKey( keybinding.Binding))
                {
                    return keybinding.Value;
                }
            }
        }
        return Input.GetAxisRaw(axis);
    }

    public void ResetToDefaultControls()
    {
        for(int i = 0; i < allKeybindings.Count; i++)
        {
            allKeybindings[i].Binding = allKeybindings[i].DefaultBinding;
        }
    }

}

public class KeyRef
{
    public string BindingName { get; set; }
    public KeyCode Binding { get; set; }
    public KeyCode DefaultBinding { get; }
    public string Category { get; set; }
    public float Value { get; set; }

    public override string ToString()
    {
        //←/→/↓/↑
        if (Binding == KeyCode.LeftArrow) { return "←"; }
        if (Binding == KeyCode.RightArrow) { return "→"; }
        if (Binding == KeyCode.UpArrow) { return "↑"; }
        if (Binding == KeyCode.DownArrow) { return "↓"; }
        //abreviates the words right and Left to R and L -=-=-=-=- Note: Tried to do that somewhat dynamically but kept getting indexing errors with substrings. Maybe another day...
        if (Binding == KeyCode.LeftShift) { return "LShift"; }
        if (Binding == KeyCode.RightShift) { return "RShift"; }

        //return all other keybindings as is
        return Binding + "";
    }

    public KeyRef(string bindingName, KeyCode binding, string category = "", float value = 0)
    {
        BindingName = bindingName;
        Binding = binding;
        DefaultBinding = binding;
        Category = category;
        Value = value;
    }
}
