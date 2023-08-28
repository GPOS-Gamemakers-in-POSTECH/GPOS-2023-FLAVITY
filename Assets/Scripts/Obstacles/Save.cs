using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField]
    private int pose = 0;
    [SerializeField]
    private GameObject Savetxt;
    private void OnTriggerEnter(Collider other)
    {
        if (DataManager.Instance.data.pose != pose)
        {
        DataManager.Instance.data.pose = pose;
        Savetxt.SetActive(true);
        }
    }
}
