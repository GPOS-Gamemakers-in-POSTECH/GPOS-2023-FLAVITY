using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    private Slider slider;
    public AudioMixer audioMixer;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataManager.Instance.data.sound;
    }

    public void Cancel()
    {
        slider.value = DataManager.Instance.data.sound;
    }

    public void Apply()
    {
        DataManager.Instance.data.sound = slider.value;
        if (DataManager.Instance.data.sound == 0) audioMixer.SetFloat("Master", -80);
        else audioMixer.SetFloat("Master", DataManager.Instance.data.sound / 100 * 40 - 40);
    }
    private void OnDisable()
    {
        Cancel();
    }
}
