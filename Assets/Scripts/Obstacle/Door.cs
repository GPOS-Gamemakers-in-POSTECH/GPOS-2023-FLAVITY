using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : DamagableObstacle
{
    public int door_id;
    public bool isOpen;
    public float currentAngle;
    public float moveSpeed = 20f;
    public Vector3 axis;
    public Vector3 size;
    public void Awake()
    {
        base.Awake();
        // Set health
        maxHealth = 1;
        resetHealth();

        // Set valid damage type
        validDamageType[NormalDamageType] = false;
        validDamageType[ExplosionDamageType] = true;

        
        size = gameObject.GetComponent<MeshCollider>().bounds.size;
        axis = new Vector3(
                    transform.localPosition.x + transform.localScale.x * size.x / 2 ,
                    transform.localPosition.y,
                    transform.localPosition.z
                    );
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }

        if (isOpen == true)
        {
            currentAngle = transform.localEulerAngles.y;
            if (currentAngle <= 90 + 0.5)
            {
                axis = new Vector3(
                    transform.localPosition.x + transform.localScale.x * size.x / 2,
                    transform.localPosition.y,
                    transform.localPosition.z
                    );

                transform.RotateAround(axis, new Vector3(0, 1, 0), 1 * Time.fixedDeltaTime * moveSpeed);
            }
        }
        else {
            currentAngle = transform.localEulerAngles.y;
            if (currentAngle >= 0 + 0.5)
            {
                axis = new Vector3(
                    transform.localPosition.x + transform.localScale.x * size.x / 2,
                    transform.localPosition.y,
                    transform.localPosition.z
                    );

                transform.RotateAround(axis, new Vector3(0, -1, 0), 1 * Time.fixedDeltaTime * moveSpeed);
            }

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

}
