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

    private float deltaEulerAngleX;
    private float deltaEulerAngleY;

    private GameObject arm;
    private GameObject mainCamera;
    private Vector3 armInitialLocalPosition;
    private Vector3 mainCameraInitialLocalPosition;

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
        eulerAngleY += (mouseX * rotCamXAxisSpeed * Mathf.Cos(dihedralAngle * Mathf.PI / 180) + mouseY * rotCamXAxisSpeed * Mathf.Sin(dihedralAngle * Mathf.PI / 180));
        eulerAngleX -= (mouseY * rotCamYAxisSpeed * Mathf.Abs(Mathf.Cos(dihedralAngle * Mathf.PI / 180)) + mouseX * rotCamYAxisSpeed * Mathf.Sin(dihedralAngle * Mathf.PI / 180));
        
        // eulerAngleZ += mouseY * rotCamXAxisSpeed * Mathf.Sin(dihedralAngle * Mathf.PI / 180);
        Debug.Log(string.Format("rot:{0}", transform.localEulerAngles)) ;

        if (dihedralAngle >= 360)
            dihedralAngle -= 360;
        if (dihedralAngle < 0)
            dihedralAngle += 360;

        transform.Rotate(new Vector3(deltaEulerAngleX, deltaEulerAngleY, 0) * Time.deltaTime);
        // eulerAngleX = transform.rotation.eulerAngles.x;
        // eulerAngleY = transform.rotation.eulerAngles.y;

        if ((-45 + 360 <= dihedralAngle && dihedralAngle < 0 + 360) || (0 + 0 <= dihedralAngle && dihedralAngle < 45 + 0))
        {
            
            eulerAngleX = ClampAngle(eulerAngleX, limitDownAngle, limitUpAngle);
        }

        if (-45 + 90 <= dihedralAngle && dihedralAngle < 45 + 90)
        {
            // eulerAngleY = ClampAngle(eulerAngleY, limitDownAngle, limitUpAngle);
        }

        if (-45 + 180 <= dihedralAngle && dihedralAngle < 45 + 180)
        {
            eulerAngleX = ClampAngle(eulerAngleX, 180 + limitDownAngle, 360 - limitUpAngle);
        }

        if (-45 + 270 <= dihedralAngle && dihedralAngle < 45 + 270)
        {
            // eulerAngleY = ClampAngle(eulerAngleY, 180 + limitDownAngle, 360 - limitUpAngle);
        }

        //transform.localRotation = Quaternion.Euler(eulerAngleX, eulerAngleY, eulerAngleZ);
        
        // eulerAngleZ = transform.eulerAngles.z;  <= -179.9f ? -179.9f : transform.eulerAngles.z >= 179.9f ? 179.9f : 0
        
        transform.rotation = Quaternion.Euler(new Vector3(eulerAngleX, eulerAngleY, 90));
        arm.transform.localEulerAngles = new Vector3(0, 0, dihedralAngle);
        mainCamera.transform.localEulerAngles = new Vector3(0, 0, dihedralAngle);

        arm.transform.localPosition = new Vector3(
            armInitialLocalPosition.x * Mathf.Cos(dihedralAngle * Mathf.PI / 180) - armInitialLocalPosition.y * Mathf.Sin(dihedralAngle * Mathf.PI / 180),
            armInitialLocalPosition.y * Mathf.Cos(dihedralAngle * Mathf.PI / 180) + armInitialLocalPosition.x * Mathf.Sin(dihedralAngle * Mathf.PI / 180),
            armInitialLocalPosition.z
            );

        mainCamera.transform.localPosition = new Vector3(
            mainCameraInitialLocalPosition.x * Mathf.Cos(dihedralAngle * Mathf.PI / 180) - mainCameraInitialLocalPosition.y * Mathf.Sin(dihedralAngle * Mathf.PI / 180),
            mainCameraInitialLocalPosition.y * Mathf.Cos(dihedralAngle * Mathf.PI / 180) + mainCameraInitialLocalPosition.x * Mathf.Sin(dihedralAngle * Mathf.PI / 180),
            mainCameraInitialLocalPosition.z
            );

    }   

    //limitation on angle which palyer can reach
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
