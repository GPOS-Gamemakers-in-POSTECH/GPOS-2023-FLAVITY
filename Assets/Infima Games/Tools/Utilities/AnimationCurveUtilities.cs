//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// This class contains utility functions to help with manipulation of AnimationCurve values.
    /// </summary>
    public static class AnimationCurveUtilities
    {
        /// <summary>
        /// Evaluates a set of curves (in Vector3 format: x,y,z) at a specific time and returns the value as a Vector3.
        /// </summary>
        public static Vector3 EvaluateCurves(this AnimationCurve[] animationCurves, float time)
        {
            //Make sure that the AnimationCurve values are valid.
            if (animationCurves == null || animationCurves.Length != 3)
                return default;
            
            //Return.
            return new Vector3
            {
                //X.
                x = animationCurves[0].Evaluate(time),
                //Y.
                y = animationCurves[1].Evaluate(time),
                //Z.
                z = animationCurves[2].Evaluate(time)
            };
        }
    }
}