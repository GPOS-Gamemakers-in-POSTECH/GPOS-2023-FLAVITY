
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
}
