
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public float MoveSpeed
    {
        set =>  animator.SetFloat("movementSpeed", value);
        get =>  animator.GetFloat("movementSpeed");
    }
    public void Play(string stateName, int layer, float normalizedTime)
    {
        animator.Play(stateName,layer,normalizedTime);  
    }
}
