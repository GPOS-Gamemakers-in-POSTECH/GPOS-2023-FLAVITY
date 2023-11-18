using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    public Transform parent;

    [SerializeField]
    private Transform bulletSpawnPoint;
    private ImpactMemoryPool ImpactMemoryPool;
    private Camera mainCamera;

    [Header("Fire Effects")]
    [SerializeField]
    private GameObject muzzleFlashEffect;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipTakeOutWeapon; // Takeoutweapon sound
    [SerializeField]
    private AudioClip audioclipFire;

    [Header("Weapon Setting")]
    [SerializeField]
    private WeaponSetting weaponsetting;

    private float lastAttackTime = 0;

    private AudioSource audioSource; // soundplay component
    private PlayerAnimation animator;

    //This is called at first activation
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<PlayerAnimation>();

        ImpactMemoryPool =GetComponent<ImpactMemoryPool>();
        mainCamera = Camera.main;
        bullet = Resources.Load("Bullet", typeof(GameObject)) as GameObject;
        parent = transform.parent;
    }

    void Update() {
        // Debug.Log(parent.GetComponent<PlayerControl>().playerDirection.eulerAngles);
        
    }
    // This is called whenever activated
    private void OnEnable()
    {
        PlaySound(audioClipTakeOutWeapon);
        muzzleFlashEffect.SetActive(false);
    }

    public void StartWeaponACtion(int type = 0)
    {
        if(type == 0)
        {
            if(weaponsetting.isAuto == true)
            {
                StartCoroutine("OnAttackLoop");
            }
            else
            {
                OnAttack();
            }
        }
    }
    public void StopWeaopnAction(int type = 0)
    {
        if(type == 0)
        {
            StopCoroutine("OnAttackLoop");
        }
    }

    private IEnumerator OnAttackLoop()
    {
        while(true)
        {
            OnAttack();

            yield return null;
        }
    }

    public void OnAttack()
    {
        if(Time.time - lastAttackTime > weaponsetting.attackRate)
        {
            if(animator.MoveSpeed > 0.5f)
            {
                return;
            }
            lastAttackTime = Time.time;

            animator.Play("Fire", -1,0);

            StartCoroutine("OnMuzzleFlashEffect");

            PlaySound(audioclipFire);
        }

        TwoStepRayCast();
    }

    private IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlashEffect.SetActive(true);

        yield return new WaitForSeconds(weaponsetting.attackRate * 0.3f);

        muzzleFlashEffect.SetActive(false);
    }

    // Take Clip sound
    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
    
    private void TwoStepRayCast()
    {
        Ray ray;
        RaycastHit hit;
        Vector3 targetPoint = Vector3.zero;
        Vector3 direction = mainCamera.transform.forward; // EulerAngleToDirection(mainCamera.transform.eulerAngles); // - new Vector3(0, 90, 0);
        GameObject clone;
        // clone.GetComponent<Rigidbody>().velocity = parent.GetComponent<PlayerControl>().playerDirection.eulerAngles;

        // ray = mainCamera.ViewportPointToRay(Vector2.one * 0.5f);

        if(Physics.Raycast(mainCamera.transform.position, direction, out hit, weaponsetting.attackDistance) && false)
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = mainCamera.transform.position + direction * weaponsetting.attackDistance; // ray.origin + ray.direction * weaponsetting.attackDistance;
        }
        
        Vector3 attackdirection = (targetPoint - transform.position).normalized;
        
        
        clone = Instantiate(bullet, mainCamera.transform.position, Quaternion.LookRotation(attackdirection));

        if (Physics.Raycast(bulletSpawnPoint.position, attackdirection, out hit, weaponsetting.attackDistance))
        {
            //ImpactMemoryPool.SpawnImpact(hit);
            
        }
    }

    private Vector3 EulerAngleToDirection(Vector3 eulerAngle)
    {
        float pitch = eulerAngle.x;
        float yaw = eulerAngle.y;
        float roll = eulerAngle.z;

        Vector3 cameraDirection = new Vector3(
            Mathf.Cos(yaw) * Mathf.Cos(pitch),
            Mathf.Sin(yaw) * Mathf.Cos(pitch),
            Mathf.Sin(pitch)
            );

        cameraDirection = cameraDirection.normalized;
        return cameraDirection;
    }

    private Vector3 DirectionToEulerAngle(Vector3 direction)
    {
        
        float x = direction.x;
        float y = direction.y;
        float z = direction.z;
        float pitch = Mathf.Asin(z);
        float yaw = Mathf.Acos(x / Mathf.Cos(pitch));
        float yaw2 = Mathf.Asin(y / Mathf.Cos(pitch));
        Vector3 eulerAngle = new Vector3(
            pitch * 180 / (2*Mathf.PI), 
            yaw * 180 / (2*Mathf.PI), 
            0
            );

        Debug.Log("AttackDirection");
        Debug.Log(eulerAngle);
        return eulerAngle;
    }
}

    