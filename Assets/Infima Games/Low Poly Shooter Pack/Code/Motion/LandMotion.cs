//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// LandMotion. This component plays the landing curves when a character lands.
    /// </summary>
    public class LandMotion : Motion
    {
        #region FIELDS SERIALIZED
        
        [Tooltip("Reference to the character's FeelManager component.")]
        [SerializeField, NotNull]
        private FeelManager feelManager;

        [Tooltip("Reference to the character's MovementBehaviour component.")]
        [SerializeField, NotNull]
        private MovementBehaviour movementBehaviour;
        
        [Tooltip("The character's Animator component.")]
        [SerializeField, NotNull]
        private Animator characterAnimator;

        [Title(label: "Settings")]

        [Tooltip("The type of this motion.")]
        [SerializeField]
        private MotionType motionType;
        
        #endregion
        
        #region FIELDS
        
        /// <summary>
        /// The location spring.
        /// </summary>
        private readonly Spring springLocation = new Spring();
        /// <summary>
        /// The rotation spring.
        /// </summary>
        private readonly Spring springRotation = new Spring();

        /// <summary>
        /// Represents the curves currently being played by this component.
        /// </summary>
        private ACurves playedCurves;

        /// <summary>
        /// Time.time at which the character last landed on the ground.
        /// </summary>
        private float landingTime;
        
        #endregion
        
        #region METHODS
        
        /// <summary>
        /// Tick.
        /// </summary>
        public override void Tick()
        {
            //Check References.
            if (feelManager == null || movementBehaviour == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);

                //Return.
                return;
            }
            
            //Get Feel.
            Feel feel = feelManager.Preset.GetFeel(motionType);
            if (feel == null)
            {
                //ReferenceError.
                Log.ReferenceError(this, gameObject);
                
                //Return.
                return;
            }
            
            //Location.
            Vector3 location = default;
            //Rotation.
            Vector3 rotation = default;

            //We store the landing time.
            if (movementBehaviour.IsGrounded() && !movementBehaviour.WasGrounded())
                landingTime = Time.time;
            
            //We start playing the landing curves.
            playedCurves = feel.GetState(characterAnimator).LandingCurves;

            //Time where we evaluate the landing curves.
            float evaluateTime = Time.time - landingTime;
                
            //Evaluate Location Curves.
            location += playedCurves.LocationCurves.EvaluateCurves(evaluateTime);
            //Evaluate Rotation Curves.
            rotation += playedCurves.RotationCurves.EvaluateCurves(evaluateTime);

            //Evaluate Location Curves.
            springLocation.UpdateEndValue(location);
            //Evaluate Rotation Curves.
            springRotation.UpdateEndValue(rotation);
        }
        
        #endregion
        
        #region FUNCTIONS

        /// <summary>
        /// GetLocation.
        /// </summary>
        public override Vector3 GetLocation()
        {
            //Check References.
            if (playedCurves == null)
                return default;

            //Return.
            return springLocation.Evaluate(playedCurves.LocationSpring);
        }
        /// <summary>
        /// GetEulerAngles.
        /// </summary>
        public override Vector3 GetEulerAngles()
        {
            //Check References.
            if (playedCurves == null)
                return default;
            
            //Return.
            return springRotation.Evaluate(playedCurves.RotationSpring);
        }
        
        #endregion
    }
}