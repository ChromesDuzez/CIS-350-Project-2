/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages cycling through the messages for the textbox which are stored in the List
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField]
    private List<string> messages;
    [SerializeField]
    private TextMeshProUGUI textbox;
    private bool waitingForInput = false;
    [SerializeField]
    private GameObject indicator;
    private bool finished = false;

    public bool typing = false;
    public float delay = 0.1f;
    public float default_timer = 20f;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TextMeshProUGUI>();

        if(textbox == null)
        {
            Debug.LogError("[TextBoxManager.cs] - not attached to a text mesh pro - text object");
        }

        StartCoroutine(runTextBoxes());
    }

    IEnumerator runTextBoxes()
    {
        foreach (string s in messages)
        {
            float timer = 0f;
            while (waitingForInput)
            {
                yield return new WaitForSecondsRealtime(delay);
                timer += delay;
                if(timer >= default_timer)
                {
                    waitingForInput = false;
                }
            }

            try
            {
                indicator.SetActive(false);
            }
            catch
            {
                Debug.Log("[TextBoxManager.cs] - indicator not set");
            }

            textbox.text = "";
            delay = 0.1f;
            typing = true;
            for (int i = 0; i <= s.Length; i++)
            {
                textbox.text = s.Substring(0,i);
                yield return new WaitForSecondsRealtime(delay);
            }
            typing = false;
            waitingForInput = true;

            try
            {
                indicator.SetActive(true);
            }
            catch
            {
                Debug.Log("[TextBoxManager.cs] - indicator not set");
            }
        }

        ExplanationPanelController.panelFinished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ExplanationPanelController.panelFinished)
        {
            if (waitingForInput)
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(vKey))
                    {
                        waitingForInput = false;
                    }
                }
            }

            if (typing)
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(vKey))
                    {
                        delay /= 2;
                    }
                }
            }
        }
    }
}
