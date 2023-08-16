using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : MonoBehaviour
{
    [SerializeField]
    private static float saved = 50;
    [SerializeField]
    private float max = 2;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = saved;
    }

    public void Cancel()
    {
        slider.value = saved;
    }
    public void Apply()
    {
        saved = slider.value;
        MouseControl.rotCamXAxisSpeed = saved / 100 * max;
        MouseControl.rotCamYAxisSpeed = saved / 100 * max;
    }
}
