using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlatform : MonoBehaviour
{
    [SerializeField] float destroySec = 3f;

    // Collision with Player
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject, destroySec);
        }
    }
}
