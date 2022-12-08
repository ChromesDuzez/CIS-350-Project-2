/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages whether or not the quit game button should be enabled or not
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(Application.platform != RuntimePlatform.WebGLPlayer);
    }
}
