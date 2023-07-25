//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// JumpMotion. This component makes an object play correct jumping and falling curves when the character is in those
    /// specific states.
    /// </summary>
    public class JumpMotion : Motion
    {
        #region FIELDS SERIALIZED
        
        [Tooltip("The character's FeelManager.")]
        [SerializeField, NotNull]
        private FeelManager feelManager;

        [Tooltip("The character's MovementBehaviour component.")]
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

            //Current FeelState.
            FeelState state = feel.GetState(characterAnimator);
            
            //Check Grounded.
            if (!movementBehaviour.IsGrounded())
            {
                //Calculate Air Time.
                float airTime = Time.time - movementBehaviour.GetLastJumpTime();

                //Check if the air time was caused by a jump.
                if (movementBehaviour.IsJumping())
                {
                    //This value represents the point at which the jumping curves are done. I.e: Length.
                    var maxCurveLength = 0.0f;

                    //Jumping Curves.
                    ACurves jumpingCurves = state.JumpingCurves;
                
                    //Loop Jumping Location Curves.
                    jumpingCurves.LocationCurves.ForEach(curve =>
                    {
                        //Update length if needed, to match longest.
                        if (curve.length > maxCurveLength)
                            maxCurveLength = curve.length;
                    });
                    
                    //Loop Jumping Rotation Curves.
                    jumpingCurves.RotationCurves.ForEach(curve =>
                    {
                        //Update length if needed, to match longest.
                        if (curve.length > maxCurveLength)
                            maxCurveLength = curve.length;
                    });
                    
                    //Check if the jumping curves should have finished playing by now.
                    if (Time.time - movementBehaviour.GetLastJumpTime() >= maxCurveLength)
                    {
                        //Remove that time, so we can still use this value to evaluate the falling curves.
                        airTime -= maxCurveLength;
                        //Use the falling curves, instead of the jumping curves, since those are done.
                        playedCurves = state.FallingCurves;
                    }
                    //Keep using the jumping curves.
                    else
                        playedCurves = state.JumpingCurves;   
                }
                //Falling.
                else
                {
                    //Use the falling curves, since the character hasn't jumped, so it must be falling!
                    playedCurves = state.FallingCurves;
                }
                
                //Evaluate Location Curves.
                location += playedCurves.LocationCurves.EvaluateCurves(airTime);
                //Evaluate Rotation Curves.
                rotation += playedCurves.RotationCurves.EvaluateCurves(airTime);
            }

            //Update Spring Location Value.
            springLocation.UpdateEndValue(location);
            //Update Spring Rotation Value.
            springRotation.UpdateEndValue(rotation);
        }
   
        #endregion
        
        #region FUNCTIONS

        /// <summary>
        /// GetLocation.
        /// </summary>
        public override Vector3 GetLocation()
        {
            //Check for playedCurves.
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
            //Check for playedCurves.
            if (playedCurves == null)
                return default;
            
            //Return.
            return springRotation.Evaluate(playedCurves.RotationSpring);
        }
        
        #endregion
    }
}