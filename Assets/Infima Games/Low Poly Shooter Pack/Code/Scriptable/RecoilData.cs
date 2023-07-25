//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Recoil Data. Used when playing recoil motions to have all the needed information
    /// for that.
    /// </summary>
    [CreateAssetMenu(fileName = "SO_Recoil", menuName = "Infima Games/Low Poly Shooter Pack/Recoil Data", order = 0)]
    public class RecoilData : ScriptableObject
    {
        #region PROPERTIES

        /// <summary>
        /// StandingStateMultiplier.
        /// </summary>
        public float StandingStateMultiplier => standingStateMultiplier;
        /// <summary>
        /// Standing Curves.
        /// </summary>
        public ACurves StandingState => standingState;
        
        /// <summary>
        /// AimingStateMultiplier.
        /// </summary>
        public float AimingStateMultiplier => aimingStateMultiplier;
        /// <summary>
        /// Aiming Curves.
        /// </summary>
        public ACurves AimingState => aimingState;
        
        #endregion
        
        #region FIELDS SERIALIZED

        [Title(label: "Standing State")]
        
        [Tooltip("Value to multiply the standingState location/rotation values by.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float standingStateMultiplier = 1.0f;

        [Tooltip("Standing State.")]
        [SerializeField, InLineEditor]
        private ACurves standingState;

        [Title(label: "Aiming State")]

        [Tooltip("Value to multiply the aimingState location/rotation values by.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float aimingStateMultiplier = 1.0f;
        
        [Tooltip("Aiming State.")]
        [SerializeField, InLineEditor]
        private ACurves aimingState;
        
        #endregion
    }
}