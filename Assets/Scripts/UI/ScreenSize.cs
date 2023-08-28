using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        Screen.SetResolution(1920,1080,true);
    }
}
