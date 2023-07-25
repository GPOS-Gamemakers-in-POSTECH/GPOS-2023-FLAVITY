//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Weapon Offsets.
    /// </summary>
    [Serializable]
    public struct Offsets
    {
        /// <summary>
        /// Standing Location.
        /// </summary>
        public Vector3 StandingLocation => standingLocation;
        /// <summary>
        /// Standing Rotation.
        /// </summary>
        public Vector3 StandingRotation => standingRotation;
        
        /// <summary>
        /// Aiming Location.
        /// </summary>
        public Vector3 AimingLocation => aimingLocation;
        /// <summary>
        /// Aiming Rotation.
        /// </summary>
        public Vector3 AimingRotation => aimingRotation;
        
        /// <summary>
        /// Running Location.
        /// </summary>
        public Vector3 RunningLocation => runningLocation;
        /// <summary>
        /// Running Rotation.
        /// </summary>
        public Vector3 RunningRotation => runningRotation;
        
        /// <summary>
        /// Crouching Location.
        /// </summary>
        public Vector3 CrouchingLocation => crouchingLocation;
        /// <summary>
        /// Crouching Rotation.
        /// </summary>
        public Vector3 CrouchingRotation => crouchingRotation;
        
        /// <summary>
        /// Action Location.
        /// </summary>
        public Vector3 ActionLocation => actionLocation;
        /// <summary>
        /// Action Rotation.
        /// </summary>
        public Vector3 ActionRotation => actionRotation;
        
        [Header("Standing Offset")]
        
        [Tooltip("Weapon bone location offset while standing.")]
        [SerializeField]
        private Vector3 standingLocation;
        
        [Tooltip("Weapon bone rotation offset while standing.")]
        [SerializeField]
        private Vector3 standingRotation;

        [Header("Aiming Offset")]
        
        [Tooltip("Weapon bone location offset while aiming.")]
        [SerializeField]
        private Vector3 aimingLocation;
        
        [Tooltip("Weapon bone rotation offset while aiming.")]
        [SerializeField]
        private Vector3 aimingRotation;
        
        [Header("Running Offset")]
        
        [Tooltip("Weapon bone location offset while running.")]
        [SerializeField]
        private Vector3 runningLocation;
        
        [Tooltip("Weapon bone rotation offset while running.")]
        [SerializeField]
        private Vector3 runningRotation;
        
        [Header("Crouching Offset")]
        
        [Tooltip("Weapon bone location offset while crouching.")]
        [SerializeField]
        private Vector3 crouchingLocation;
        
        [Tooltip("Weapon bone rotation offset while crouching.")]
        [SerializeField]
        private Vector3 crouchingRotation;
        
        [Header("Action Offset")]
        
        [Tooltip("Weapon bone location offset while performing an action (grenade, melee).")]
        [SerializeField]
        private Vector3 actionLocation;
        
        [Tooltip("Weapon bone rotation offset while performing an action (grenade, melee).")]
        [SerializeField]
        private Vector3 actionRotation;
    }
}