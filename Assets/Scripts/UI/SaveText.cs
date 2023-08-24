using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveText : MonoBehaviour
{
    TextMeshProUGUI text;
   
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        text = GetComponent<TextMeshProUGUI>();
        text.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        while (text.color.a > 0)
        {
            text.color = new Color(1, 1, 1, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
