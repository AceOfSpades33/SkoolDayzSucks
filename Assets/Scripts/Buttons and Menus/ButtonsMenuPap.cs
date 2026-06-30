using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenuPap : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private Player player;
    [SerializeField] private LoadingScreen screen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject botonPause;
    [SerializeField] private GameObject marco;

    void Awake()
    {
        screen = GameObject.FindFirstObjectByType<LoadingScreen>();
        marco.SetActive(true);
        botonPause.SetActive(true);
    }

    public void PauseBtn()
    {
        audioSource.Play();
        
        menuPausa.SetActive(true);
        Time.timeScale = 0f;

        marco.SetActive(false);
        botonPause.SetActive(false);
    }

    public void ContinueBtn()
    {
        audioSource.Play();
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        marco.SetActive(true);
        botonPause.SetActive(true);
    }

    public void SalirBtn()
    {
        player.c.Disable();
        audioSource.Play();
        Time.timeScale = 1f;
        screen.StartLoading("MainMenu");
    }
}
