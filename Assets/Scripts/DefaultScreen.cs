using UnityEngine;

public class DefaultScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
