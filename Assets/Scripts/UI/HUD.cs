using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject left, up, right;
    Image image;

    void Start(){
        image = GetComponent<Image>();    
    }

    void Update()
    {
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
