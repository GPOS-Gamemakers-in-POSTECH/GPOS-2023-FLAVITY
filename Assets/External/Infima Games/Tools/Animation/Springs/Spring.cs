//Copyright 2022, Infima Games. All Rights Reserved.

using System;
using UnityEngine;

namespace InfimaGames
{
    /// <summary>
    /// Spring. Handles interpolation with a spring-shaped motion. Very helpful to avoid normal interpolation
    /// which looks quite lame.
    /// </summary>
    public class Spring
    {
        /// <summary>
        /// Settings.
        /// </summary>
        private SpringSettings settings;

        private Vector3 initialVelocity;
        
        private Vector3 start;
        private Vector3 end;

        private Vector3 currentValue;
        private Vector3 currentVelocity;
        private Vector3 currentAcceleration;

        private float stepSize = 1f / 61f; // stable if < deltaTime && < 1/60
        private bool isFirstEvaluate = true;

        /// <summary>
        /// Current Held Frames.
        /// </summary>
        private int hFrames;
        /// <summary>
        /// Current Held Force.
        /// </summary>
        private HeldForce heldForce;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Spring()
        {
            settings = new SpringSettings()
            {
                damping = 16.0f,
                mass = 1.0f,
                speed = 1.0f,
                stiffness = 169.0f
            };
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public Spring(SpringSettings newSettings) => settings = newSettings;

        /// <summary>
        /// Resets all values to initial states.
        /// </summary>
        private void Reset()
        {
            currentValue = start;
            currentVelocity = initialVelocity;
            currentAcceleration = Vector3.zero;
        }

        /// <summary>
        /// Adjust Settings.
        /// </summary>
        public void Adjust(SpringSettings newSettings) => settings = newSettings;

        /// <summary>
        /// Update the end value in the middle of motion.
        /// This reuses the current velocity and interpolate the value smoothly afterwards.
        /// </summary>
        /// <param name="value">End value</param>
        public void UpdateEndValue(Vector3 value) => UpdateEndValue(value, currentVelocity);
        /// <summary>
        /// Sets the held force to use.
        /// </summary>
        public void SetHeldForce(HeldForce force) => heldForce = force;

        /// <summary>
        /// Update the end value in the middle of motion but using a new velocity.
        /// </summary>
        /// <param name="value">End value</param>
        /// <param name="velocity">New velocity</param>
        public void UpdateEndValue(Vector3 value, Vector3 velocity)
        {
            end = value;
            currentVelocity = velocity;
        }
        /// <summary>
        /// Advance a step by deltaTime(seconds).
        /// </summary>
        public Vector3 Evaluate()
        {
            if (heldForce.Frames > 0)
            {
                hFrames++;

                if (hFrames >= heldForce.Frames)
                {
                    hFrames = 0;
                    heldForce = default;
                }
            }
            
            if (isFirstEvaluate)
            {
                Reset();
                isFirstEvaluate = false;
            }

            //Multiply by speed to make the spring faster.
            float deltaTime = Time.deltaTime * settings.speed;

            float c = settings.damping;
            float m = settings.mass;
            float k = settings.stiffness;

            Vector3 x = currentValue;
            Vector3 v = currentVelocity;
            Vector3 a = currentAcceleration;

            float _stepSize = deltaTime > stepSize ? stepSize : deltaTime - 0.001f;
            float steps = Mathf.Ceil(deltaTime / _stepSize);
            for (var i = 0; i < steps; i++)
            {
                float dt = Math.Abs(i - (steps - 1)) < 0.01f ? deltaTime - i * _stepSize : _stepSize;

                x += v * dt + a * (dt * dt * 0.5f);
                // springForce = -k * (x - endValue)
                // dampingForce = -c * v
                var _a = (-k * (x - (end + heldForce.Force)) + -c * v) / m;
                v += (a + _a) * (dt * 0.5f);
                a = _a;
            }

            currentValue = x;
            currentVelocity = v;
            currentAcceleration = a;

            return currentValue;
        }

        public Vector3 Evaluate(SpringSettings newSettings)
        {
            //Adjust Settings.
            Adjust(newSettings);

            //Evaluate.
            return Evaluate();
        }
    }
}