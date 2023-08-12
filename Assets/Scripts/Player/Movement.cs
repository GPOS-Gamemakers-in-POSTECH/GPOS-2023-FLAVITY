
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



    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private CharacterController characterController;
    private PlayerControl playerControl;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerControl = GetComponent<PlayerControl>();
    }

    void Update()
    {
        float dihedralAngle = playerControl.dihedralAngle;
        if (!characterController.isGrounded) // TODO Error line
        {
            moveForce.x += - gravity * Time.deltaTime * Mathf.Abs(Mathf.Sin(dihedralAngle * Mathf.PI / 180));
            moveForce.y += gravity * Time.deltaTime * Mathf.Abs(Mathf.Cos(dihedralAngle * Mathf.PI / 180));
        }
        moveForce.x = 0;
        moveForce.y = 0;
        Debug.Log(moveForce);
        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        float dihedralAngle = playerControl.dihedralAngle;
        direction = transform.rotation * new Vector3(direction.x, direction.y , direction.z);
        moveForce = new Vector3(
            direction.x * moveSpeed * Mathf.Cos(dihedralAngle * Mathf.PI / 180) + moveForce.x * Mathf.Sin(dihedralAngle * Mathf.PI / 180), 
            direction.y * moveSpeed * Mathf.Sin(dihedralAngle * Mathf.PI / 180) + moveForce.y * Mathf.Cos(dihedralAngle * Mathf.PI / 180), 
            direction.z * moveSpeed
            );
        Debug.Log(string.Format("cos: {0}, sin: {1}", Mathf.Cos(dihedralAngle * Mathf.PI / 180), Mathf.Sin(dihedralAngle * Mathf.PI / 180)));
    }

    public void Jump()
    {
        float dihedralAngle = playerControl.dihedralAngle;
        if (characterController.isGrounded)  // TODO Error line
        {
            moveForce.x = jumpForce * Mathf.Abs(Mathf.Sin(dihedralAngle * Mathf.PI / 180));
            moveForce.y = jumpForce * Mathf.Abs(Mathf.Cos(dihedralAngle * Mathf.PI / 180));
        }
    }
}
