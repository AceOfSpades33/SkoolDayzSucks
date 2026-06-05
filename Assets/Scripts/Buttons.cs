using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OptionsButton()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
