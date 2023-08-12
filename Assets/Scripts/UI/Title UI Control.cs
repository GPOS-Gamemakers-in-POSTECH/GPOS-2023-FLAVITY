using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIControl : MonoBehaviour
{
    // New Game Button - Change Scene
    public void ChangeScene()
    {
        SceneManager.LoadScene("Map");
    }

    // Quit Button - Quit Game
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
