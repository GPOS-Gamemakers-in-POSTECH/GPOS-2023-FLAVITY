//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// ItemAnimationData. Stores all information related to the weapon-specific procedural data.
    /// </summary>
    public class ItemAnimationData : ItemAnimationDataBehaviour
    {
        #region FIELDS SERIALIZED

        [Title(label: "Item Offsets")]

        [Tooltip("The object that contains all offset data for this item.")]
        [SerializeField, InLineEditor]
        private ItemOffsets itemOffsets;
        
        [Title(label: "Lowered Data")]

        [Tooltip("This object contains all the data needed for us to set the lowered pose of this weapon.")]
        [SerializeField, InLineEditor]
        private LowerData lowerData;

        [Title(label: "Leaning Data")]

        [Tooltip("LeaningData. Contains all the information on what this weapon should do while the character is leaning.")]
        [SerializeField, InLineEditor]
        private LeaningData leaningData;
        
        [Title(label: "Camera Recoil Data")]

        [Tooltip("Weapon Recoil Data Asset. Used to get some camera recoil values, usually for weapons.")]
        [SerializeField, InLineEditor]
        private RecoilData cameraRecoilData;
        
        [Title(label: "Weapon Recoil Data")]

        [Tooltip("Weapon Recoil Data Asset. Used to get some recoil values, usually for weapons.")]
        [SerializeField, InLineEditor]
        private RecoilData weaponRecoilData;

        #endregion
        
        #region GETTERS

        /// <summary>
        /// GetCameraRecoilData.
        /// </summary>
        public override RecoilData GetCameraRecoilData() => cameraRecoilData;
        /// <summary>
        /// GetWeaponRecoilData.
        /// </summary>
        public override RecoilData GetWeaponRecoilData() => weaponRecoilData;

        /// <summary>
        /// GetRecoilData.
        /// </summary>
        public override RecoilData GetRecoilData(MotionType motionType) =>
            motionType == MotionType.Item ? GetWeaponRecoilData() : GetCameraRecoilData();

        /// <summary>
        /// GetLowerData.
        /// </summary>
        public override LowerData GetLowerData() => lowerData;
        /// <summary>
        /// GetLeaningData.
        /// </summary>
        public override LeaningData GetLeaningData() => leaningData;
        
        /// <summary>
        /// GetItemOffsets.
        /// </summary>
        public override ItemOffsets GetItemOffsets() => itemOffsets;

        #endregion
    }   
}