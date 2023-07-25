//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Interactable.
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        //TODO
        [SerializeField]
        protected string interactionText;
        
        #endregion
        
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
        
        #region METHODS
        
        /// <summary>
        /// Called to interact with this object.
        /// </summary>
        /// <param name="actor">The actor starting the interaction.</param>
        public abstract void Interact(GameObject actor = null);
        
        #endregion

        #region GETTERS

        //TODO
        public virtual string GetInteractionText() => interactionText;

        #endregion
    }
}