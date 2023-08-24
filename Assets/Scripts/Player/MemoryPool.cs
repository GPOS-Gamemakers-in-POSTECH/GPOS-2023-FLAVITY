// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MemoryPool
// {
//     private class PoolItem
//     {
//         public bool isActive;
//         public GameObject gameObject;
//     }

//     private int increaseCount = 5;
//     private int maxCount;
//     private int activeCount;

//     private GameObject poolObject;
//     private List<PoolItem> poolItemList;

//     public int MaxCount => maxCount;
//     public int ActiveCount => activeCount;

//     public MemoryPool(GameObject poolObject)
//     {
//         maxCount = 0;
//         activeCount = 0;
//         this.poolObject = poolObject;
//         poolItemList = new List<PoolItem>();

//         InstantiateObjects();
//     }

//     public void InstantiateObjects(){
//         maxCount += increaseCount;

//         for(int i=0;i<increaseCont;i++)
//         {
//             PoolItem poolItem = new PoolItem();

//             poolItem.isActive = false;
//             poolItem.gameObject = GameObject.Instantiate(poolObject);
//             poolItem.gameObject.SetActive(false);

//             poolItemList.Add(poolItem);
//         }
//     }

//     public void DestroyObjects()
//     {
//         if(poolItemList == null) return;

//         int count = poolItemList.Count;

//         for(int i =0; i<count;i++)
//         {
//             GameObject.Destroy(poolItemList[i].gameObject);
//         }

//         poolItemList.Clear();
//     }

//     public GameObject ActivePoolItem()
//     {
//         if( poolItemList == null) return null;

//         if(maxCount == activeCount)
//         {
//             InstantiateObjects();
//         }

//         int count = poolItemList.count;
//         for(int i = 0; i<count;i++)
//         {
//             PoolItem poolItem = poolItemList[i];

//             if(poolItem.isActive == false)
//             {
//                 activeCount++;
//                 poolItem.isActive = true;
//                 poolItem.gameObejct.SetActive(true);

//                 return poolItem.gameObejct;
//             }
//         }
//         return null;
//     }


//     public void DeactivatePoolItem(GameObject removeObject)
//     {
//         if(poolItemList == null || removeObject == null) return;

//         int count = poolItemList.count;
//         for(int i = 0;i<count;i++)
//         {
//             PoolItem poolItem = poolItemList[i];
//             if(poolItem.gameObejct == removeObject){
//                 activeCount--;

//                 poolItem.isActive = false;
//                 poolItem.gameObejct.SetActive(false);

//                 return;
//             }
//         }
//     }

//     public void DeactivateAllPoolItems()
//     {
//         if(poolItemList == null) return;

//         int count =  poolItemList.count;
//         for(int i = 0;i<count;i++)
//         {
//             Poolitem poolitem = poolitemList[i];

//             if( poolitem.gameObejct !=null || poolitem.isActive == true)
//             {
//                 poolItem.isActive = false;
//                 poolItem.gameObejct.SetActive(false);
//             }
//         }

//         activeCount = 0;
//     }


// }
