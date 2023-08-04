using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField]
    protected float saved = 50;
    [SerializeField]
    protected float max = 2;
    protected Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Cancel()
    {
        slider.value = saved;
    }

    public virtual void Apply()
    {
        saved = slider.value;
    }
}
