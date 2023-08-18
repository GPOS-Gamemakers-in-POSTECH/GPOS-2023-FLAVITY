using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float dihedralAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, dihedralAngle);
        dihedralAngle += 1;
        if (dihedralAngle >= 360)
            dihedralAngle -= 360;
    }
}
