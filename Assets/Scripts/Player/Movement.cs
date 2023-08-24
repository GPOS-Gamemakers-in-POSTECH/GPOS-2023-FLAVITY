
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
    
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if(!characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        //Debug.Log("why?");
        direction = transform.rotation * new Vector3(direction.x, 0 , direction.z);
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
        //moveForce.normalize();
        //moveForce = Vector3.Normalize(moveForce) * moveSpeed;
        //moveForce = public static Vecotr3 Normalize(moveForce);
        Debug.Log(moveForce);
    }

    public void Jump()
    {
        if(characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }
}
