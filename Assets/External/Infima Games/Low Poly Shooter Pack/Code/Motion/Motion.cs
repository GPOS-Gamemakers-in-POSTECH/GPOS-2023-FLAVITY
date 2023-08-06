//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// MotionType.
    /// </summary>
    public enum MotionType { Camera, Item }
    
    /// <summary>
    /// Motion. This abstract class serves as a base class for all components that apply any sort of cool procedural
    /// motions to either the weapons, or the camera, in the asset.
    /// It has a bunch of helper things that make it easier to handle, and runs through the MotionApplier, forming
    /// a nice cycle! 
    /// </summary>
    [RequireComponent(typeof(MotionApplier))]
    public abstract class Motion : MonoBehaviour
    {
        #region PROPERTIES
        
        /// <summary>
        /// Alpha.
        /// </summary>
        public float Alpha => alpha;
        
        #endregion
        
        #region FIELDS SERIALIZED
        
        [Title(label: "Motion")]
        
        [Tooltip("The Motion's alpha. Used to more easily control how much of the motion is applied.")]
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float alpha = 1.0f;

        [Title(label: "References")]
        
        [Tooltip("The MotionApplier that will apply this Motion's values.")]
        [SerializeField, NotNull]
        protected MotionApplier motionApplier;
        
        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Awake.
        /// </summary>
        protected virtual void Awake()
        {
            //Try to get the applier if we haven't assigned it.
            if (motionApplier == null)
                motionApplier = GetComponent<MotionApplier>();
            
            //Subscribe.
            if(motionApplier != null)
                motionApplier.Subscribe(this);
        }

        /// <summary>
        /// Tick.
        /// </summary>
        public abstract void Tick();
        
        #endregion
        
        #region FUNCTIONS
        
        /// <summary>
        /// GetLocation.
        /// </summary>
        public abstract Vector3 GetLocation();
        /// <summary>
        /// GetEulerAngles.
        /// </summary>
        public abstract Vector3 GetEulerAngles();
        
        #endregion
    }
}