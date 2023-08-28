using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack.Legacy;

public class Explosive : DamagableObstacle
{
    private float explosionDelay;
    private bool routineStarted = false;

    [Header("Prefabs")]
    public GameObject explosionPrefab;
    public GameObject damagedExplosivePrefab;

    [Header("Explosion Delay Options")]
    public float explosionMinDelay = 0.05f;
    public float explosionMaxDelay = 0.25f;

    [Header("Explosion Physics Options")]
    public float explosionRadius = 12.5f;
    public float explosionForce = 4000.0f;
    public int explosionDamage = 3;
    
    public void Awake()
    {
        base.Awake();
        
        // Set health
        maxHealth = 3;
        resetHealth();

        // Set valid damage type
        validDamageType[NormalDamageType] = true;
        validDamageType[ExplosionDamageType] = true;

        // explosionPrefab = GameObject.Find("Assets/Prefabs/ExplosionEffect.prefab");
        // damagedExplosivePrefab = GameObject.Find("Assets/Infima Games/Low Poly Shooter Pack/Prefabs/Damageables/P_LPSP_DMG_Barrel_Destroyed.prefab");
    }

    // Update is called once per frame
    void Update()
    {
        
        explosionDelay = Random.Range(explosionMinDelay, explosionMaxDelay);

        if (health == 0)
        {
            if (!routineStarted)
            {
                
                StartCoroutine(Explode());
                routineStarted = true;
            }

        }
    }

    /// <summary>
    /// Delay explosion.
    /// Create damaged explosive prefab.
    /// Give physical force and damage to nearby colliders.
    /// Create explosion prefab.
    /// Destroys itself.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Explode() {
        // Wait for set amount of delay
        yield return new WaitForSeconds(explosionDelay);
        // Spawn the damaged explosive prefab
        Instantiate(damagedExplosivePrefab, transform.position, transform.rotation);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        // Give physical effect on objects in range of explosion radius.
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Debug.Log(hit.transform.name);
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            // Push nearby objects with explosion force 
            if (rb != null && (hit.transform.tag == "Explosive" ||
                hit.transform.tag == "Target" ||
                hit.transform.tag == "Door") && this != hit)
                rb.AddExplosionForce(explosionForce * 50, explosionPosition, explosionRadius);

            Debug.Log(hit.transform.tag);
            // Give explosion damage to DamagableObstacles
            if ((hit.transform.tag == "Explosive" ||
                hit.transform.tag == "Target" ||
                hit.transform.tag == "Door"))
                if (hit.transform.tag == "Door"){
                    Debug.Log("dasd");
                    Debug.Log(hit.gameObject.transform.parent);
                    hit.gameObject.transform.parent.gameObject.GetComponent<DamagableObstacle>().receiveDamage(ExplosionDamageType, explosionDamage);
                }
                else{
                    hit.gameObject.GetComponent<DamagableObstacle>().receiveDamage(ExplosionDamageType, explosionDamage);
                }
        
        
        
        }


        /*
          // Raycast downwards to check the ground tag
         RaycastHit checkGround;
         if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
         {
             // Instantiate explosion prefab at hit position
             Instantiate(explosionPrefab, checkGround.point,
                 Quaternion.FromToRotation(Vector3.forward, checkGround.normal));
         }
         */

        Destroy(gameObject);
    }
}
