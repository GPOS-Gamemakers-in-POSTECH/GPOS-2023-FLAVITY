using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode KeyCodeJump = KeyCode.Space;

    private MouseControl mouse; // mouse control variable
    private Movement movement; // player movement control variable
    private Status status;
    private Weapon weapon;
    //This is called at first activation
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mouse = GetComponent<MouseControl>();
        movement = GetComponent<Movement>();
        status = GetComponent<Status>();
        weapon = GetComponentInChildren<Weapon>();
    }
    
    // This is called whenever activated
    private void Update()
    {
        UpdateRotate();
        // Debug.Log("why?");
        UpdateMove();
        UpdateJump();
    }

    // call mouse update rotate method using mouse input
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouse.UpdateRotate(mouseX,mouseY);
    }

    //call movement update method
    private void UpdateMove()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0 || z !=0)
        {
            bool isRun = false;
            
            if(z>0) isRun = Input.GetKey(keyCodeRun);

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
        }
        movement.MoveTo(new Vector3(x,0,z));
    }
    private void UpdateJump()
    {
        if(Input.GetKey(KeyCodeJump))
        {
            movement.Jump();
        }
    }

    private void UpdateWeaponAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.StartWeaponACtion();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            weapon.StopWeaopnAction();
        }
    }
}
