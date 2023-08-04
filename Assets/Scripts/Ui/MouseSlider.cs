using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlider : SliderValue
{
    public override void Apply()
    {
        base.Apply();
        MouseControl.rotCamXAxisSpeed = saved * 100 / max;
        MouseControl.rotCamYAxisSpeed = saved / 50;
    }
}
