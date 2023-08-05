//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// SwayDirection.
    /// </summary>
    [Serializable]
    public struct SwayDirection
    {
        [Title(label: "Location Settings")]
        
        [Range(0.0f, 10.0f)]
        [Tooltip("Multiplier applied to the location curves.")]
        [SerializeField]
        public float locationMultiplier;

        [Tooltip("Animated location curves.")]
        [SerializeField]
        public AnimationCurve[] locationCurves;

        [Title(label: "Rotation Settings")]
        
        [Range(0.0f, 10.0f)]
        [Tooltip("Multiplier applied to the rotation curves.")]
        [SerializeField]
        public float rotationMultiplier;

        [Tooltip("Animated rotation curves.")]
        [SerializeField]
        public AnimationCurve[] rotationCurves;
    }
}