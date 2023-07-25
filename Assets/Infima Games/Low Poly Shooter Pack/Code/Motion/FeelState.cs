//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// FeelState. Contains information on different things that happen in a single state.
    /// </summary>
    [Serializable]
    public struct FeelState
    {
        #region PROPERTIES

        /// <summary>
        /// Offset.
        /// </summary>
        public FeelStateOffset Offset => offset;
        /// <summary>
        /// SwayData.
        /// </summary>
        public SwayData SwayData => swayData;

        /// <summary>
        /// JumpingCurves.
        /// </summary>
        public ACurves JumpingCurves => jumpingCurves;
        /// <summary>
        /// FallingCurves.
        /// </summary>
        public ACurves FallingCurves => fallingCurves;
        /// <summary>
        /// LandingCurves.
        /// </summary>
        public ACurves LandingCurves => landingCurves;
        
        #endregion
        
        #region FIELDS SERIALIZED
        
        [Title(label: "Offset")]
        
        [Tooltip("Offset.")]
        [SerializeField, InLineEditor]
        public FeelStateOffset offset;
        
        [Title(label: "Sway Data")]
        
        [Tooltip("Settings relating to sway.")]
        [SerializeField, InLineEditor]
        public SwayData swayData;
        
        [Title(label: "Jumping Curves")]

        [Tooltip("Animation curves played when the character jumps.")]
        [SerializeField, InLineEditor]
        public ACurves jumpingCurves;
        
        [Title(label: "Falling Curves")]
        
        [Tooltip("Animation curves played when the character falls.")]
        [SerializeField, InLineEditor]
        public ACurves fallingCurves;
        
        [Title(label: "Landing Curves")]

        [Tooltip("Animation curves played when the character lands.")]
        [SerializeField, InLineEditor]
        public ACurves landingCurves;
        
        #endregion
    }
}