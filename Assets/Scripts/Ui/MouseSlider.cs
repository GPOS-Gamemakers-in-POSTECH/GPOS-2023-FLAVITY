using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : MonoBehaviour
{
    [SerializeField]
    private float max = 2;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataManager.Instance.data.mouse;
    }

    public void Cancel()
    {
        slider.value = DataManager.Instance.data.mouse;
    }
    public void Apply()
    {
        DataManager.Instance.data.mouse = slider.value;
        MouseControl.rotCamXAxisSpeed = DataManager.Instance.data.mouse / 100 * max;
        MouseControl.rotCamYAxisSpeed = DataManager.Instance.data.mouse / 100 * max;
    }
    private void OnDisable()
    {
        Cancel();
    }
}
