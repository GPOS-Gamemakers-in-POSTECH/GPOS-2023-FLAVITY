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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseObj.SetActive(false);
        OptionObj.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseObj.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
    }

    public void Main() 
    {
        Resume();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DataManager.Instance.SaveGameData();
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        Resume();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
