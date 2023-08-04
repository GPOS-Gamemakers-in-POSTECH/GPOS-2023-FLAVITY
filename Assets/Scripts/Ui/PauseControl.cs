using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeEsc = KeyCode.Escape;

    private int rotCamXAxisSpeed_size = 2;
    private int rotCamYAxisSpeed_size = 2;

    public static bool GameIsPaused = false;
    public GameObject PauseObj;
    public GameObject OptionObj;

    void Start()
    {
        
    }

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

    public void MouseValue()
    {
    }
}
