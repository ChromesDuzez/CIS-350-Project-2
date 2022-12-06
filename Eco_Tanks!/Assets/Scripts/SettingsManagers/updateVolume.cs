/*
* Zach Wilson
* CIS 350 - Group Project
* This script updates the volume variable in globalSettings
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _slider = gameObject.GetComponent<Slider>();
        }
        catch
        {
            Debug.LogError("[updateVolume.cs] - Could not get component Slider... try setting it manually in inspector.");
        }

        _slider.onValueChanged.AddListener((v) => {
            GlobalSettings.volume = v;
        });
    }
}
