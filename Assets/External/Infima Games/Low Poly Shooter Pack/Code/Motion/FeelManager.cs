//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// This class's main purpose is to hold the feel preset that is active
    /// in the game at any given time, and allow others to access it.
    /// </summary>
    public class FeelManager : MonoBehaviour
    {
        #region PROPERTIES
        
        /// <summary>
        /// Preset.
        /// </summary>
        public FeelPreset Preset
        {
            //Get.
            get => preset;
            //Set.
            set => preset = value;
        }
        
        #endregion
        
        #region FIELDS SERIALIZED
        
        [Tooltip("Feel Preset. This drives the feel of the entire " +
                 "project, both for weapons, and also for the camera. " +
                 "It is a very important object.")]
        [SerializeField]
        private FeelPreset preset;
        
        #endregion
    }
}