/*
* Zach Wilson
* CIS 350 - Group Project
* This script stores all the keybindings that we want to set in a scriptable object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        public KeybindingActions keybindingAction;
        public KeyCode keyCode;
    }

    public KeybindingCheck[] keybindingChecks;
}
