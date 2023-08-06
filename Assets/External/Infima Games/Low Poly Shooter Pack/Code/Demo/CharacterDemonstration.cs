//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Character Demonstration.
    /// </summary>
    public class CharacterDemonstration : MonoBehaviour
    {
        #region FIELDS SERIALIZED
        
        [Tooltip("Transform component of the character weapon's magazine.")]
        [SerializeField]
        private Transform magazineTransform;

        [Tooltip("Magazine Prefab. A generic one is used, no need for specific prefabs.")]
        [SerializeField]
        private GameObject prefabMagazine;
        
        #endregion

        #region FIELDS

        /// <summary>
        /// Mesh Filter.
        /// </summary>
        private MeshFilter meshFilter;
        /// <summary>
        /// Mesh Renderer.
        /// </summary>
        private MeshRenderer meshRenderer;

        #endregion

        #region UNITY

        private void Awake()
        {
            //Cache filter component.
            meshFilter = magazineTransform.GetComponent<MeshFilter>();
            //Cache renderer component.
            meshRenderer = magazineTransform.GetComponent<MeshRenderer>();
        }

        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Spawns a magazine, and hides the one visible, depending on the drop value.
        /// </summary>
        /// <param name="drop">If true, a magazine is spawned, and the visual one is hidden, otherwise the visual
        /// magazine is made visible.</param>
        public void DropMagazine(bool drop = true)
        {
            //Disable magazine when dropping! This avoids having double magazines!
            magazineTransform.gameObject.SetActive(!drop);

            //Spawn Drop.
            if (!drop)
                return;
            
            //Spawn new magazine.
            GameObject spawnedMagazine = Instantiate(prefabMagazine, magazineTransform.position,
                magazineTransform.rotation);
            //Update shared materials. This makes the materials match.
            spawnedMagazine.GetComponent<MeshRenderer>().sharedMaterials =
                meshRenderer.sharedMaterials;
            //Update filter mesh. This makes the mesh match.
            spawnedMagazine.GetComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
            
            //Destroy after a few seconds.
            Destroy(spawnedMagazine, 5.0f);
        }
        
        #endregion
    }
}