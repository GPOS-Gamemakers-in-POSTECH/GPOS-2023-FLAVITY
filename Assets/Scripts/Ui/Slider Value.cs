using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text valueText;
    public int Max;
    
    void Start()
    {
        valueText = GetComponent<Text>();
    }

    public void valueUpdate(float value)
    {
        valueText.text = (value * Max);
    }
}