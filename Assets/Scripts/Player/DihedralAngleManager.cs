using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DihedralAngleManager : MonoBehaviour
{
    // All dihedral angle manipulation must be operated in this script

    public float targetDihedralAngle;
    public float dihedralAngle;

    private bool isRotating;
    public int rotationSpeed = 5;

    private MouseControl mouseControl;

    private RaycastHit hit;
    void Awake()
    {
        mouseControl = GetComponent<MouseControl>();

        isRotating = false;
        dihedralAngle = 0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        // Rotation complete
        if (Mathf.Abs(targetDihedralAngle - dihedralAngle) < 1)
        {
            dihedralAngle = targetDihedralAngle; // Clearly set dihedral angle
            isRotating = false;
        }
        else
        {
            dihedralAngle += rotationSpeed * (targetDihedralAngle - dihedralAngle) * Time.deltaTime; // Rotate angle
            isRotating = true;
        }

        // Update isRotating and Rotatables to Player's status
        Status.isRotating = isRotating;

        if (!Physics.Raycast(transform.position, -mouseControl.cameraTransform.right, out hit, 2) && !isRotating && 
            !Status.rotated)
            Status.isCcwRotatable = true;
        else
            Status.isCcwRotatable = false;

        if (!Physics.Raycast(transform.position, mouseControl.cameraTransform.right, out hit, 2) && !isRotating &&
            !Status.rotated)
            Status.isCwRotatable = true;
        else
            Status.isCwRotatable = false;

        if (Physics.Raycast(transform.position, mouseControl.cameraTransform.right, out hit, 2) &&
            Physics.Raycast(transform.position, -mouseControl.cameraTransform.right, out hit, 2) && !isRotating ||
            Status.rotated
            )
            Status.isUpsideDownRotatable = false;
        else
            Status.isUpsideDownRotatable = true;
    }
    public void RotateCounterClockWise()
    {
        // Rotate ccw 90 deg
        if (!isRotating && Status.isCcwRotatable)
            targetDihedralAngle += 90;
    }

    public void RotateClockWise()
    {
        // Rotate cw 90 deg
        if (!isRotating && Status.isCwRotatable)
            targetDihedralAngle -= 90;
    }

    public void RotateUpsideDown()
    {
        // Rotate ccw 180 deg
        if (!isRotating) {
            if (Status.isCcwRotatable)
                targetDihedralAngle += 180;
            else if (Status.isCwRotatable)
                targetDihedralAngle -= 180;
        }
    }
}
