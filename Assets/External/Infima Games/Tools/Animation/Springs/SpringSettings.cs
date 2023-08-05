//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames
{
    /// <summary>
    /// This little struct is used to define forces that are applied to the Spring class
    /// for more than one frame.
    /// </summary>
    [Serializable]
    public struct HeldForce
    {
        #region PROPERTIES
        
        /// <summary>
        /// Force.
        /// </summary>
        public Vector3 Force => force;
        /// <summary>
        /// Frames.
        /// </summary>
        public int Frames => frames;

        #endregion
        
        #region FIELDS SERIALIZED
        
        [Tooltip("Force applied over frames.")]
        [SerializeField]
        private Vector3 force;

        [Tooltip("Frames to apply the force over.")]
        [SerializeField]
        private int frames;
        
        #endregion
    }

    /// <summary>
    /// Defines all the settings necessary for a Spring to function correctly. It can be passed directly
    /// to the Spring to use all the data when calling Evaluate.
    /// </summary>
    [Serializable]
    public struct SpringSettings
    {
        [Title(label: "Spring")]
        
        [BeginHorizontal(labelToWidthRatio: 0.15f)]
        [Tooltip("Determines how springy the spring is, the lower this value, the more bounce you will see.")]
        [Range(0.0f, 100.0f)]
        public float damping;
        
        [EndHorizontal]
        [Tooltip("Determines how stiff the interpolation looks. The lower the value, the stiffer it becomes.")]
        [Range(0.0f, 200.0f)]
        public float stiffness;
        
        [Title(label: "Modifiers")]

        [BeginHorizontal(labelToWidthRatio: 0.15f)]
        [Tooltip("Determines how heavy the interpolation looks.")]
        [Range(0.0f, 100.0f)]
        public float mass;

        [EndHorizontal]
        [Tooltip("Determines the speed of the interpolation. The higher the value, the faster the speed.")]
        [Range(1.0f, 10.0f)]
        public float speed;

        /// <summary>
        /// Default values for spring settings. If we don't have this, there's no other way that I know of that
        /// allows us to still assign default values to this, which we definitely need, since they're not precisely
        /// easy to guess.
        /// </summary>
        public static SpringSettings Default()
        {
            //Return.
            return new SpringSettings()
            {
                damping = 15.0f,
                mass = 1.0f,
                stiffness = 150.0f,
                speed = 1.0f
            };
        }
    }
}