using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;
    [SerializeField]
    private KeyCode KeyCodeJump = KeyCode.Space;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;
    [SerializeField]
    private AudioClip audioClipRun;

    private MouseControl mouse; // mouse control variable
    private Movement movement; // player movement control variable
    private Status status;
    private PlayerAnimation animator;
    private AudioSource audioSource;
    private Weapon weapon;

    private GameObject arm;
    private GameObject mainCamera;
    private Vector3 armInitialLocalPosition;
    private Vector3 mainCameraInitialLocalPosition;

    public float dihedralAngle;
    //This is called at first activation
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mouse = GetComponent<MouseControl>();
        movement = GetComponent<Movement>();
        status = GetComponent<Status>();
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<PlayerAnimation>();
        audioSource = GetComponent<AudioSource>();

        arm = transform.Find("(Legacy)arms_assault_rifle_01").gameObject;
        mainCamera = transform.Find("Main Camera").gameObject;

        armInitialLocalPosition = arm.transform.localPosition;
        mainCameraInitialLocalPosition = mainCamera.transform.localPosition;

        dihedralAngle = 90f;
    }
    
    // This is called whenever activated
    private void Update()
    {
        if (!PauseControl.GameIsPaused)
        {
            UpdateRotate();
            UpdateMove();
            UpdateJump();
            UpdateWeaponAction();
        }
    }

    // call mouse update rotate method using mouse input
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouse.UpdateRotate(mouseX,mouseY, dihedralAngle);

        Debug.Log(string.Format("arm : {0}, maincam : {1}", arm.transform.localEulerAngles, mainCamera.transform.localEulerAngles));
        
        

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
}