using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderValue : MonoBehaviour
{
    TextMeshProUGUI valueText;
    public int Max;
    
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
    }

    public void valueUpdate(float value)
    {
        valueText.text = (int)(value * Max) + "%";
    }
}