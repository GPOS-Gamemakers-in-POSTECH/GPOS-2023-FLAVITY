using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : DamagableObstacle
{
    private int hitCount = 0;
    private Queue<int> hitQueue = new Queue<int>();
    public int doorOpenDelay = 5;
    public int target_id;
    public GameObject linkedDoor;

    public void Awake()
    {
        base.Awake();
        // Set health
        maxHealth = 1;
        resetHealth();

        // Set valid damage type
        validDamageType[NormalDamageType] = true;
        validDamageType[ExplosionDamageType] = true;

        // Pairing door
        GameObject[] arrayOfDoors = GameObject.FindGameObjectsWithTag("Doors");
        foreach(GameObject door in arrayOfDoors)
        {
            if (door.GetComponent<SildeDoor>().door_id == target_id)
            {
                linkedDoor = door;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
         if (health == 0)
        {
            StartCoroutine(ManageHitQueue());
            resetHealth();
        }
        if (linkedDoor != null)
        {
            if (hitQueue.Count != 0 && linkedDoor.GetComponent<SildeDoor>().isOpen == false)
            {
                linkedDoor.GetComponent<SildeDoor>().open();
            }
            else if (hitQueue.Count == 0 && linkedDoor.GetComponent<SildeDoor>().isOpen == true)
            {
                linkedDoor.GetComponent<SildeDoor>().close();
            }
        }
    }

    private IEnumerator ManageHitQueue()
    {
        hitQueue.Enqueue(hitCount);
        hitCount++;
        yield return new WaitForSeconds(doorOpenDelay);
        hitQueue.Dequeue();
    }
}
