using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeEsc = KeyCode.Escape;

    public static bool GameIsPaused = false;
    public GameObject PauseObj;
    public GameObject OptionObj;

    void Update()
    {
        if(Input.GetKeyDown(keyCodeEsc))
        {
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseObj.SetActive(false);
        OptionObj.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        PauseObj.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Main() {
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
