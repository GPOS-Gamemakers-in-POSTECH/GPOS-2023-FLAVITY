//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Interactor Behaviour.
    /// </summary>
    public abstract class InteractorBehaviour : MonoBehaviour
    {
        #region UNITY

        /// <summary>
        /// Awake.
        /// </summary>
        protected virtual void Awake(){}

        /// <summary>
        /// Start.
        /// </summary>
        protected virtual void Start(){}

        /// <summary>
        /// Update.
        /// </summary>
        protected virtual void Update(){}

        /// <summary>
        /// Fixed Update.
        /// </summary>
        protected virtual void FixedUpdate(){}

        /// <summary>
        /// Late Update.
        /// </summary>
        protected virtual void LateUpdate(){}

        #endregion

        #region GETTERS

        /// <summary>
        /// Returns true if an interaction is viable.
        /// </summary>
        public abstract bool CanInteract();

        /// <summary>
        /// Returns the result of the interaction trace.
        /// </summary>
        public abstract RaycastHit GetHitResult();
        /// <summary>
        /// Returns the current interactable found by the trace.
        /// </summary>
        public abstract Interactable GetInteractable();

        #endregion
    }
}