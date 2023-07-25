//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public class CopyTransform : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Tooltip("Transform to copy from.")]
        [SerializeField]
        private Transform copy;

        #endregion

        #region FIELDS

        /// <summary>
        /// Local Transform.
        /// </summary>
        private Transform local;

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        private void Awake()
        {
            //Cache local.
            local = transform;
        }

        /// <summary>
        /// Update.
        /// </summary>
        private void Update()
        {
            //Copy position.
            local.position = copy.position;
            //Copy rotation.
            local.rotation = copy.rotation;
            //Copy scale.
            local.localScale = copy.localScale;
        }

        #endregion
    }
}