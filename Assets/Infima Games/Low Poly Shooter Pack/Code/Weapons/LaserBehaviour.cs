//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Laser Abstract Class.
    /// </summary>
    public abstract class LaserBehaviour : MonoBehaviour
    {
        #region GETTERS

        /// <summary>
        /// Returns the Sprite used on the Character's Interface.
        /// </summary>
        public abstract Sprite GetSprite();
        
        /// <summary>
        /// Returns true if this laser should be off while the character is running.
        /// </summary>
        public abstract bool GetTurnOffWhileRunning();
        /// <summary>
        /// Returns true if this laser should be off while the character is aiming.
        /// </summary>
        public abstract bool GetTurnOffWhileAiming();

        /// <summary>
        /// Toggles the laser.
        /// </summary>
        public abstract void Toggle();
        /// <summary>
        /// Reapplies the laser.
        /// </summary>
        public abstract void Reapply();
        /// <summary>
        /// Hides the laser.
        /// </summary>
        public abstract void Hide();

        #endregion
    }
}