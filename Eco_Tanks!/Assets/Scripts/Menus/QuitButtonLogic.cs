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
