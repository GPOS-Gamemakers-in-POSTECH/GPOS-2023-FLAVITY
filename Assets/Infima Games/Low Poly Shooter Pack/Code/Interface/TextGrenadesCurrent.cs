//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using System.Globalization;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Current Grenades Text.
    /// </summary>
    public class TextGrenadesCurrent : ElementText
    {
        #region FIELDS SERIALIZED
        
        [Title(label: "Colors")]
        
        [Tooltip("Determines if the color of the text should changes as grenades are thrown.")]
        [SerializeField]
        private bool updateColor = true;
        
        [Tooltip("Determines how fast the color changes as the grenade are thrown.")]
        [SerializeField]
        private float emptySpeed = 1.5f;
        
        [Tooltip("Color used on this text when the player character has no grendes.")]
        [SerializeField]
        private Color emptyColor = Color.red;

        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Current.
            float current = characterBehaviour.GetGrenadesCurrent();
            //Total.
            float total = characterBehaviour.GetGrenadesTotal();
            
            //Update Text.
            textMesh.text = current.ToString(CultureInfo.InvariantCulture);

            //Determine if we should update the text's color.
            if (updateColor)
            {
                //Calculate Color Alpha. Helpful to make the text color change based on grenade count.
                float colorAlpha = (current / total) * emptySpeed;
                //Lerp Color. This makes sure that the text color changes based on grenade count.
                textMesh.color = Color.Lerp(emptyColor, Color.white, colorAlpha);   
            }
        }
        
        #endregion
    }
}