using System.Collections;
using UnityEngine;

public class Cinematica : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private LoadingScreen loadingScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        loadingScreen = GameObject.FindFirstObjectByType<LoadingScreen>();
        audioSource.Play();
        StartCoroutine(TimeLife());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(39f);
        loadingScreen.StartLoading("Game");
    }
}
