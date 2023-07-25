//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames
{
    /// <summary>
    /// ScriptableObject containing a location and rotation curve, along with settings to interpolate
    /// them using the Spring class.
    /// Very helpful for lots of procedural motions that use curves.
    /// </summary>
    [CreateAssetMenu(fileName = "SO_AC_Default", menuName = "Infima Games/Animation Curves")]
    public class ACurves : ScriptableObject
    {
        #region PROPERTIES
        
        /// <summary>
        /// LocationSpring.
        /// </summary>
        public SpringSettings LocationSpring => locationSpring;
        /// <summary>
        /// LocationCurves.
        /// </summary>
        public AnimationCurve[] LocationCurves => locationCurves;
        /// <summary>
        /// LocationMultiplier.
        /// </summary>
        public float LocationMultiplier => locationMultiplier;
        
        /// <summary>
        /// RotationSpring.
        /// </summary>
        public SpringSettings RotationSpring => rotationSpring;
        /// <summary>
        /// RotationCurves.
        /// </summary>
        public AnimationCurve[] RotationCurves => rotationCurves;
        /// <summary>
        /// RotationMultiplier.
        /// </summary>
        public float RotationMultiplier => rotationMultiplier;
        
        #endregion

        [Title(label: "Location Settings")]
        
        [Range(0.0f, 10.0f)]
        [Tooltip("Multiplier applied to the location curves.")]
        [SerializeField]
        private float locationMultiplier = 1.0f;
        
        [Tooltip("Interpolation settings for the location.")]
        [SerializeField]
        private SpringSettings locationSpring = SpringSettings.Default();

        [Tooltip("Animated location curves.")]
        [SerializeField]
        private AnimationCurve[] locationCurves;

        [Title(label: "Rotation Settings")]
        
        [Range(0.0f, 10.0f)]
        [Tooltip("Multiplier applied to the rotation curves.")]
        [SerializeField]
        private float rotationMultiplier = 1.0f;
        
        [Tooltip("Interpolation settings for the rotation.")]
        [SerializeField]
        private SpringSettings rotationSpring = SpringSettings.Default();

        [Tooltip("Animated rotation curves.")]
        [SerializeField]
        private AnimationCurve[] rotationCurves;
    }
}