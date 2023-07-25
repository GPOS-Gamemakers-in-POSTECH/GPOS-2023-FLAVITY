using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public static class MathUtilities
    {
        public static bool IsBigger(float value, float otherValue, float tolerance = 0.01f) { return value > (otherValue + tolerance); }

        public static bool Equals(float value, float otherValue, float tolerance = 0.01f)
        {
            var diff = Mathf.Abs(otherValue - value);
            return diff < tolerance;
        }

        public static Vector3 GetTangentToPlane(Vector3 direction, Vector3 normal, Vector3 up)
        {
            var right = Vector3.Cross(direction, up).normalized;
            return Vector3.Cross(normal, right).normalized;
        }
    }
}