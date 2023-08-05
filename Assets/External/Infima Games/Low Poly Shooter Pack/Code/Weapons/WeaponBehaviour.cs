//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        #region UNITY

        /// <summary>
        /// Awake.
        /// </summary>
        protected virtual void Awake(){}

        /// <summary>
        /// Start.
        /// </summary>
        protected virtual void Start(){}

        /// <summary>
        /// Update.
        /// </summary>
        protected virtual void Update(){}

        /// <summary>
        /// Late Update.
        /// </summary>
        protected virtual void LateUpdate(){}

        #endregion

        #region GETTERS

        /// <summary>
        /// Returns the sprite to use when displaying the weapon's body.
        /// </summary>
        /// <returns></returns>
        public abstract Sprite GetSpriteBody();
        /// <summary>
        /// Returns the value of multiplierMovementSpeed;
        /// </summary>
        public abstract float GetMultiplierMovementSpeed();

        /// <summary>
        /// Returns the holster audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipHolster();
        /// <summary>
        /// Returns the unholster audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipUnholster();

        /// <summary>
        /// Returns the reload audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipReload();
        /// <summary>
        /// Returns the reload empty audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipReloadEmpty();
        
        /// <summary>
        /// Returns the reload open audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipReloadOpen();
        /// <summary>
        /// Returns the reload insert audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipReloadInsert();
        /// <summary>
        /// Returns the reload close audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipReloadClose();

        /// <summary>
        /// Returns the fire empty audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipFireEmpty();
        /// <summary>
        /// Returns the bolt action audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipBoltAction();

        /// <summary>
        /// Returns the fire audio clip.
        /// </summary>
        public abstract AudioClip GetAudioClipFire();
        
        /// <summary>
        /// Returns Current Ammunition. 
        /// </summary>
        public abstract int GetAmmunitionCurrent();
        /// <summary>
        /// Returns Total Ammunition.
        /// </summary>
        public abstract int GetAmmunitionTotal();

        /// <summary>
        /// Determines if this Weapon reloads in cycles.
        /// </summary>
        public abstract bool HasCycledReload();

        /// <summary>
        /// Returns the Weapon's Animator component.
        /// </summary>
        public abstract Animator GetAnimator();

        /// <summary>
        /// Returns the value of canReloadAimed.
        /// </summary>
        public abstract bool CanReloadAimed();
        
        /// <summary>
        /// Returns true if this weapon shoots in automatic.
        /// </summary>
        public abstract bool IsAutomatic();
        /// <summary>
        /// Returns true if the weapon has any ammunition left.
        /// </summary>
        public abstract bool HasAmmunition();

        /// <summary>
        /// Returns true if the weapon is full of ammunition.
        /// </summary>
        public abstract bool IsFull();
        /// <summary>
        /// Returns true if this is a bolt-action weapon.
        /// </summary>
        public abstract bool IsBoltAction();

        /// <summary>
        /// Returns true if the weapon should be automatically reload when empty.
        /// </summary>
        public abstract bool GetAutomaticallyReloadOnEmpty();
        /// <summary>
        /// Returns the delay after firing the last shot when the weapon should start automatically reloading.
        /// </summary>
        public abstract float GetAutomaticallyReloadOnEmptyDelay();

        /// <summary>
        /// Can this weapon be reloaded when it is full?
        /// </summary>
        public abstract bool CanReloadWhenFull();
        /// <summary>
        /// Returns the weapon's rate of fire.
        /// </summary>
        public abstract float GetRateOfFire();

        /// <summary>
        /// Returns the field of view multiplier when aiming.
        /// </summary>
        public abstract float GetFieldOfViewMultiplierAim();
        /// <summary>
        /// Returns the field of view multiplier when aiming for the weapon camera.
        /// </summary>
        public abstract float GetFieldOfViewMultiplierAimWeapon();

        /// <summary>
        /// Returns the RuntimeAnimationController the Character needs to use when this Weapon is equipped!
        /// </summary>
        public abstract RuntimeAnimatorController GetAnimatorController();
        /// <summary>
        /// Returns the weapon's attachment manager component.
        /// </summary>
        public abstract WeaponAttachmentManagerBehaviour GetAttachmentManager();
        
        #endregion

        #region METHODS

        /// <summary>
        /// Fires the weapon.
        /// </summary>
        /// <param name="spreadMultiplier">Value to multiply the weapon's spread by. Very helpful to account for aimed spread multipliers.</param>
        public abstract void Fire(float spreadMultiplier = 1.0f);
        /// <summary>
        /// Reloads the weapon.
        /// </summary>
        public abstract void Reload();

        /// <summary>
        /// Fills the character's equipped weapon's ammunition by a certain amount, or fully if set to -1.
        /// </summary>
        public abstract void FillAmmunition(int amount);
        /// <summary>
        /// Sets the slide back pose.
        /// </summary>
        public abstract void SetSlideBack(int back);

        /// <summary>
        /// Ejects a casing from the weapon. This is commonly called from animation events, but can be called from anywhere.
        /// </summary>
        public abstract void EjectCasing();

        #endregion
    }
}