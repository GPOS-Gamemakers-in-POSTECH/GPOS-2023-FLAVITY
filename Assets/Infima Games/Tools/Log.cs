﻿using System;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public static class Log
    {
        public static void wtf() { Internal_Log("Wtf", LogType.Log); }
        public static void wtf(object toPrint)
        {
            //Null check.
            if (toPrint == null)
                toPrint = "Null";

            string message = "Wtf happened: " + toPrint;
            Internal_Log(message, LogType.Log);
        }

        public static void warn_me() { Internal_Log("You have been warned", LogType.Warning); }
        public static void warn_me(object warning)
        {
            //Null check.
            if (warning == null)
                warning = "Null";

            string message = "You have been warned that: " + warning;
            Internal_Log("You have been warned that: " + warning, LogType.Warning);
        }

        public static void kill() { Internal_Log("I will find you, and I will kill you", LogType.Error); }
        public static void kill(object toKill)
        {
            //Null check.
            if (toKill == null)
                toKill = "Null";

            string message = "You have been warned that: " + toKill;
            Internal_Log(message, LogType.Error);
        }

        public static void oopsie(Exception oopsie, UnityEngine.Object context = default(UnityEngine.Object)) { Debug.LogException(oopsie, context); }

        /// <summary>
        /// Throws a reference error. We have this as a specific function so we don't have to repeat it
        /// everywhere, which would be quite tedious.
        /// </summary>
        /// <param name="behaviour">Behaviour throwing the error.</param>
        /// <param name="gameObject">GameObject that the behaviour is added to.</param>
        public static void ReferenceError(MonoBehaviour behaviour, GameObject gameObject)
        {
            //Error Message.
            kill($"Component {behaviour.GetType().Name} on GameObject {gameObject.name} has missing references, and will " +
                     $"not correctly function. Please fix this so the component can work properly!");
        }

        private static void Internal_Log(string message, LogType type)
        {
            // Null case.
            if (message == " ")
                message = "Null";

            switch (type)
            {
                case LogType.Log:
                    Debug.Log(message);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                    Debug.LogError(message);
                    break;
                case LogType.Assert:
                    break;
                case LogType.Exception:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(type.GetType().FullName, type, null);
            }
        }
    }
}