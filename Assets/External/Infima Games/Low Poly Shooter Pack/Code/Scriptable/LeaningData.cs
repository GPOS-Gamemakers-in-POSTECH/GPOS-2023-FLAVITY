//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// LeaningData. Contains all data related to the player character leaning, and having the camera and equipped item
    /// act on it too.
    /// </summary>
    [CreateAssetMenu(fileName = "SO_Leaning_Name", menuName = "Infima Games/Low Poly Shooter Pack/Leaning Data", order = 0)]
    public class LeaningData : ScriptableObject
    {
        #region FIELDS SERIALIZED
        
        [Title(label: "Item Curves")]
        
        [Tooltip("Animation curves played on the item when leaning while the character is aiming.")]
        [SerializeField, InLineEditor]
        private ACurves itemAiming;
        
        [Tooltip("Animation curves played on the item when leaning while the character is standing.")]
        [SerializeField, InLineEditor]
        private ACurves itemStanding;

        [Title(label: "Camera Curves")]
        
        [Tooltip("Animation curves played on the camera when leaning while the character is aiming.")]
        [SerializeField, InLineEditor]
        
        private ACurves cameraAiming;
        [Tooltip("Animation curves played on the camera when leaning while the character is standing.")]
        [SerializeField, InLineEditor]
        private ACurves cameraStanding;
        
        #endregion
        
        #region FUNCTIONS

        /// <summary>
        /// Returns the curves for the requested MotionType.
        /// </summary>
        public ACurves GetCurves(MotionType motionType, bool aiming = false)
        {
            //Switch.
            return motionType switch
            {
                //MotionType.Camera.
                MotionType.Camera => aiming ? cameraAiming : cameraStanding,
                //MotionType.Item.
                MotionType.Item => aiming ? itemAiming : itemStanding,
                //Default.
                _ => itemStanding
            };
        }
        
        #endregion
    }
}