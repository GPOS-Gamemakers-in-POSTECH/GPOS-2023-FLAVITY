//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// ItemOffsets. Contains data on how an item should be offset in different states.
    /// </summary>
    [CreateAssetMenu(fileName = "SO_IO_Default", menuName = "Infima Games/Low Poly Shooter Pack/Item Offsets", order = 0)]
    public class ItemOffsets : ScriptableObject
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
        
        [Title(label: "Standing Offset")]
        
        [Tooltip("Weapon bone location offset while standing.")]
        [SerializeField]
        private Vector3 standingLocation;
        
        [Tooltip("Weapon bone rotation offset while standing.")]
        [SerializeField]
        private Vector3 standingRotation;

        [Title(label: "Aiming Offset")]
        
        [Tooltip("Weapon bone location offset while aiming.")]
        [SerializeField]
        private Vector3 aimingLocation;
        
        [Tooltip("Weapon bone rotation offset while aiming.")]
        [SerializeField]
        private Vector3 aimingRotation;
        
        [Title(label: "Running Offset")]
        
        [Tooltip("Weapon bone location offset while running.")]
        [SerializeField]
        private Vector3 runningLocation;
        
        [Tooltip("Weapon bone rotation offset while running.")]
        [SerializeField]
        private Vector3 runningRotation;
        
        [Title(label: "Crouching Offset")]
        
        [Tooltip("Weapon bone location offset while crouching.")]
        [SerializeField]
        private Vector3 crouchingLocation;
        
        [Tooltip("Weapon bone rotation offset while crouching.")]
        [SerializeField]
        private Vector3 crouchingRotation;
        
        [Title(label: "Action Offset")]
        
        [Tooltip("Weapon bone location offset while performing an action (grenade, melee).")]
        [SerializeField]
        private Vector3 actionLocation;
        
        [Tooltip("Weapon bone rotation offset while performing an action (grenade, melee).")]
        [SerializeField]
        private Vector3 actionRotation;
    }
}