using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenuPap : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;

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
        SceneManager.LoadScene("MainMenu");
    }
}
