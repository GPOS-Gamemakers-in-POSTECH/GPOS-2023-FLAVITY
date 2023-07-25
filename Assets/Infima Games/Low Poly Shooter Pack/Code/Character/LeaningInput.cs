//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEngine.InputSystem;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// LeaningInput. This script handles all leaning input, and makes sure to let the character's animator know about it.
    /// </summary>
    public class LeaningInput : MonoBehaviour
    {
        #region FIELDS SERIALIZED
        
        [Title(label: "References")]
        
        [Tooltip("The character's CharacterBehaviour component.")]
        [SerializeField, NotNull]
        private CharacterBehaviour characterBehaviour;
        
        [Tooltip("The character's Animator component.")]
        [SerializeField, NotNull]
        private Animator characterAnimator;

        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// Current Leaning Value.
        /// </summary>
        private float leaningInput;
        /// <summary>
        /// True If Leaning.
        /// </summary>
        private bool isLeaning;

        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Update.
        /// </summary>
        private void Update()
        {
            //Update isLeaning.
            isLeaning = (leaningInput != 0.0f);
            
            //Update AHashes.LeaningInput Float.
            characterAnimator.SetFloat(AHashes.LeaningInput, leaningInput);
            //Update AHashes.Leaning Bool.
            characterAnimator.SetBool(AHashes.Leaning, isLeaning);
        }

        /// <summary>
        /// Lean.
        /// </summary>
        public void Lean(InputAction.CallbackContext context)
        {
            //Block while the cursor is unlocked.
            if (!characterBehaviour.IsCursorLocked())
            {
                //Zero out the leaning.
                leaningInput = 0.0f;
                
                //Return.
                return;
            }

            //ReadValue.
            leaningInput = context.ReadValue<float>();
        }
        
        #endregion
    }
}