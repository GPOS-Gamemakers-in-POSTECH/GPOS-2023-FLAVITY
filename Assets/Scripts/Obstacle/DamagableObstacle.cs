using UnityEngine;
using System;

abstract public class DamagableObstacle : MonoBehaviour
{
    public const int NormalDamageType = 0;
    public const int ExplosionDamageType = 1;

    /// <summary>
    /// Current Health of DamagableObstacle.
    /// </summary>
    [SerializeField]
    protected int health;

    /// <summary>
    /// Maximum Health of DamagableObstacle.
    /// </summary>
    [SerializeField]
    protected int maxHealth;
    
    /// <summary>
    /// Boolean array of what damageType is valid for DamagableObstacle.
    /// </summary>
    /// <example>
    /// validDamageType[damageType] = true if damageType is valid for DamagableObstacle.
    /// validDamageType[damageType] = false if damageType is invalid for DamagableObstacle.
    /// </example>
    /// <remarks>
    /// Must be allocated and defined in Awake()
    /// </remarks>
    protected bool[] validDamageType;

    /// <remarks>
    /// Must be overrided by child class.
    /// </remarks>
    protected void Awake()
    {
        validDamageType = new bool[2];
    }
    /// <summary>
    /// Give DamagalbeObstacle Damage.
    /// </summary>
    /// <param name="damageType"></param>
    /// <param name="damageValue"></param>
    public void receiveDamage(int damageType, int damageValue)
    {
        // Receive damage
        if (isDamageValid(damageType))
            health = Math.Max(health - damageValue, 0);
        
    }
    /// <summary>
    /// Set health to max
    /// </summary>
    public void resetHealth()
    {
        health = maxHealth;
    }
    /// <summary>
    /// Check whether received damage is valid for DamagableObstacle
    /// </summary>
    /// <param name="damageType"></param>
    /// <returns name="validDamageType[damageType]"></returns>
    private bool isDamageValid(int damageType)
    {
        return validDamageType[damageType];
    }

}
