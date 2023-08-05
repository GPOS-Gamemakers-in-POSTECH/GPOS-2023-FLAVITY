// Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// FeelPreset. Holds all the Feel objects needed to create an overall feel for the game.
    /// </summary>
    [CreateAssetMenu(fileName = "SO_Feel_Preset", menuName = "Infima Games/Low Poly Shooter Pack/Feel Preset", order = 0)]
    public class FeelPreset : ScriptableObject
    {
        #region FIELDS SERIALIZED
        
        [Title(label: "Camera Feel")]
        
        [Tooltip("Camera Feel. Holds the values relating to how the camera feels when playing.")]
        [SerializeField, InLineEditor]
        private Feel cameraFeel;

        [Title(label: "Item Feel")]
        
        [Tooltip("Item Feel. Holds the values relating to how the items feels when playing.")]
        [SerializeField, InLineEditor]
        private Feel itemFeel;
        
        #endregion
        
        #region FUNCTIONS

        /// <summary>
        /// GetFeel. Returns the correct feel based on parameters.
        /// </summary>
        public Feel GetFeel(MotionType motionType)
        {
            //Switch.
            return motionType switch
            {
                //MotionType.Camera.
                MotionType.Camera => cameraFeel,
                //MotionType.Item.
                MotionType.Item => itemFeel,
            };
        }
        
        #endregion
    }
}