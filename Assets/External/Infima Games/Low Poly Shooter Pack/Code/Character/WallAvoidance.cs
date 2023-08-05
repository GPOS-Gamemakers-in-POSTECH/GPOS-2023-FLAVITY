//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// WallAvoidance. This component handles lowering the character's equipped item when near a wall.
    /// </summary>
    public class WallAvoidance : MonoBehaviour
    {
        #region PROPERTIES
        
        /// <summary>
        /// HasWall.
        /// </summary>
        public bool HasWall => hasWall;

        #endregion
        
        #region FIELDS SERIALIZED
        
        [Title(label: "References")]
        
        [Tooltip("The Transform of the character's camera.")]
        [SerializeField, NotNull]
        private Transform playerCamera;
        
        [Title(label: "Settings")]
        
        [Tooltip("The maximum distance to check for walls.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float distance = 1.0f;
        
        [Tooltip("The radius of the sphere check.")]
        [Range(0.0f, 2.0f)]
        [SerializeField]
        private float radius = 0.5f;

        [Tooltip("The layers to count as wall layers.")]
        [SerializeField]
        private LayerMask layerMask;
        
        #endregion

        #region FIELDS
        
        /// <summary>
        /// True if there is a wall that the character is looking at.
        /// </summary>
        private bool hasWall;
        
        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Update.
        /// </summary>
        private void Update()
        {
            //Check References.
            if (playerCamera == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);

                //Return.
                return;
            }
            
            //Trace Ray.
            var ray = new Ray(playerCamera.position, playerCamera.forward);
            //Trace.
            hasWall = Physics.SphereCast(ray, radius, distance, layerMask);
        }
        
        #endregion
    }
}