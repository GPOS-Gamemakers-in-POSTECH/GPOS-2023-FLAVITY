using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public class LimitFramerate : MonoBehaviour
    {
        [Tooltip("Are we limiting the framerate, or keeping it as is by default?")]
        [SerializeField]
        private bool limit = true;

        [Tooltip("Max frames the game can have while limited.")]
        [SerializeField]
        private int framerate = 15;

        private int defaultVSync;
        private int defaultTargetFramerate;

        private void Awake()
        {
            //Save defaults.
            defaultVSync = QualitySettings.vSyncCount;
            defaultTargetFramerate = Application.targetFrameRate;
        }

        private void Update()
        {
            //Limit the framerate if required.
            QualitySettings.vSyncCount = limit ? 0 : defaultVSync;
            Application.targetFrameRate = limit ? framerate : defaultTargetFramerate;
        }
    }
}