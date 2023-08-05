//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// RecoilMotion. Produces procedural recoil motions and applies it!
    /// </summary>
    public class RecoilMotion : Motion
    {
        #region FIELDS SERIALIZED
        
        [Tooltip("The character's InventoryBehaviour component.")]
        [SerializeField, NotNull]
        private InventoryBehaviour inventoryBehaviour;
        
        [Tooltip("The character's CharacterBehaviour component.")]
        [SerializeField, NotNull]
        private CharacterBehaviour characterBehaviour;
        
        [Title(label: "Settings")]

        [Tooltip("The type of motion we want this component to apply.")]
        [SerializeField]
        private MotionType motionType;
        
        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// Recoil Spring Location. Used to apply location recoil to the camera.
        /// We don't really use this one as much as the rotation one, since applying location changes to the
        /// camera feels quite bad.
        /// </summary>
        private readonly Spring recoilSpringLocation = new Spring();
        /// <summary>
        /// Recoil Spring Rotation. Used to apply rotation recoil to the camera.
        /// </summary>
        private readonly Spring recoilSpringRotation = new Spring();

        /// <summary>
        /// Current Recoil Curves. We apply these, so it is important that they are up to date.
        /// </summary>
        private ACurves recoilCurves;
        
        #endregion
        
        #region METHODS

        /// <summary>
        /// Tick.
        /// </summary>
        public override void Tick()
        {
            //Check for reference errors.
            if (inventoryBehaviour == null || characterBehaviour == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);
                
                //Return.
                return;
            }

            //Try to get a ItemAnimationDataBehaviour from the equipped weapon.
            var animationDataBehaviour = inventoryBehaviour.GetEquipped().GetComponent<ItemAnimationDataBehaviour>();
            //If there's none, then we don't even need to run this script at all, basically.
            if (animationDataBehaviour == null)
                return;

            //Grab the RecoilData value we need.
            RecoilData recoilData = animationDataBehaviour.GetRecoilData(motionType);
            //If there's no RecoilData assigned, then there's no reason to bother with this either, nothing will work.
            if (recoilData == null)
                return;
            
            //Get shotsFired.
            int shotsFired = characterBehaviour.GetShotsFired();
            //Get the recoilDataMultiplier value from the actual recoilData object.
            float recoilDataMultiplier = recoilData.StandingStateMultiplier;
            
            //Recoil Location.
            Vector3 recoilLocation = default;
            //Recoil Rotation.
            Vector3 recoilRotation = default;
            
            //Get recoil curves.
            recoilCurves = recoilData.StandingState;
            //Check if we're aiming.
            if (characterBehaviour.IsAiming())
            {
                //Use the aiming recoil multiplier.
                recoilDataMultiplier = recoilData.AimingStateMultiplier;
                //Update the curves we use to be the aiming ones.
                recoilCurves = recoilData.AimingState;
            }
            
            #region WIP
            
            //We need to have returnRecoilPitch. This is a value that gets set to currentRecoilPitch when we stop firing.
            //So, we also need to know when we've stopped firing.
            
            //We need to have a currentRecoilPitch.
            //Everytime we rotate the camera, which happens in Character[OnLook], we need to store the current recoil rotation.
            //We can probably just call a function from there to here, or directly subscribe somehow...etc

            //This entire thing is only done for the camera.
            //TODO: Unsure how we're putting this together?
            // if (shotsFired > 0)
            // {
            //     if (returnRecoilPitch > 0.0f)
            //         ResetRecoil();
            //     else
            //     {
            //         //Interpolate.
            //     }
            // }
            // else
            // {
            //     if (returnRecoilPitch > 0.0f)
            //     {
            //         //Interpolate to returnRecoilPitch.
            //         ResetRecoil();
            //     }
            //     else
            //     {
            //         //Interpolate to zero.
            //     }
            // }
            
            #endregion
            
            //We really need a recoil object to calculate recoil. If we don't have one, we'll just completely ignore
            //doing any recoil, because there's no point.
            if (recoilCurves != null)
            {
                //We need three curves for things to work properly.
                if (recoilCurves.LocationCurves.Length == 3)
                {
                    /*
                    * Calculate the final recoil location by evaluating the recoil curve at the correct time.
                    * The correct time in this case is always the amount of shots that we have just fired, so the recoil
                    * curves are built to be based on specific ammo counts. Just something to take into account.
                   */
                    recoilLocation.x = recoilCurves.LocationCurves[0].Evaluate(shotsFired);
                    recoilLocation.y = recoilCurves.LocationCurves[1].Evaluate(shotsFired);
                    recoilLocation.z = recoilCurves.LocationCurves[2].Evaluate(shotsFired);
                }
            
                //We need three curves for things to work properly.
                if(recoilCurves.RotationCurves.Length == 3)
                {
                    //Calculate the final recoil rotation by evaluating the recoil curve at the correct time.
                    recoilRotation.x = recoilCurves.RotationCurves[0].Evaluate(shotsFired);
                    recoilRotation.y = recoilCurves.RotationCurves[1].Evaluate(shotsFired);
                    recoilRotation.z = recoilCurves.RotationCurves[2].Evaluate(shotsFired);
                }
            
                //Add Multipliers.
                recoilLocation *= recoilCurves.LocationMultiplier * recoilDataMultiplier;
                //Add Multipliers.
                recoilRotation *= recoilCurves.RotationMultiplier * recoilDataMultiplier;
            }
            
            //Update the location recoil values.
            //We do this after the null check because we want to make sure the recoil stops smoothly (spring-ly?) even
            //if we suddenly don't have a recoil object anymore.
            recoilSpringLocation.UpdateEndValue(recoilLocation);  
            //Update the rotational recoil values.
            recoilSpringRotation.UpdateEndValue(recoilRotation);
        }
        
        #endregion
        
        #region FUNCTIONS

        /// <summary>
        /// GetLocation.
        /// </summary>
        public override Vector3 GetLocation()
        {
            //Check Reference.
            if (recoilCurves == null)
                return default;
            
            //Return.
            return recoilSpringLocation.Evaluate(recoilCurves.LocationSpring);
        }
        /// <summary>
        /// GetEulerAngles.
        /// </summary>
        public override Vector3 GetEulerAngles()
        {           
            //Check Reference.
            if (recoilCurves == null)
                return default;
            
            //Return.
            return recoilSpringRotation.Evaluate(recoilCurves.RotationSpring);
        }
        
        #endregion
    }
}