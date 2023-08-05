//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using System.Collections.Generic;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// ApplyMode. Determines how a MotionApplier should apply the values from the Motions that are subscribed to it.
    /// </summary>
    public enum ApplyMode { Override, Add }
    
    /// <summary>
    /// MotionApplier. Applies all location, rotation values from Motion components subscribed to it in accordance with the
    /// settings of this component.
    /// </summary>
    public class MotionApplier : MonoBehaviour
    {
        #region FIELDS SERIALIZED
        
        [Title(label: "Settings")]

        [Tooltip("Determines the way this component applies the values for all subscribed Motion components.")]
        [SerializeField]
        private ApplyMode applyMode;
        
        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// Subscribed Motions.
        /// </summary>
        private readonly List<Motion> motions = new List<Motion>();

        /// <summary>
        /// This Transform.
        /// </summary>
        private Transform thisTransform;

        #endregion
        
        #region METHODS

        /// <summary>
        /// Awake.
        /// </summary>
        private void Awake()
        {
            //Cache.
            thisTransform = transform;
        }
        /// <summary>
        /// LateUpdate.
        /// </summary>
        private void LateUpdate()
        {
            //Final Location.
            Vector3 finalLocation = default;
            //Final Euler Angles.
            Vector3 finaEulerAngles = default;
            
            //ForEach Motion.
            motions.ForEach((motion =>
            {
                //Tick.
                motion.Tick();
                
                //Add Location.
                finalLocation += motion.GetLocation() * motion.Alpha;
                //Add Rotation.
                finaEulerAngles += motion.GetEulerAngles() * motion.Alpha;
            }));

            //Override Mode.
            if(applyMode == ApplyMode.Override)
            {
                //Set Location.
                thisTransform.localPosition = finalLocation;
                //Set Euler Angles.
                thisTransform.localEulerAngles = finaEulerAngles;
            }
            //Add Mode.
            else if (applyMode == ApplyMode.Add)
            {
                //Add Location.
                thisTransform.localPosition += finalLocation;
                //Add Euler Angles.
                thisTransform.localEulerAngles += finaEulerAngles;
            }
        }
        
        /// <summary>
        /// Subscribe a Motion to this MotionApplier. This means that the Motion's results every frame will be computed,
        /// and applied, by this MotionApplier.
        /// </summary>
        public void Subscribe(Motion motion) => motions.Add(motion);
        
        #endregion
    }
}