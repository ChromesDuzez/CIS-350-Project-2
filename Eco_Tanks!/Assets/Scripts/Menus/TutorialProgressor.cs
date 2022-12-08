/*
* John Green
* CIS 350 - Group Project
* A HORRIBLY inefficient way to cycle tutorial panels because I am suboptimal at coding
* 
* Edit: Zach Wilson - Made it so that it uses the custom keybindings and also helped make it a tad more efficient w/o spending a bunch more time
* Also as per Professor Schaffer's Note made it so that the Second Player (if not an AI also gets to learn the controls)
*/

using System.Collections;
using UnityEngine;

public class TutorialProgressor : MonoBehaviour
{
    public GameObject[] tutorialPanels = new GameObject[3];
    public int buttonsPressed = 0;
    public bool button1Pressed = false;
    public bool button2Pressed = false;
    public bool button3Pressed = false;
    public bool button4Pressed = false;
    public bool canSwitch = false;
    public bool routineAllower = true;

    void Start()
    {
        tutorialPanels[0].SetActive(true);
    }

    void Update()
    {
        if(tutorialPanels[0].activeInHierarchy)
        {
            if (Input.GetKeyDown(GlobalSettings.RedTankRotateLeft.Binding) && button1Pressed == false)
            {
                button1Pressed = true;
            }

            if (Input.GetKeyDown(GlobalSettings.RedTankRotateRight.Binding) && button2Pressed == false)
            {
                button2Pressed = true;
            }

            if ((Input.GetKeyDown(GlobalSettings.BlueTankRotateLeft.Binding) || GlobalSettings.player2AIEnabled) && button3Pressed == false)
            {
                button3Pressed = true;
            }

            if ((Input.GetKeyDown(GlobalSettings.BlueTankRotateRight.Binding) || GlobalSettings.player2AIEnabled) && button4Pressed == false)
            {
                button4Pressed = true;
            }

            if (button1Pressed && button2Pressed && button3Pressed && button4Pressed)
            {   
                if(routineAllower)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    button1Pressed = false;
                    button2Pressed = false;
                    button3Pressed = false;
                    button4Pressed = false;

                    tutorialPanels[0].SetActive(false);
                    tutorialPanels[1].SetActive(true);
                    canSwitch = false;
 //                   Debug.Log("False, line 46");
                    routineAllower = true;
                }              
            }
        }

        if (tutorialPanels[1].activeInHierarchy)
        {
            if (Input.GetKeyDown(GlobalSettings.RedTankForward.Binding) && button1Pressed == false)
            {
                button1Pressed = true;
            }

            if (Input.GetKeyDown(GlobalSettings.RedTankBack.Binding) && button2Pressed == false)
            {
                button2Pressed = true;
            }

            if ((Input.GetKeyDown(GlobalSettings.BlueTankForward.Binding) || GlobalSettings.player2AIEnabled) && button3Pressed == false)
            {
                button3Pressed = true;
            }

            if ((Input.GetKeyDown(GlobalSettings.BlueTankBack.Binding) || GlobalSettings.player2AIEnabled) && button4Pressed == false)
            {
                button4Pressed = true;
            }

            if (button1Pressed && button2Pressed && button3Pressed && button4Pressed)
            {
                if (routineAllower)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    button1Pressed = false;
                    button2Pressed = false;
                    button3Pressed = false;
                    button4Pressed = false;

                    tutorialPanels[1].SetActive(false);
                    tutorialPanels[2].SetActive(true);
                    canSwitch = false;
 //                   Debug.Log("False, line 76");
                    routineAllower = true;
                }
            }
        }

        if (tutorialPanels[2].activeInHierarchy)
        {
            if (Input.GetKeyDown(GlobalSettings.RedTankShoot.Binding) && button1Pressed == false)
            {
                button1Pressed = true;
            }

            if ((Input.GetKeyDown(GlobalSettings.BlueTankShoot.Binding) || GlobalSettings.player2AIEnabled) && button3Pressed == false)
            {
                button3Pressed = true;
            }

            if (button1Pressed && button3Pressed)
            {
                if (routineAllower)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    button1Pressed = false;
                    button3Pressed = false;

                    tutorialPanels[2].SetActive(false);
                    canSwitch = false;
//                    Debug.Log("False, line 100");
                    routineAllower = true;
                }
            }
        }
    }

    private IEnumerator WaitBeforeNewPanel()
    {
        routineAllower = false;
        yield return new WaitForSeconds(1);
        canSwitch = true;
    }
}
