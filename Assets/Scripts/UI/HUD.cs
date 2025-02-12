using System;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject left, up, right;
    [SerializeField] private TMP_Text timer;

    private void Update()
    {
        DataManager.Instance.data.time += Time.deltaTime;
        int sec = (int)DataManager.Instance.data.time % 60;
        int min = (int)DataManager.Instance.data.time / 60;
        timer.text = min.ToString("00") + " : " + sec.ToString("00");

        if (Status.isRotating)
        {
            left.SetActive(false);
            up.SetActive(false);
            right.SetActive(false);
        }
        else
        {
            if (Status.isCwRotatable) left.SetActive(true);
            else left.SetActive(false);

            if (Status.isCcwRotatable) right.SetActive(true);
            else right.SetActive(false);

            if (Status.isUpsideDownRotatable) up.SetActive(true);
            else up.SetActive(false);
        }
    }
}