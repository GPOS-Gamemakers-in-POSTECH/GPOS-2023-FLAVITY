using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderText : MonoBehaviour
{
    TextMeshProUGUI valueText;
    
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
    }

    public void valueUpdate(float value)
    {
        valueText.text = (int)(value) + "%";
    }
}
