using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Change Scene
    public void SceneChange()
    {
        SceneManager.LoadScene("Map");
    }
}
