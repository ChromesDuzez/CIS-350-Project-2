/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the buttons in the settings manager and disables them during the rebinding process
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingRebinder : MonoBehaviour
{
    [SerializeField] private GameObject[] toDisable;
    [SerializeField] private GameObject[] toEnable;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Clicked);
    }

    void Clicked()
    {
        if(!GlobalSettings.rebinding)
        {
            for (int i = 0; i < toDisable.Length; i++)
            {
                toDisable[i].SetActive(false);
            }

            for (int i = 0; i < toEnable.Length; i++)
            {
                toEnable[i].SetActive(true);
            }
        }
    }
}
