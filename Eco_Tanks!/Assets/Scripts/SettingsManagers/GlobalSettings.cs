/*
* Zach Wilson
* CIS 350 - Group Project
* This script stores global variables for the game such as volume, muted and senstivity
* 
* SideNote: I am so sorry for this horrible unreadable monstrosity... I hate it so much more than you do.
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
    //public static KeyCode RedTankForward = KeyCode.W;
    public static KeyRef RedTankForward = new KeyRef("RedTankForward", KeyCode.W, Vertical1, 1.0f);
    //public static KeyCode RedTankBack = KeyCode.S;
    public static KeyRef RedTankBack = new KeyRef("RedTankBack", KeyCode.S, Vertical1, -1.0f);
    public static string Horizontal1 = "Horizontal";
    //public static KeyCode RedTankRotateLeft = KeyCode.A;
    public static KeyRef RedTankRotateLeft = new KeyRef("RedTankRotateLeft", KeyCode.A, Horizontal1, -1.0f);
    //public static KeyCode RedTankRotateRight = KeyCode.D;
    public static KeyRef RedTankRotateRight = new KeyRef("RedTankRotateRight", KeyCode.D, Horizontal1, 1.0f);
    //public static KeyCode RedTankShoot = KeyCode.Space;
    public static KeyRef RedTankShoot = new KeyRef("RedTankShoot", KeyCode.Space);
    //Blue Tank Settings
    public static string Vertical2 = "Vertical2";
    //public static KeyCode BlueTankForward = KeyCode.UpArrow;
    public static KeyRef BlueTankForward = new KeyRef("BlueTankForward", KeyCode.UpArrow, Vertical2, 1.0f);
    //public static KeyCode BlueTankBack = KeyCode.DownArrow;
    public static KeyRef BlueTankBack = new KeyRef("BlueTankBack", KeyCode.DownArrow, Vertical2, -1.0f);
    public static string Horizontal2 = "Horizontal2";
    //public static KeyCode BlueTankRotateLeft = KeyCode.LeftArrow;
    public static KeyRef BlueTankRotateLeft = new KeyRef("BlueTankRotateLeft", KeyCode.LeftArrow, Horizontal2, -1.0f);
    //public static KeyCode BlueTankRotateRight = KeyCode.RightArrow;
    public static KeyRef BlueTankRotateRight = new KeyRef("BlueTankRotateRight", KeyCode.RightArrow, Horizontal2, 1.0f);
    //public static KeyCode BlueTankShoot = KeyCode.RightShift;
    public static KeyRef BlueTankShoot = new KeyRef("BlueTankShoot", KeyCode.RightShift);

    public static List<KeyRef> allKeybindings = new List<KeyRef>() { RedTankForward, RedTankBack, RedTankRotateLeft, RedTankRotateRight, RedTankShoot, BlueTankForward, BlueTankBack, BlueTankRotateLeft, BlueTankRotateRight, BlueTankShoot };
    public static List<string> listKeybindings = new List<string>() { RedTankForward.BindingName, RedTankBack.BindingName, RedTankRotateLeft.BindingName, RedTankRotateRight.BindingName, RedTankShoot.BindingName, BlueTankForward.BindingName, BlueTankBack.BindingName, BlueTankRotateLeft.BindingName, BlueTankRotateRight.BindingName, BlueTankShoot.BindingName };
    //KeyCode[] allKeybindings = new KeyCode[] { };
    [SerializeField]
    private KeyCode[] defaultKeybindings = new KeyCode[10];

    //Choose 1 or 2 players
    public static bool player2Enabled = false;
    public static bool player2AIEnabled = false;


    //Settings Related to Seeing the Tutorial on the start of the game...
    public static bool hasSeenInfoCard = false;
    public static bool hasSeenTutorial = false;
    public static string tutorialScene;

    //Setup
    void Start()
    {
        //allKeybindings.Add(RedTankForward);
        //allKeybindings.Add(RedTankBack);
        //allKeybindings.Add(RedTankRotateLeft);
        //allKeybindings.Add(RedTankRotateRight);
        //allKeybindings.Add(BlueTankForward);
        //allKeybindings.Add(BlueTankBack);
        //allKeybindings.Add(BlueTankRotateLeft);
        //allKeybindings.Add(BlueTankRotateRight);

        KeyCode temp;
        for (int i = 0; i < allKeybindings.Count; i++)
        {
            temp = allKeybindings[i].Binding;
            defaultKeybindings[i] = temp;
        }
    }

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
            allKeybindings[i].Binding = defaultKeybindings[i];
        }
    }

}

public class KeyRef
{
    public string BindingName { get; set; }
    public KeyCode Binding { get; set; }
    public string Category { get; set; }
    public float Value { get; set; }

    public KeyRef(string bindingName, KeyCode binding, string category = "", float value = 0)
    {
        BindingName = bindingName;
        Binding = binding;
        Category = category;
        Value = value;
    }
}


/* old method logic... saving just in case
 *
  public static float GetAxisRaw(string axis)
    {
        if(Vertical1 == axis)
        {
            if(Input.GetKey(RedTankForward.Binding))
            {
                return 1;
            }
            else if(Input.GetKey(RedTankBack.Binding))
            {
                return -1;
            }
        }
        else if(Horizontal1 == axis)
        {
            if (Input.GetKey(RedTankRotateRight.Binding))
            {
                return 1;
            }
            else if (Input.GetKey(RedTankRotateLeft.Binding))
            {
                return -1;
            }
        }
        else if (Vertical2 == axis)
        {
            if (Input.GetKey(BlueTankForward.Binding))
            {
                return 1;
            }
            else if (Input.GetKey(BlueTankBack.Binding))
            {
                return -1;
            }
        }
        else if (Horizontal2 == axis)
        {
            if (Input.GetKey(BlueTankRotateRight.Binding))
            {
                return 1;
            }
            else if (Input.GetKey(BlueTankRotateLeft.Binding))
            {
                return -1;
            }
        }
        return Input.GetAxisRaw(axis);
    } 
 * 
*/