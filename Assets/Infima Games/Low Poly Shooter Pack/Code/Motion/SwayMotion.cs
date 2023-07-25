//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// SwayMotion. This component produces all the sway motions!
    /// </summary>
    public class SwayMotion : Motion
    {
        #region FIELDS SERIALIZED
        
        [Tooltip("The character's FeelManager component.")]
        [SerializeField, NotNull]
        private FeelManager feelManager;
        
        [Tooltip("The character's Animator component.")]
        [SerializeField, NotNull]
        private Animator characterAnimator;
        
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
        /// springLocation.
        /// </summary>
        private readonly Spring springLocation = new Spring();
        /// <summary>
        /// springRotation.
        /// </summary>
        private readonly Spring springRotation = new Spring();

        /// <summary>
        /// FeelState.
        /// </summary>
        private FeelState feelState;

        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Tick.
        /// </summary>
        public override void Tick()
        {
            //Check for reference errors.
            if (feelManager == null || characterBehaviour == null || inventoryBehaviour == null ||
                characterAnimator == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);
                
                //Return.
                return;
            }
            
            //Get the looking input.
            Vector2 inputLook = Vector2.ClampMagnitude(characterBehaviour.GetInputLook(), 1);
            //Get the movement input.
            Vector2 movement = Vector2.ClampMagnitude(characterBehaviour.GetInputMovement(), 1);

            //Get FeelPreset.
            FeelPreset feelPreset = feelManager.Preset;
            if (feelPreset == null)
                return;
            
            //Get Feel.
            Feel feel = feelPreset.GetFeel(motionType);
            if (feel == null)
                return;
            
            //Get the current FeelState value.
            feelState = feel.GetState(characterAnimator);

            //Grab ScopeBehaviour.
            ScopeBehaviour scopeBehaviour = inventoryBehaviour.GetEquipped().GetAttachmentManager().GetEquippedScope();

            //SwayData.
            SwayData swayData = feelState.SwayData;
            if (swayData == null)
                return;
            
            //Represents the sway applied for horizontal values.
            Vector3 horizontalLocation = default;
            //Look Sway.
            horizontalLocation += swayData.Look.Horizontal.locationCurves.EvaluateCurves(inputLook.x) * 
                              swayData.Look.Horizontal.locationMultiplier;
            //Movement Sway.
            horizontalLocation += swayData.Movement.Horizontal.locationCurves.EvaluateCurves(movement.x) *
                              swayData.Movement.Horizontal.locationMultiplier;

            //Represents the sway applied for vertical values.
            Vector3 verticalLocation = default;
            //Look Sway.
            verticalLocation += swayData.Look.Vertical.locationCurves.EvaluateCurves(inputLook.y) * 
                            swayData.Look.Vertical.locationMultiplier;
            //Movement Sway.
            verticalLocation += swayData.Movement.Vertical.locationCurves.EvaluateCurves(movement.y) * 
                            swayData.Movement.Vertical.locationMultiplier;

            //Represents the sway applied for horizontal values.
            Vector3 horizontalRotation = default;
            //Look Sway.
            horizontalRotation += swayData.Look.Horizontal.rotationCurves.EvaluateCurves(inputLook.x) * 
                                  swayData.Look.Horizontal.rotationMultiplier;
            //Movement Sway.
            horizontalRotation += swayData.Movement.Horizontal.rotationCurves.EvaluateCurves(movement.x) *
                                  swayData.Movement.Horizontal.rotationMultiplier;

            //Represents the sway applied for vertical values.
            Vector3 verticalRotation = default;
            //Look Sway.
            verticalRotation += swayData.Look.Vertical.rotationCurves.EvaluateCurves(inputLook.y) * 
                                swayData.Look.Vertical.rotationMultiplier;
            //Movement Sway.
            verticalRotation += swayData.Movement.Vertical.rotationCurves.EvaluateCurves(movement.y) * 
                                swayData.Movement.Vertical.rotationMultiplier;
            
            //Update Location Value.
            springLocation.UpdateEndValue(scopeBehaviour.GetSwayMultiplier() * (horizontalLocation + verticalLocation));
            //Update Rotation Value.
            springRotation.UpdateEndValue(scopeBehaviour.GetSwayMultiplier() * (horizontalRotation + verticalRotation));
        }

        #endregion
        
        #region FUNCTIONS
        
        /// <summary>
        /// GetLocation.
        /// </summary>
        public override Vector3 GetLocation()
        {
            //Check References.
            if (feelState.SwayData == null)
                return default;
            
            //Return.
            return springLocation.Evaluate(feelState.SwayData.SpringSettings);
        }
        /// <summary>
        /// GetEulerAngles.
        /// </summary>
        public override Vector3 GetEulerAngles()
        {
            //Check References.
            if (feelState.SwayData == null)
                return default;
            
            //Return.
            return springRotation.Evaluate(feelState.SwayData.SpringSettings);
        }
        
        #endregion
    }
}