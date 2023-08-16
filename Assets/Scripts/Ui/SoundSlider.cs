using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    private static float saved = 50;
    [SerializeField]
    private float max = 40;
    private Slider slider;
    public AudioMixer audioMixer;

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
        if (saved == 0) audioMixer.SetFloat("Master", -80);
        else audioMixer.SetFloat("Master", saved / 100 * max - 40);
    }
}
