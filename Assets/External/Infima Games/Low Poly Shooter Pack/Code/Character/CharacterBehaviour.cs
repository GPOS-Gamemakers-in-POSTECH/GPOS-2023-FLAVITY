//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Character Abstract Behaviour.
    /// </summary>
    public abstract class CharacterBehaviour : MonoBehaviour
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
        /// LateUpdate.
        /// </summary>
        protected virtual void LateUpdate(){}

        #endregion
        
        #region GETTERS
        
        /// <summary>
        /// This function should return the amount of shots that the character has fired in succession.
        /// Using this value for applying recoil, and for modifying spread is what we have this function for.
        /// </summary>
        /// <returns></returns>
        public abstract int GetShotsFired();
        /// <summary>
        /// Returns true when the character's weapons are lowered.
        /// </summary>
        public abstract bool IsLowered();

        /// <summary>
        /// Returns the player character's main camera.
        /// </summary>
        public abstract Camera GetCameraWorld();
        /// <summary>
        /// Returns the player character's weapon camera.
        /// </summary>
        /// <returns></returns>
        public abstract Camera GetCameraDepth();
        
        /// <summary>
        /// Returns a reference to the Inventory component.
        /// </summary>
        public abstract InventoryBehaviour GetInventory();

        /// <summary>
        /// Returns the current amount of grenades left.
        /// </summary>
        public abstract int GetGrenadesCurrent();
        /// <summary>
        /// Returns the total amount of grenades left.
        /// </summary>
        public abstract int GetGrenadesTotal();

        /// <summary>
        /// Returns true if the character is running.
        /// </summary>
        public abstract bool IsRunning();
        /// <summary>
        /// Returns true if the character has a weapon that is holstered in their hands.
        /// </summary>
        public abstract bool IsHolstered();

        /// <summary>
        /// Returns true if the character is crouching.
        /// </summary>
        public abstract bool IsCrouching();
        /// <summary>
        /// Returns true if the character is reloading.
        /// </summary>
        public abstract bool IsReloading();

        /// <summary>
        /// Returns true if the character is throwing a grenade.
        /// </summary>
        public abstract bool IsThrowingGrenade();
        /// <summary>
        /// Returns true if the character is meleeing.
        /// </summary>
        public abstract bool IsMeleeing();
        
        /// <summary>
        /// Returns true if the character is aiming.
        /// </summary>
        public abstract bool IsAiming();
        /// <summary>
        /// Returns true if the game cursor is locked.
        /// </summary>
        public abstract bool IsCursorLocked();

        /// <summary>
        /// Returns true if the tutorial text should be visible on the screen.
        /// </summary>
        public abstract bool IsTutorialTextVisible();

        /// <summary>
        /// Returns the Movement Input.
        /// </summary>
        public abstract Vector2 GetInputMovement();
        /// <summary>
        /// Returns the Look Input.
        /// </summary>
        public abstract Vector2 GetInputLook();

        /// <summary>
        /// Returns the audio clip played when the character throws a grenade.
        /// </summary>
        public abstract AudioClip[] GetAudioClipsGrenadeThrow();
        /// <summary>
        /// Returns the audio clip played when the character melees.
        /// </summary>
        public abstract AudioClip[] GetAudioClipsMelee();
        
        /// <summary>
        /// Returns true if the character is inspecting.
        /// </summary>
        public abstract bool IsInspecting();
        /// <summary>
        /// Returns true if the player is holding the fire button.
        /// </summary>
        /// <returns></returns>
        public abstract bool IsHoldingButtonFire();
        
        #endregion

        #region ANIMATION

        /// <summary>
        /// Ejects a casing from the equipped weapon.
        /// </summary>
        public abstract void EjectCasing();
        /// <summary>
        /// Fills the character's equipped weapon's ammunition by a certain amount, or fully if set to -1.
        /// </summary>
        public abstract void FillAmmunition(int amount);

        /// <summary>
        /// Throws a grenade.
        /// </summary>
        public abstract void Grenade();
        /// <summary>
        /// Sets the equipped weapon's magazine to be active or inactive!
        /// </summary>
        public abstract void SetActiveMagazine(int active);
        
        /// <summary>
        /// Bolt Animation Ended.
        /// </summary>
        public abstract void AnimationEndedBolt();
        /// <summary>
        /// Reload Animation Ended.
        /// </summary>
        public abstract void AnimationEndedReload();

        /// <summary>
        /// Grenade Throw Animation Ended.
        /// </summary>
        public abstract void AnimationEndedGrenadeThrow();
        /// <summary>
        /// Melee Animation Ended.
        /// </summary>
        public abstract void AnimationEndedMelee();

        /// <summary>
        /// Inspect Animation Ended.
        /// </summary>
        public abstract void AnimationEndedInspect();
        /// <summary>
        /// Holster Animation Ended.
        /// </summary>
        public abstract void AnimationEndedHolster();

        /// <summary>
        /// Sets the equipped weapon's slide back pose.
        /// </summary>
        public abstract void SetSlideBack(int back);

        public abstract void SetActiveKnife(int active);

        #endregion
    }
}