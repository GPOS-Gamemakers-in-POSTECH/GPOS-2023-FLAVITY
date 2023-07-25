//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Weapon Image. Handles assigning the proper sprites to the weapon images.
    /// </summary>
    public class ImageWeapon : Element
    {
        #region FIELDS SERIALIZED

        [Title(label: "Colors")]

        [Tooltip("Color applied to all images.")]
        [SerializeField]
        private Color imageColor = Color.white;
        
        [Title(label: "Settings")]
        
        [Tooltip("Weapon Body Image.")]
        [SerializeField]
        private Image imageWeaponBody;

        [Tooltip("Weapon Grip Image.")]
        [SerializeField]
        private Image imageWeaponGrip;

        [Tooltip("Weapon Laser Image.")]
        [SerializeField]
        private Image imageWeaponLaser;
        
        [Tooltip("Weapon Silencer Image.")]
        [SerializeField]
        private Image imageWeaponMuzzle;
        
        [Tooltip("Weapon Magazine Image.")]
        [SerializeField]
        private Image imageWeaponMagazine;
        
        [Tooltip("Weapon Scope Image.")]
        [SerializeField]
        private Image imageWeaponScope;
        
        [Tooltip("Weapon Scope Default Image.")]
        [SerializeField]
        private Image imageWeaponScopeDefault;

        #endregion

        #region FIELDS

        /// <summary>
        /// Weapon Attachment Manager.
        /// </summary>
        private WeaponAttachmentManagerBehaviour attachmentManagerBehaviour;

        #endregion

        #region METHODS

        protected override void Tick()
        {
            //Calculate what color and alpha we need to apply.
            Color toAssign = imageColor;
            foreach (Image image in GetComponents<Image>())
                image.color = toAssign;
            
            //Get Attachment Manager.
            attachmentManagerBehaviour = equippedWeaponBehaviour.GetAttachmentManager();
            //Update the weapon's body sprite!
            imageWeaponBody.sprite = equippedWeaponBehaviour.GetSpriteBody();

            //Sprite.
            Sprite sprite = default;

            //Scope Default.
            ScopeBehaviour scopeDefaultBehaviour = attachmentManagerBehaviour.GetEquippedScopeDefault();
            //Get Sprite.
            if (scopeDefaultBehaviour != null)
                sprite = scopeDefaultBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponScopeDefault, sprite, scopeDefaultBehaviour == null);
            
            //Scope.
            ScopeBehaviour scopeBehaviour = attachmentManagerBehaviour.GetEquippedScope();
            //Get Sprite.
            if (scopeBehaviour != null)
                sprite = scopeBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponScope, sprite, scopeBehaviour == null || scopeBehaviour == scopeDefaultBehaviour);

            //Magazine.
            MagazineBehaviour magazineBehaviour = attachmentManagerBehaviour.GetEquippedMagazine();
            //Get Sprite.
            if (magazineBehaviour != null)
                sprite = magazineBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponMagazine, sprite, magazineBehaviour == null);

            //Laser.
            LaserBehaviour laserBehaviour = attachmentManagerBehaviour.GetEquippedLaser();
            //Get Sprite.
            if (laserBehaviour != null)
                sprite = laserBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponLaser, sprite, laserBehaviour == null);
            
            //Grip.
            GripBehaviour gripBehaviour = attachmentManagerBehaviour.GetEquippedGrip();
            //Get Sprite.
            if (gripBehaviour != null)
                sprite = gripBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponGrip, sprite, gripBehaviour == null);
            
            //Muzzle.
            MuzzleBehaviour muzzleBehaviour = attachmentManagerBehaviour.GetEquippedMuzzle();
            //Get Sprite.
            if (muzzleBehaviour != null)
                sprite = muzzleBehaviour.GetSprite();
            //Assign Sprite!
            AssignSprite(imageWeaponMuzzle, sprite, muzzleBehaviour == null);
        }

        /// <summary>
        /// Assigns a sprite to an image.
        /// </summary>
        private static void AssignSprite(Image image, Sprite sprite, bool forceHide = false)
        {
            //Update.
            image.sprite = sprite;
            //Disable image if needed.
            image.enabled = sprite != null && !forceHide;
        }

        #endregion
    }
}