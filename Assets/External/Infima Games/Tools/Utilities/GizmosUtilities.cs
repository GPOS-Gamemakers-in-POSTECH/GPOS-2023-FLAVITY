#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// GizmosUtilities.
    /// </summary>
    public static class GizmosUtilities
    {
        public static bool CanDraw(bool playCheck = false)
        {
            //Check if the game is playing.
            if (playCheck && !Application.isPlaying)
                return false;

            //Only draw gizmos in the scene view, or from the main camera.
            return (SceneView.focusedWindow is SceneView) || (Camera.current != Camera.main);
        }
    }
}
#endif