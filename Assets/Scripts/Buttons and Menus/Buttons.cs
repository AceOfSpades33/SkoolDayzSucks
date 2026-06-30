using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private LoadingScreen screen;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private AudioSource audioSource;

    public void Awake()
    {
        screen = GameObject.FindFirstObjectByType<LoadingScreen>();
    }

    public void PlayButton()
    {
        audioSource.Play();
        screen.StartLoading("Game");
        Time.timeScale = 1f;
    }

    public void OptionsButton()
    {
        audioSource.Play();
        optionsMenu.SetActive(true);
    }

    public void OptionsButtonExit()
    {
        audioSource.Play();
        optionsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        audioSource.Play();
        Application.Quit();
    }

}
