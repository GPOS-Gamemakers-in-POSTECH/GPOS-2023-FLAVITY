using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : SliderValue
{
    [SerializeField]
    private List<AudioSource> musicsources;
    public override void Apply()
    {
        base.Apply();
        foreach (var musicsource in musicsources)
        {
            musicsource.volume = saved / 100;
        }
    }
}
