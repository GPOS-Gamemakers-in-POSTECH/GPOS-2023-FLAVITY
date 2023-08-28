
using UnityEngine;

public enum ImpactType { Metal = 0, Concrete, Target, ExplosiveBarrel}

public class ImpactMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] impactPrefab;
    private MemoryPool[] memoryPool;

    private void Awake() {
        memoryPool = new MemoryPool[impactPrefab.Length];
        for(int i = 0; i < impactPrefab.Length;++i)
        {
            memoryPool[i] = new MemoryPool(impactPrefab[i]);
        }
    }
    public void SpawnImpact(RaycastHit hit)
    {
        if(hit.transform.CompareTag("Metal"))
        {
            OnSpawnImpact(ImpactType.Metal,hit.point,Quaternion.LookRotation(hit.normal));
        }
        else if(hit.transform.CompareTag("Concrete"))
        {
            OnSpawnImpact(ImpactType.Concrete,hit.point,Quaternion.LookRotation(hit.normal));
        }
        else if(hit.transform.CompareTag("Target"))
        {
            OnSpawnImpact(ImpactType.Target,hit.point,Quaternion.LookRotation(hit.normal));
        }
        else if(hit.transform.CompareTag("ExplosiveBarrel"))
        {
            OnSpawnImpact(ImpactType.ExplosiveBarrel,hit.point,Quaternion.LookRotation(hit.normal));
        }
    }

    public void OnSpawnImpact(ImpactType type, Vector3 position, Quaternion rotation)
    {
        GameObject item = memoryPool[(int)type].ActivePoolItem();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.GetComponent<Impact>().Set up(memoryPool[(int)type]);
    }
}


