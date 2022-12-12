using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarsStunTextUpdater : MonoBehaviour
{
    private Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        updateTextbox();
    }

    public void updateTextbox()
    {
        if (GlobalSettings.carsStun)
            textbox.text = "Cars Stun: ON";
        else
            textbox.text = "Cars Stun: OFF";
    }
}
