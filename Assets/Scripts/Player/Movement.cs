
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
        characterController = GetComponent<CharacterController>();
        playerControl = GetComponent<PlayerControl>();
        mouseControl = GetComponent<MouseControl>();
    }

    void Update()
    {
        float dihedralAngle = playerControl.dihedralAngle;

        if (!Physics.Raycast(transform.position, new Vector3(Mathf.Sin(dihedralAngle * Mathf.PI / 180), -Mathf.Cos(dihedralAngle * Mathf.PI / 180), 0), out hit, 2)) // TODO Error line
        {
            moveForce.x += - gravity * Time.deltaTime * Mathf.Sin(dihedralAngle * Mathf.PI / 180);
            moveForce.y += gravity * Time.deltaTime * Mathf.Cos(dihedralAngle * Mathf.PI / 180);
            
        }
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        float dihedralAngle = playerControl.dihedralAngle;
        
        direction = mouseControl.cameraTransform.rotation * new Vector3(direction.x, direction.y , direction.z);
        moveForce = new Vector3(
            direction.x * moveSpeed * Mathf.Abs(Mathf.Cos(dihedralAngle * Mathf.PI / 180)) + moveForce.x * Mathf.Abs(Mathf.Sin(dihedralAngle * Mathf.PI / 180)), 
            direction.y * moveSpeed * Mathf.Abs(Mathf.Sin(dihedralAngle * Mathf.PI / 180)) + moveForce.y * Mathf.Abs(Mathf.Cos(dihedralAngle * Mathf.PI / 180)), 
            direction.z * moveSpeed
            );
        
    }

    public void Jump()
    {
        float dihedralAngle = playerControl.dihedralAngle;
        if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(dihedralAngle * Mathf.PI / 180), -Mathf.Cos(dihedralAngle * Mathf.PI / 180), 0), out hit, 2))  // TODO Error line
        {
            moveForce.x = - jumpForce * Mathf.Sin(dihedralAngle * Mathf.PI / 180);
            moveForce.y = jumpForce * Mathf.Cos(dihedralAngle * Mathf.PI / 180);
        }
    }
}
