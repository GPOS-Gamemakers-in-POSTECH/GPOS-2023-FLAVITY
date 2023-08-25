
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravity;

    private MouseControl mouseControl;
    private DihedralAngleManager dihedralAngleManager;
    
    private float dihedralAngle;
    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private CharacterController characterController;
    private PlayerControl playerControl;
    private RaycastHit hit;

    private void Awake()
    {
        // Load components
        characterController = GetComponent<CharacterController>();
        playerControl = GetComponent<PlayerControl>();
        mouseControl = GetComponent<MouseControl>();
        dihedralAngleManager = GetComponent<DihedralAngleManager>();
    }

    void Update()
    {
        dihedralAngle = dihedralAngleManager.targetDihedralAngle;
        // Debug.Log(Status.isRotating);

        // Give player gravitational acceleration
        if (!Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Rad(dihedralAngle)), -Mathf.Cos(Rad(dihedralAngle)), 0), out hit, 2)) // TODO Error line
        {
            moveForce.x += - gravity * Time.deltaTime * Mathf.Sin(Rad(dihedralAngle));
            moveForce.y += gravity * Time.deltaTime * Mathf.Cos(Rad(dihedralAngle));
            
        }
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = mouseControl.cameraTransform.rotation * new Vector3(direction.x, direction.y , direction.z); // Convert direction's frame in to camera's frame

        if (Mathf.Abs(Mathf.Sin(Rad(dihedralAngle))) > 0.9)
            moveForce = new Vector3(
                moveForce.x,
                direction.y * moveSpeed,
                direction.z * moveSpeed
                );

        if (Mathf.Abs(Mathf.Cos(Rad(dihedralAngle))) > 0.9)
        {
            moveForce = new Vector3(
                direction.x * moveSpeed,
                moveForce.y,
                direction.z * moveSpeed
                );
        }
        
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(Rad(dihedralAngle)), -Mathf.Cos(Rad(dihedralAngle)), 0), out hit, 2)) // If touching ground
        {
            if (Mathf.Abs(Mathf.Sin(Rad(dihedralAngle))) > 0.9)
                moveForce.x = -jumpForce * Mathf.Sin(Rad(dihedralAngle));

            else if (Mathf.Abs(Mathf.Cos(Rad(dihedralAngle))) > 0.9) 
                moveForce.y = jumpForce * Mathf.Cos(Rad(dihedralAngle));
        }
    }

    private float Rad(float value)
    {
        return value * Mathf.PI / 180;
    }
}
