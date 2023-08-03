using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DamagableObstacle
{
    public int door_id;
    public bool isOpen = false;
    public float currentAngle = 0f;

    public void Awake()
    {
        base.Awake();
        // Set health
        maxHealth = 1;
        resetHealth();

        // Set valid damage type
        validDamageType[NormalDamageType] = false;
        validDamageType[ExplosionDamageType] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }
    public void open()
    {
        isOpen = true;

    }

    public void close()
    {
        isOpen = false;
    }

    private void rotateAroundAxis(int destAngle)
    {
        Vector3 size = gameObject.GetComponent<MeshCollider>().bounds.size;
        // Vector3 axis = new Vector3(transform.x +  * size.y)
    }
}
