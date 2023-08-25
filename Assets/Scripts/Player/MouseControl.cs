using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public static float rotCamXAxisSpeed = 1;
    public static float rotCamYAxisSpeed = 1;

    private float limitDownAngle = -80;
    private float limitUpAngle = 90;

    public float eulerAngleX;
    private float eulerAngleY;

    private GameObject arm;
    private Vector3 armInitialLocalPosition;

    private GameObject mainCamera;
    private Vector3 mainCameraInitialLocalPosition;

    public Transform cameraTransform;

    private void Awake()
    {
        arm = transform.Find("(Legacy)arms_assault_rifle_01").gameObject;
        mainCamera = transform.Find("Main Camera").gameObject;

        armInitialLocalPosition = arm.transform.localPosition;
        mainCameraInitialLocalPosition = mainCamera.transform.localPosition;
    }

    // mouse update method
    public void UpdateRotate(float mouseX, float mouseY, float dihedralAngle)
    {

        eulerAngleY += mouseX * rotCamXAxisSpeed;
        eulerAngleX -= mouseY * rotCamYAxisSpeed;

        if (dihedralAngle >= 360)
            dihedralAngle -= 360;
        if (dihedralAngle < 0)
            dihedralAngle += 360;

        eulerAngleX = ClampAngle(eulerAngleX, limitDownAngle, limitUpAngle);

        arm.transform.localPosition = new Vector3(
            armInitialLocalPosition.x * Mathf.Cos(Rad(eulerAngleY)) + armInitialLocalPosition.y * Mathf.Sin(Rad(eulerAngleX)) * Mathf.Sin(Rad(eulerAngleY)) + armInitialLocalPosition.z * Mathf.Cos(Rad(eulerAngleX)) * Mathf.Sin(Rad(eulerAngleY)),
            armInitialLocalPosition.y * Mathf.Cos(Rad(eulerAngleX)) - armInitialLocalPosition.z * Mathf.Sin(Rad(eulerAngleX)),
            armInitialLocalPosition.y * Mathf.Sin(Rad(eulerAngleX)) * Mathf.Cos(Rad(eulerAngleY)) - armInitialLocalPosition.x * Mathf.Sin(Rad(eulerAngleY)) + armInitialLocalPosition.z * Mathf.Cos(Rad(eulerAngleX)) * Mathf.Cos(Rad(eulerAngleY))
            );

        mainCamera.transform.localPosition = new Vector3(
            mainCameraInitialLocalPosition.x * Mathf.Cos(Rad(eulerAngleY)) + mainCameraInitialLocalPosition.y * Mathf.Sin(Rad(eulerAngleX)) * Mathf.Sin(Rad(eulerAngleY)),
            mainCameraInitialLocalPosition.y * Mathf.Cos(Rad(eulerAngleX)),
            mainCameraInitialLocalPosition.y * Mathf.Sin(Rad(eulerAngleX)) * Mathf.Cos(Rad(eulerAngleY)) - mainCameraInitialLocalPosition.x * Mathf.Sin(Rad(eulerAngleY))
            );

        arm.transform.localRotation = Quaternion.Euler(new Vector3(eulerAngleX, eulerAngleY, 0));
        mainCamera.transform.localRotation = Quaternion.Euler(new Vector3(eulerAngleX, eulerAngleY, 0));
        cameraTransform = mainCamera.transform;
    }   

    //limitation on angle which player can reach
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
    private float Rad(float value)
    {
        return value * Mathf.PI / 180;
    }
}
