using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SildeDoor : DamagableObstacle
{
    public int door_id;
    public bool isOpen;
    public float currentAngle;
    public float moveSpeed = 20f;
    public float openLength = 1.5f;
    public float currentLength = 0f;
    public Vector3 initdoorLPos;
    public Vector3 initdoorRPos;

    public Vector3 destdoorLPos;
    public Vector3 destdoorRPos;
    public GameObject doorL;
    public GameObject doorR;
    

    public void Awake()
    {
        base.Awake();
        // Set health
        maxHealth = 1;
        resetHealth();

        // Set valid damage type
        validDamageType[NormalDamageType] = false;
        validDamageType[ExplosionDamageType] = true;

        doorL = transform.Find("doorL").gameObject;
        doorR = transform.Find("doorR").gameObject;

        initdoorLPos = doorL.transform.localPosition;
        initdoorRPos = doorR.transform.localPosition;

        destdoorLPos = new Vector3(initdoorLPos.x - openLength, initdoorLPos.y, initdoorLPos.z);
        destdoorRPos = new Vector3(initdoorLPos.x + openLength, initdoorLPos.y, initdoorLPos.z);

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
            doorL.transform.localPosition = Vector3.MoveTowards(doorL.transform.localPosition, destdoorLPos, 1);
            doorR.transform.localPosition = Vector3.MoveTowards(doorR.transform.localPosition, destdoorRPos, 1);

        }
        else
        {
            doorL.transform.localPosition = Vector3.MoveTowards(doorL.transform.localPosition, initdoorLPos, 1);
            doorR.transform.localPosition = Vector3.MoveTowards(doorR.transform.localPosition, initdoorRPos, 1);
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
