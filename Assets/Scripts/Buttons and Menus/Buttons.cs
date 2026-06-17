using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private LoadingScreen screen;

    public void Awake()
    {
        screen = GameObject.FindFirstObjectByType<LoadingScreen>();
    }

    public void PlayButton()
    {
        screen.StartLoading("Game");
        Time.timeScale = 1f;
    }

    public void OptionsButton()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
