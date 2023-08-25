using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Key Codes
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode KeyCodeJump = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeRotateClockWise = KeyCode.Q;
    [SerializeField]
    private KeyCode keyCodeRotateCounterClockWise = KeyCode.E;

    // Audio Clips
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;
    [SerializeField]
    private AudioClip audioClipRun;

    private MouseControl mouse; // mouse control variable
    private Movement movement; // player movement control variable
    private DihedralAngleManager dihedralAngleManager;
    private Status status;
    private PlayerAnimation animator;
    private AudioSource audioSource;
    private Weapon weapon;

    private GameObject mainCamera;

    private RaycastHit hit;

    private float dihedralAngle;
    private Quaternion playerDirection; // ######### NOTE: USE THIS VARIABLE TO GET CURRENT PLAYERS DIRECTION #########

    public float doubleTapTime = 0.5f;
    private float elapsedTime;
    private int pressCount;

    //This is called at first activation
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        transform.position = DataManager.Instance.SavePoint[DataManager.Instance.data.pose];

        // Load components and gameObjects
        mouse = GetComponent<MouseControl>();
        movement = GetComponent<Movement>();
        dihedralAngleManager = GetComponent<DihedralAngleManager>();
        status = GetComponent<Status>();
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<PlayerAnimation>();
        audioSource = GetComponent<AudioSource>();
        mainCamera = transform.Find("Main Camera").gameObject;
        
        // Set rotation
        dihedralAngle = 0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, dihedralAngle));

    }
    
    // This is called whenever activated
    private void Update()
    {
        if (!PauseControl.GameIsPaused)
        {
            UpdateDihedralAngle();
            UpdateRotate();
            UpdateMove();
            UpdateJump();
            UpdateWeaponAction();
        }
    }

    private void UpdateDihedralAngle()
    {
        // Get key input and rotate player
        dihedralAngle = dihedralAngleManager.dihedralAngle; // Update dihedral angle

        // Detect double jump
        if (Physics.Raycast(transform.position, new Vector3(Mathf.Sin(dihedralAngle * Mathf.PI / 180), -Mathf.Cos(dihedralAngle * Mathf.PI / 180), 0), out hit, 3))
        {
            // count the number of times space is pressed
            if (Input.GetKeyDown(KeyCodeJump))
            {
                pressCount++;
            }

            if (pressCount == 2) // otherwise if the press count is 2
            {
                // Double pressed within the time limit
                dihedralAngleManager.RotateUpsideDown();
                resetPressTimer();
            }

            // Detect CW rotate key
            if (Input.GetKeyDown(keyCodeRotateClockWise))
            {
                if (Mathf.Cos(mainCamera.transform.localEulerAngles.y * Mathf.PI / 180) > 0)
                    dihedralAngleManager.RotateClockWise();
                else
                    dihedralAngleManager.RotateCounterClockWise();
            }

            // Detect CCW rotate key
            if (Input.GetKeyDown(keyCodeRotateCounterClockWise))
            {
                if (Mathf.Cos(mainCamera.transform.localEulerAngles.y * Mathf.PI / 180) > 0)
                    dihedralAngleManager.RotateCounterClockWise();
                else
                    dihedralAngleManager.RotateClockWise();
            }
        }


        if (pressCount > 0)
        {
            // count the time passed
            elapsedTime += Time.deltaTime;

            // if the time elapsed is greater than the time limit
            if (elapsedTime > doubleTapTime)
            {
                resetPressTimer();
            }

        }
    }

    // call mouse update rotate method using mouse input
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, dihedralAngle));
        playerDirection = mainCamera.transform.rotation;
        mouse.UpdateRotate(mouseX, mouseY, dihedralAngle);
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
            animator.MoveSpeed = isRun == true ? 1 : 0.5f;
            audioSource.clip = isRun == true ? audioClipRun : audioClipWalk;

            if(audioSource.isPlaying == false)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else{
            movement.MoveSpeed = 0;
            animator.MoveSpeed = 0;

            if(audioSource.isPlaying == true){
                audioSource.Stop();
            }
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

    //reset the press count & timer
    private void resetPressTimer()
    {
        pressCount = 0;
        elapsedTime = 0;
    }

}