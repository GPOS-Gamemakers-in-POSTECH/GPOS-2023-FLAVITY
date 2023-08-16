using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public static float rotCamXAxisSpeed = 1;
    public static float rotCamYAxisSpeed = 1;

    private float limitDownAngle = -80;
    private float limitUpAngle = 90;
    [SerializeField]
    private float eulerAngleX;
    [SerializeField]
    private float eulerAngleY;
    [SerializeField]
    private float eulerAngleZ;

    private GameObject arm;
    private GameObject mainCamera;
    private Vector3 armInitialLocalPosition;
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
            armInitialLocalPosition.x * Mathf.Cos(eulerAngleY * Mathf.PI / 180) + armInitialLocalPosition.y * Mathf.Sin(eulerAngleX * Mathf.PI / 180) * Mathf.Sin(eulerAngleY * Mathf.PI / 180) + armInitialLocalPosition.z * Mathf.Cos(eulerAngleX * Mathf.PI / 180) * Mathf.Sin(eulerAngleY * Mathf.PI / 180),
            armInitialLocalPosition.y * Mathf.Cos(eulerAngleX * Mathf.PI / 180) - armInitialLocalPosition.z * Mathf.Sin(eulerAngleX * Mathf.PI / 180),
            armInitialLocalPosition.y * Mathf.Sin(eulerAngleX * Mathf.PI / 180) * Mathf.Cos(eulerAngleY * Mathf.PI / 180) - armInitialLocalPosition.x * Mathf.Sin(eulerAngleY * Mathf.PI / 180) + armInitialLocalPosition.z * Mathf.Cos(eulerAngleX * Mathf.PI / 180) * Mathf.Cos(eulerAngleY * Mathf.PI / 180)
            );

        mainCamera.transform.localPosition = new Vector3(
            mainCameraInitialLocalPosition.x * Mathf.Cos(eulerAngleY * Mathf.PI / 180) + mainCameraInitialLocalPosition.y * Mathf.Sin(eulerAngleX * Mathf.PI / 180) * Mathf.Sin(eulerAngleY * Mathf.PI / 180),
            mainCameraInitialLocalPosition.y * Mathf.Cos(eulerAngleX * Mathf.PI / 180),
            mainCameraInitialLocalPosition.y * Mathf.Sin(eulerAngleX * Mathf.PI / 180) * Mathf.Cos(eulerAngleY * Mathf.PI / 180) - mainCameraInitialLocalPosition.x * Mathf.Sin(eulerAngleY * Mathf.PI / 180)
            );

        arm.transform.localRotation = Quaternion.Euler(new Vector3(eulerAngleX, eulerAngleY, 0));
        mainCamera.transform.localRotation = Quaternion.Euler(new Vector3(eulerAngleX, eulerAngleY, 0));
        cameraTransform = mainCamera.transform;
    }   

    //limitation on angle which palyer can reach
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
