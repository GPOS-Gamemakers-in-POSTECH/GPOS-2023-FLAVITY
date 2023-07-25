// Copyright 2022, Infima Games. All Rights Reserved.

using TMPro;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Interaction Text.
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class TextInteraction : Element
    {
        #region FIELDS SERIALIZED

        [Title(label: "References")]

        [Tooltip("Text that gets modified when looking at something to pick up.")]
        [SerializeField]
        private TextMeshProUGUI textToModify;
        
        [Title(label: "Setup")]
        
        [Tooltip("Name of the boolean to set when changing state.")]
        [SerializeField]
        private string stateName = "Visible";
        
        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// Animator.
        /// </summary>
        private Animator animator;
        /// <summary>
        /// Interactor Behaviour.
        /// </summary>
        private InteractorBehaviour interactorBehaviour;
        
        #endregion
        
        #region UNITY
        
        /// <summary>
        /// Awake.
        /// </summary>
        protected override void Awake()
        {
            //Base.
            base.Awake();

            //Cache Animator.
            animator = GetComponent<Animator>();
        }
        
        #endregion
        
        #region METHODS

        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Cache Interactor Behaviour.
            interactorBehaviour ??= characterBehaviour.GetComponentInChildren<InteractorBehaviour>();
            if (interactorBehaviour != null && interactorBehaviour.CanInteract())
            {
                //Get Interactable.
                Interactable interactable = interactorBehaviour.GetInteractable();
                if (interactable != null)
                {
                    //Show.
                    animator.SetBool(stateName, true);
                        
                    //Modify Text.
                    if(textToModify != null)
                        textToModify.text = interactable.GetInteractionText().ToUpper();
                }
                //Hide.
                else
                    animator.SetBool(stateName, false);
            }
        }
        
        #endregion
    }
}