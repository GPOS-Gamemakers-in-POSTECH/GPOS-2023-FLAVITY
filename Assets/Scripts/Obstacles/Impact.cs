// using UnityEngine;

// public class Impact : MonoBehaviour
// {
//     private ParticleSystem particle;
//     private MemoryPool memoryPool;

//     private void Awake()
//     {
//         particle = GetComponent<ParticleSystem>();
//     }
    
//     public void Setup(MemoryPool pool) 
//     {
//         memoryPool = pool;
//     }

//     private void Update() 
//     {
//         if(particle.isPlaying == false)
//         {
//             memoryPool.DeactivatePoolItem(gameObject);
//         }
//     }
// }
