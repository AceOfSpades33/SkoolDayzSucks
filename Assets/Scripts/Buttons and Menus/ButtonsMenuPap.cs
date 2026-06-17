using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenuPap : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private Player player;
    [SerializeField] private LoadingScreen screen;

    public void PauseBtn()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueBtn()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SalirBtn()
    {
        player.c.Disable();
        Time.timeScale = 1f;
        screen.StartLoading("MainMenu");
    }
}
