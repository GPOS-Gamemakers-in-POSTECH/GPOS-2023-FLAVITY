
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("Walk, Run Speed")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    private int health;

    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;


    public static bool isRotating;

    public static bool isCwRotatable;
    public static bool isCcwRotatable;
    public static bool isUpsideDownRotatable;
    public static bool rotated;
    
    
    void Update()
    {
        Debug.Log(isRotating);
        Debug.Log(isCwRotatable);
        Debug.Log(isCcwRotatable);
        Debug.Log(isUpsideDownRotatable);
    }

}
