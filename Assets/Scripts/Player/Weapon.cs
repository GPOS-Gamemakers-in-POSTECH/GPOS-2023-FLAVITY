using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipTakeOutWeapon; // Takeoutweapon sound

    [Header("Weapon Setting")]
    [SerializeField]
    private WeaponSetting weaponsetting;

    private float lastAttackTime = 0;

    private AudioSource audioSource; // soundplay component
    private Animation animator;

    //This is called at first activation
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animation>();
    }

    // This is called whenever activated
    private void OnEnable()
    {
        PlaySound(audioClipTakeOutWeapon);
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
                //OnAttack();
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
            //OnAttack();

            yield return null;
        }
    }

    // public void OnAttack()
    // {
    //     if(Time.time - lastAttackTime > weaponsetting.attackRate)
    //     {
    //         if(animator.MoveSpeed() > 0.5f)
    //         {
    //             return;
    //         }
    //         lastAttackTime = Time.time;

    //         animator.Play("Fire", -1,0);
    //     }

    // }
    // Take Clip sound
    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
