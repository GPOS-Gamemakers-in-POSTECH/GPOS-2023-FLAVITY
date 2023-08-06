//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Abstract movement class. Handles interactions with the main movement component.
    /// </summary>
    public abstract class MovementBehaviour : MonoBehaviour
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
        /// Returns the last Time.time value at which the character jumped.
        /// </summary>
        public abstract float GetLastJumpTime();
        
        /// <summary>
        /// Returns the value of MultiplierForward.
        /// </summary>
        /// <returns></returns>
        public abstract float GetMultiplierForward();
        /// <summary>
        /// Returns the value of MultiplierSideways.
        /// </summary>
        /// <returns></returns>
        public abstract float GetMultiplierSideways();
        /// <summary>
        /// Returns the value of MultiplierBackwards.
        /// </summary>
        /// <returns></returns>
        public abstract float GetMultiplierBackwards();

        /// <summary>
        /// Returns the character's current velocity.
        /// </summary>
        public abstract Vector3 GetVelocity();
        /// <summary>
        /// Returns true if the character is grounded.
        /// </summary>
        public abstract bool IsGrounded();
        /// <summary>
        /// Returns last frame's IsGrounded value.
        /// </summary>
        public abstract bool WasGrounded();
        
        /// <summary>
        /// Returns true if the character is jumping.
        /// </summary>
        public abstract bool IsJumping();

        /// <summary>
        /// Returns true if the character can set its crouching value to the passed parameter.
        /// </summary>
        public abstract bool CanCrouch(bool newCrouching);
        /// <summary>
        /// Returns true if the character is crouching.
        /// </summary>
        public abstract bool IsCrouching();

        #endregion

        #region METHODS

        /// <summary>
        /// Calling this will make the character jump!
        /// </summary>
        public abstract void Jump();
        /// <summary>
        /// Forces crouch/un-crouch!
        /// </summary>
        public abstract void Crouch(bool crouching);

        /// <summary>
        /// Tries to crouch/un-crouch.
        /// </summary>
        public abstract void TryCrouch(bool value);
        
        /// <summary>
        /// Tries to toggle the crouching state. This method should also make sure to handle any automatic
        /// un-crouching that may happen when the character stops being under an object.
        /// </summary>
        public abstract void TryToggleCrouch();

        #endregion
    }
}