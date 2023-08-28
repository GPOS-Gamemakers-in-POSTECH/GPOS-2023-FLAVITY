using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
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

        ray = mainCamera.ViewportPointToRay(Vector2.one * 0.5f);

        if(Physics.Raycast(ray, out hit, weaponsetting.attackDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint  = ray.origin + ray.direction * weaponsetting.attackDistance;
        }

        Vector3 attackdirection = (targetPoint - bulletSpawnPoint.position).normalized;
        if(Physics.Raycast(bulletSpawnPoint.position, attackdirection, out hit, weaponsetting.attackDistance))
        {
            ImpactMemoryPool.SpawnImpact(hit);
        }
    }
}
