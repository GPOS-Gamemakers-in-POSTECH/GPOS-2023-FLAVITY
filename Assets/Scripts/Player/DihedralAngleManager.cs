using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DihedralAngleManager : MonoBehaviour
{
    public float targetDihedralAngle;
    private float dihedralAngle;
    private PlayerControl playerControl;
    public bool isrotating;
    public int rotationSpeed = 5;
    void Awake()
    {
        isrotating = false;
        playerControl = GetComponent<PlayerControl>();
    }
    
    // Update is called once per frame
    void Update()
    {
        dihedralAngle = playerControl.dihedralAngle;
        if (Mathf.Abs(targetDihedralAngle - dihedralAngle) < 1)
        {
            playerControl.dihedralAngle = targetDihedralAngle;
            isrotating = false;
        }
        else
        {
            playerControl.dihedralAngle += rotationSpeed * (targetDihedralAngle - dihedralAngle) * Time.deltaTime;
            isrotating = true;
        }
    }
    public void RotateCounterClockWise()
    {
        if (!isrotating)
            targetDihedralAngle += 90;
    }

    public void RotateClockWise()
    {
        if (!isrotating)
            targetDihedralAngle -= 90;
    }

    public void RotateUpsideDown()
    {
        if (!isrotating)
            targetDihedralAngle += 180;
    }
}
