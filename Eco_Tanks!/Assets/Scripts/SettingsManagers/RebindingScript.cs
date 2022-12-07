/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the rebinding process
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebindingScript : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text bindingText;
    [SerializeField] private List<string> theKeybindings = GlobalSettings.listKeybindings;
    [SerializeField] private string bindingToEdit;
    private int bindingIndex = -1;
    private bool thisScriptRebindingProcess = false;

    /*
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GlobalSettings.listKeybindings.Count; i++)
        {
            if(GlobalSettings.listKeybindings[i] == bindingToEdit)
            {
                bindingIndex = i;
            }
        }

        if(bindingIndex == -1)
        {
            Debug.LogError("[RebindingScript.cs] - invalid bindingToEdit given");
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
        bindingText.text = GlobalSettings.allKeybindings[bindingIndex].Binding + "";
    }
    */

    void OnEnable()
    {
        for (int i = 0; i < GlobalSettings.listKeybindings.Count; i++)
        {
            if (GlobalSettings.listKeybindings[i] == bindingToEdit)
            {
                bindingIndex = i;
            }
        }

        if (bindingIndex == -1)
        {
            Debug.LogError("[RebindingScript.cs] - invalid bindingToEdit given");
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
        bindingText.text = GlobalSettings.allKeybindings[bindingIndex].Binding + "";
    }

    void Clicked()
    {
        if(!GlobalSettings.rebinding)
        {
            thisScriptRebindingProcess = true;
            GlobalSettings.rebinding = true;
        }
        else if(thisScriptRebindingProcess)
        {
            thisScriptRebindingProcess = false;
            GlobalSettings.rebinding = false;
        }
    }

    void Update()
    {
        if(thisScriptRebindingProcess)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey) && !isMouseKeyCode(vKey))
                {
                    GlobalSettings.allKeybindings[bindingIndex].Binding = vKey;
                    bindingText.text = GlobalSettings.allKeybindings[bindingIndex].Binding + "";
                    thisScriptRebindingProcess = false;
                    GlobalSettings.rebinding = false;
                }
            }
        }
    }

    bool isMouseKeyCode(KeyCode key)
    {
        return (key == KeyCode.Mouse0 || key == KeyCode.Mouse1 || key == KeyCode.Mouse2 || key == KeyCode.Mouse3 || key == KeyCode.Mouse4 || key == KeyCode.Mouse5 || key == KeyCode.Mouse6);
    }
}
