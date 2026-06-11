using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
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
