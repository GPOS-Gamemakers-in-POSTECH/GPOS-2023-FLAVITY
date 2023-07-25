//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Makes an object face the main camera.
    /// </summary>
    public class FaceCamera : MonoBehaviour
    {
        #region FIELDS

        /// <summary>
        /// Main Camera Transform.
        /// </summary>
        private Transform cameraTransform;

        #endregion
        
        #region UNITY

        private void Start()
        {
            //Cache Camera Transform.
            if (Camera.main != null) 
                cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            //Look At.
            transform.LookAt(cameraTransform, Vector3.up);
        }

        #endregion
    }
}