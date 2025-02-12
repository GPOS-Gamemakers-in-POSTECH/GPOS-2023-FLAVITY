using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIControl : MonoBehaviour
{
    public GameObject continue_button;
    private void Awake()
    {
        // Roading Data
        DataManager.Instance.LoadGameData();
        if (DataManager.Instance.data.pose == 0)
        {
            continue_button.GetComponent<Button>().interactable = false;
        }
    }

    public void ChangeScene()
    {
        DataManager.Instance.data.pose = 0;
        DataManager.Instance.data.time = 0;
        SceneManager.LoadScene("Map");
    }

    public void Continue()
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
