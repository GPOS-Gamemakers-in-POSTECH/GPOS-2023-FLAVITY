//Copyright 2022, Infima Games. All Rights Reserved.

using TMPro;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Display an animation's name in the world.
    /// </summary>
    public class DisplayAnimationName : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Tooltip("Text Display.")]
        [SerializeField]
        private TextMeshProUGUI currentAnimationText;

        #endregion

        #region FIELDS

        /// <summary>
        /// Cached Animator.
        /// </summary>
        private Animator cachedAnimator;

        #endregion

        #region UNITY

        private void Start()
        {
            //Get them_Animator, which you attach to the GameObject you intend to animate.
            cachedAnimator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            //Fetch the current Animation clip information for the base layer
            AnimatorClipInfo[] currentClipInfo = cachedAnimator.GetCurrentAnimatorClipInfo(0);
            //Output the current Animation name to UI text
            currentAnimationText.text = currentClipInfo[0].clip.name;
        }

        #endregion
    }
}