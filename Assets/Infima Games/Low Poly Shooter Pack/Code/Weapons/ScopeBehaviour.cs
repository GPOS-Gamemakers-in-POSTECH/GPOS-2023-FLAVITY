//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Scope Behaviour.
    /// </summary>
    public abstract class ScopeBehaviour : MonoBehaviour
    {
        #region GETTERS

        /// <summary>
        /// Returns the value of multiplierMouseSensitivity.
        /// </summary>
        /// <returns></returns>
        public abstract float GetMultiplierMouseSensitivity();
        
        /// <summary>
        /// Returns the value of multiplierSpread.
        /// </summary>
        /// <returns></returns>
        public abstract float GetMultiplierSpread();

        /// <summary>
        /// Returns the aiming location offset.
        /// </summary>
        /// <returns></returns>
        public abstract Vector3 GetOffsetAimingLocation();
        /// <summary>
        /// Returns the aiming rotation offset.
        /// </summary>
        /// <returns></returns>
        public abstract Vector3 GetOffsetAimingRotation();

        public abstract float GetFieldOfViewMultiplierAim();
        public abstract float GetFieldOfViewMultiplierAimWeapon();

        /// <summary>
        /// Returns the Sprite used on the Character's Interface.
        /// </summary>
        public abstract Sprite GetSprite();
        /// <summary>
        /// Returns the value to multiply the weapon sway by while aiming through this scope.
        /// </summary>
        public abstract float GetSwayMultiplier();

        #endregion

        #region METHODS

        /// <summary>
        /// Called when the character using this scope aims through it.
        /// </summary>
        public abstract void OnAim();

        /// <summary>
        /// Called when the character using this scope stops aiming through it.
        /// </summary>
        public abstract void OnAimStop();

        #endregion
    }
}