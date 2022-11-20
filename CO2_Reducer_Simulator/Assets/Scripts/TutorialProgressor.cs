/*
* John Green
* CIS 350 - Group Project
* A HORRIBLY inefficient way to cycle tutorial panels because I am suboptimal at coding
*/

using System.Collections;
using UnityEngine;

public class TutorialProgressor : MonoBehaviour
{
    public GameObject[] tutorialPanels = new GameObject[3];
    public int buttonsPressed = 0;
    public bool button1Pressed = false;
    public bool button2Pressed;
    public bool canSwitch = false;
    public int routineAllower = 1;

    void Start()
    {
        tutorialPanels[0].SetActive(true);
    }

    void Update()
    {
        if(tutorialPanels[0].activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.A) && button1Pressed == false)
            {
                buttonsPressed++;
                button1Pressed = true;
            }

            if (Input.GetKeyDown(KeyCode.D) && button2Pressed == false)
            {
                buttonsPressed++;
                button2Pressed = true;
            }

            if(buttonsPressed == 2)
            {   
                if(routineAllower == 1)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    buttonsPressed = 0;
                    button1Pressed = false;
                    button2Pressed = false;

                    tutorialPanels[0].SetActive(false);
                    tutorialPanels[1].SetActive(true);
                    canSwitch = false;
 //                   Debug.Log("False, line 46");
                    routineAllower = 1;
                }              
            }
        }

        if (tutorialPanels[1].activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.W) && button1Pressed == false)
            {
                buttonsPressed++;
                button1Pressed = true;
            }

            if (Input.GetKeyDown(KeyCode.S) && button2Pressed == false)
            {
                buttonsPressed++;
                button2Pressed = true;
            }

            if (buttonsPressed == 2)
            {
                if (routineAllower == 1)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    buttonsPressed = 0;
                    button1Pressed = false;
                    button2Pressed = false;

                    tutorialPanels[1].SetActive(false);
                    tutorialPanels[2].SetActive(true);
                    canSwitch = false;
 //                   Debug.Log("False, line 76");
                    routineAllower = 1;
                }
            }
        }

        if (tutorialPanels[2].activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E) && button1Pressed == false)
            {
                buttonsPressed++;
                button1Pressed = true;
            }

            if (buttonsPressed == 1)
            {
                if (routineAllower == 1)
                    StartCoroutine("WaitBeforeNewPanel");

                if (canSwitch)
                {
                    buttonsPressed = 0;
                    button1Pressed = false;
                    button2Pressed = false;

                    tutorialPanels[2].SetActive(false);
                    canSwitch = false;
//                    Debug.Log("False, line 100");
                    routineAllower = 1;
                }
            }
        }
    }

    private IEnumerator WaitBeforeNewPanel()
    {
        routineAllower = 0;
        yield return new WaitForSeconds(1);
        canSwitch = true;
//        Debug.Log("True, line 108");
    //    buttonsPressed = 0;
    //    button1Pressed = false;
    //    button2Pressed = false;
         
    //    if (tutorialPanels[0].activeInHierarchy)
    //    {
    //        tutorialPanels[0].SetActive(false);
    //        tutorialPanels[1].SetActive(true);
    //        yield break;
    //    }

    //    if (tutorialPanels[1].activeInHierarchy)
    //    {
    //        tutorialPanels[1].SetActive(false);
    //        tutorialPanels[2].SetActive(true);
    //        yield break;
    //    }

    //    if (tutorialPanels[2].activeInHierarchy)
    //    {
    //        tutorialPanels[2].SetActive(false);
    //        yield break;
    //    }
    }

}
