/*
* Zach Wilson
* CIS 350 - Group Project
* This script manages the slider and updates its value text
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _sliderText;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _slider = gameObject.GetComponent<Slider>();
        }
        catch
        {
            Debug.LogError("[SliderScript.cs] - Could not get component Slider... try setting it manually in inspector.");
        }

        try
        {
            if(gameObject.GetComponentInChildren<TextMeshProUGUI>().CompareTag("Value"))
            {
                _sliderText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            }
        }
        catch
        {
            Debug.LogError("[SliderScript.cs] - Failed to initialize _sliderText");
        }

        _slider.onValueChanged.AddListener((v) => {
            _sliderText.text = v.ToString("0.00");
        });
    }
}
