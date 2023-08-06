//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Animator Hashes.
    /// </summary>
    public static class AHashes
    {
        /// <summary>
        /// Leaning Bool Hash.
        /// </summary>
        public static readonly int Leaning = Animator.StringToHash("Leaning");
        /// <summary>
        /// Aiming Bool Hash.
        /// </summary>
        public static readonly int Aim = Animator.StringToHash("Aim");
        
        /// <summary>
        /// Crouching Bool Hash.
        /// </summary>
        public static readonly int Crouching = Animator.StringToHash("Crouching");
        
        /// <summary>
        /// Leaning Float Hash.
        /// </summary>
        public static readonly int LeaningInput = Animator.StringToHash("Leaning Input");
        /// <summary>
        /// Stop Trigger Hash.
        /// </summary>
        public static readonly int Stop = Animator.StringToHash("Stop");
        
        /// <summary>
        /// Reloading Bool Hash.
        /// </summary>
        public static readonly int Reloading = Animator.StringToHash("Reloading");
        /// <summary>
        /// Inspecting Bool Hash.
        /// </summary>
        public static readonly int Inspecting = Animator.StringToHash("Inspecting");
        
        /// <summary>
        /// Meleeing Bool Hash.
        /// </summary>
        public static readonly int Meleeing = Animator.StringToHash("Meleeing");
        /// <summary>
        /// Grenading Bool Hash.
        /// </summary>
        public static readonly int Grenading = Animator.StringToHash("Grenading");
        
        /// <summary>
        /// Bolt Action Bool Hash.
        /// </summary>
        public static readonly int Bolt = Animator.StringToHash("Bolt Action");
        
        /// <summary>
        /// Holstering Bool Hash.
        /// </summary>
        public static readonly int Holstering = Animator.StringToHash("Holstering");
        /// <summary>
        /// Holstered Bool Hash.
        /// </summary>
        public static readonly int Holstered = Animator.StringToHash("Holstered");

        /// <summary>
        /// Running Bool Hash.
        /// </summary>
        public static readonly int Running = Animator.StringToHash("Running");
        /// <summary>
        /// Lowered Bool Hash.
        /// </summary>
        public static readonly int Lowered = Animator.StringToHash("Lowered");
        
        /// <summary>
        /// Alpha Action Offset Float Hash.
        /// </summary>
        public static readonly int AlphaActionOffset = Animator.StringToHash("Alpha Action Offset");

        /// <summary>
        /// AlphaIKHandLeft.
        /// </summary>
        public static readonly int AlphaIKHandLeft = Animator.StringToHash("Alpha IK Hand Left");
        /// <summary>
        /// AlphaIKHandRight.
        /// </summary>
        public static readonly int AlphaIKHandRight = Animator.StringToHash("Alpha IK Hand Right");
        
        /// <summary>
        /// Aiming Alpha Value.
        /// </summary>
        public static readonly int AimingAlpha = Animator.StringToHash("Aiming");

        /// <summary>
        /// Hashed "Movement".
        /// </summary>
        public static readonly int Movement = Animator.StringToHash("Movement");
        /// <summary>
        /// Hashed "Leaning".
        /// </summary>
        public static readonly int LeaningForward = Animator.StringToHash("Leaning Forward");
        
        /// <summary>
        /// Hashed "Aiming Speed Multiplier".
        /// </summary>
        public static readonly int AimingSpeedMultiplier = Animator.StringToHash("Aiming Speed Multiplier");
        /// <summary>
        /// Hashed "Turning".
        /// </summary>
        public static readonly int Turning = Animator.StringToHash("Turning");
        
        /// <summary>
        /// Hashed "Horizontal".
        /// </summary>
        public static readonly int Horizontal = Animator.StringToHash("Horizontal");
        /// <summary>
        /// Hashed "Vertical".
        /// </summary>
        public static readonly int Vertical = Animator.StringToHash("Vertical");
        
        /// <summary>
        /// Hashed "Play Rate Locomotion Forward".
        /// </summary>
        public static readonly int PlayRateLocomotionForward = Animator.StringToHash("Play Rate Locomotion Forward");
        /// <summary>
        /// Hashed "Play Rate Locomotion Sideways".
        /// </summary>
        public static readonly int PlayRateLocomotionSideways = Animator.StringToHash("Play Rate Locomotion Sideways");
        /// <summary>
        /// Hashed "Play Rate Locomotion Backwards".
        /// </summary>
        public static readonly int PlayRateLocomotionBackwards = Animator.StringToHash("Play Rate Locomotion Backwards");
    }
}