using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private LoadingScreen screen;
    [SerializeField] private GameObject optionsMenu;

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
        optionsMenu.SetActive(true);
    }

    public void OptionsButtonExit()
    {
        optionsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
