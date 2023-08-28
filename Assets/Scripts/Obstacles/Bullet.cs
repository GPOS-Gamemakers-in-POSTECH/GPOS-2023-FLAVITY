//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEditor;
using System.Collections;
using InfimaGames.LowPolyShooterPack;
using Random = UnityEngine.Random;

namespace InfimaGames.LowPolyShooterPack.Legacy
{
	public class Bullet : MonoBehaviour
	{

		[Range(5, 6)]
		[Tooltip("After how long time should the bullet prefab be destroyed?")]
		public float destroyAfter = 5;

		[Tooltip("If enabled the bullet destroys on impact")]
		public bool destroyOnImpact = false;

		[Tooltip("Minimum time after impact that the bullet is destroyed")]
		public float minDestroyTime;

		[Tooltip("Maximum time after impact that the bullet is destroyed")]
		public float maxDestroyTime;

		[Header("Impact Effect Prefabs")]
		public Transform[] metalImpactPrefabs;
		public Transform[] concreteImpactPrefabs;

		public Rigidbody rb;

		private void Start()
		{

			metalImpactPrefabs = new Transform[1];
			concreteImpactPrefabs = new Transform[1];
			metalImpactPrefabs[0] = (Resources.Load("P_IMP_Metal", typeof(GameObject)) as GameObject).transform;
			concreteImpactPrefabs[0] = (Resources.Load("P_IMP_Concrete", typeof(GameObject)) as GameObject).transform;
			rb = GetComponent<Rigidbody>();
			//Start destroy timer
			StartCoroutine(DestroyAfter());
		}

        private void Update()
        {
			rb.velocity = transform.forward * 10000;
			// Debug.Log(transform.rotation.eulerAngles);
        }

        //If the bullet collides with anything
        private void OnCollisionEnter(Collision collision)
		{
			//Ignore collisions with other projectiles.
			if (collision.gameObject.GetComponent<Projectile>() != null)
				return;

			// //Ignore collision if bullet collides with "Player" tag
			// if (collision.gameObject.CompareTag("Player")) 
			// {
			// 	//Physics.IgnoreCollision (collision.collider);
			// 	Debug.LogWarning("Collides with player");
			// 	//Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
			//
			// 	//Ignore player character collision, otherwise this moves it, which is quite odd, and other weird stuff happens!
			// 	Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
			//
			// 	//Return, otherwise we will destroy with this hit, which we don't want!
			// 	return;
			// }
			//
			//If destroy on impact is false, start 
			//coroutine with random destroy timer
			if (!destroyOnImpact)
			{
				StartCoroutine(DestroyTimer());
			}
			//Otherwise, destroy bullet on impact
			else
			{
				Destroy(gameObject);
			}

			//If bullet collides with "Metal" tag
			if (collision.transform.tag == "Metal")
			{
				//Instantiate random impact prefab from array
				Instantiate(metalImpactPrefabs[Random.Range
						(0, metalImpactPrefabs.Length)], transform.position,
					Quaternion.LookRotation(collision.contacts[0].normal));
				//Destroy bullet object
				Destroy(gameObject);
			}
			
			//If bullet collides with "Concrete" tag
			if (collision.transform.tag == "Concrete")
			{
				//Instantiate random impact prefab from array
				Instantiate(concreteImpactPrefabs[Random.Range
						(0, concreteImpactPrefabs.Length)], transform.position,
					Quaternion.LookRotation(collision.contacts[0].normal));
				//Destroy bullet object
				Destroy(gameObject);
			}

			//If bullet collides with "Target" tag
			if (collision.transform.tag == "Target")
			{
				//Toggle "isHit" on target object
				collision.transform.gameObject.GetComponent
					<Target>().receiveDamage(0, 1);
				//Destroy bullet object
				Destroy(gameObject);
			}

			//If bullet collides with "ExplosiveBarrel" tag
			if (collision.transform.tag == "Explosive")
			{
				
				//Toggle "explode" on explosive barrel object
				collision.transform.gameObject.GetComponent
					<Explosive>().receiveDamage(0, 1);
				//Destroy bullet object
				Destroy(gameObject);
			}
			Destroy(gameObject);
		}

		private IEnumerator DestroyTimer()
		{
			//Wait random time based on min and max values
			yield return new WaitForSeconds
				(Random.Range(minDestroyTime, maxDestroyTime));
			//Destroy bullet object
			Destroy(gameObject);
		}

		private IEnumerator DestroyAfter()
		{
			//Wait for set amount of time
			yield return new WaitForSeconds(destroyAfter);
			//Destroy bullet object
			Destroy(gameObject);
		}
	}
}