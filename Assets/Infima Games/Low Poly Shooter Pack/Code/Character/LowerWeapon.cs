//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// LowerWeapon. This component handles lowering the character's weapon when the player wants to, or
    /// in specific situations where it is needed.
    /// </summary>
    public class LowerWeapon : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Title(label: "References")]
        
        [Tooltip("The character's Animator component.")]
        [SerializeField, NotNull]
        private Animator characterAnimator;
        
        [Tooltip("A WallAvoidance component is required so we can check if the character is facing a wall " +
                 "and lower the weapon automatically. If there's no such component assigned, this will never " +
                 "happen.")]
        [SerializeField]
        private WallAvoidance wallAvoidance;
        
        [Tooltip("The character's InventoryBehaviour component.")]
        [SerializeField, NotNull]
        private InventoryBehaviour inventoryBehaviour;

        [Tooltip("The character's CharacterBehaviour component.")]
        [SerializeField, NotNull]
        private CharacterBehaviour characterBehaviour;

        [Title(label: "Settings")]

        [Tooltip("If true, the lowered state is stopped when the character starts firing.")]
        [SerializeField]
        private bool stopWhileFiring = true;
        
        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// If true, the character has their weapon lowered, and in a state where there's not many actions that
        /// can be performed.
        /// </summary>
        private bool lowered;
        /// <summary>
        /// This becomes true when the player asks for the weapon to be lowered, but may not directly make the weapon
        /// lowered depending on other states that are active.
        /// </summary>
        private bool loweredPressed;
        
        #endregion
        
        #region UNITY

        /// <summary>
        /// Update.
        /// </summary>
        private void Update()
        {
            //Check References.
            if (characterAnimator == null || characterBehaviour == null || inventoryBehaviour == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);
                
                //Return.
                return;
            }

            //Update the lowered variable.
            lowered = (loweredPressed || wallAvoidance != null && wallAvoidance.HasWall) && !characterBehaviour.IsAiming() && !characterBehaviour.IsRunning()
                      && !characterBehaviour.IsInspecting() && !characterBehaviour.IsHolstered();

            //Stop the lowered state while firing if necessary.
            //We use this by default, but it could be useful to not have it if your lowered poses are different.
            if (stopWhileFiring && characterBehaviour.IsHoldingButtonFire())
                lowered = false;
            
            //Make sure that the equipped weapon has a ItemAnimationDataBehaviour.
            var animationData = inventoryBehaviour.GetEquipped().GetComponent<ItemAnimationDataBehaviour>();
            if (animationData == null)
                lowered = false;
            else
            {
                //Check that the current weapon equipped has the necessary data for lowering.
                if (animationData.GetLowerData() == null)
                    lowered = false;
            }
            
            //Update Animator Lowered.
            characterAnimator.SetBool(AHashes.Lowered, lowered);
        }

        #endregion
        
        #region GETTERS
        
        /// <summary>
        /// This function returns true if the character's weapon is lowered, and in a state where the character
        /// cannot do as many things.
        /// </summary>
        /// <returns></returns>
        public bool IsLowered() => lowered;
        
        #endregion
        
        #region METHODS

        /// <summary>
        /// Lower. Called to try and lower the character's equipped weapon!
        /// Keep in mind that this method is called by the PlayerInput component on the main character root.
        /// </summary>
        public void Lower(InputAction.CallbackContext context)
        {
            //Block while the cursor is unlocked.
            if (!characterBehaviour.IsCursorLocked())
                return;

            //No changing the lowered state while doing these, since you can't see it.
            if (characterBehaviour.IsAiming() || characterBehaviour.IsInspecting() || 
                characterBehaviour.IsRunning() || characterBehaviour.IsHolstered())
                return;
			
            //Switch.
            switch (context)
            {
                //Performed.
                case {phase: InputActionPhase.Performed}:
                    //Toggle Lowered.
                    loweredPressed = !loweredPressed;
                    break;
            }
        }
        
        #endregion
    }
}