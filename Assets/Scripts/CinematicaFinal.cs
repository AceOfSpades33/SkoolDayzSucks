using System.Collections;
using UnityEngine;

public class CinematicaFinal : MonoBehaviour
{
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject creditos;
    [SerializeField] private GameObject agradecimiento;
    [SerializeField] private GameObject imagen;
    [SerializeField] private GameObject fondo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imagen.SetActive(true);
        fondo.SetActive(false);
        titulo.SetActive(false);
        creditos.SetActive(false);
        agradecimiento.SetActive(false);
        StartCoroutine(Cinematica());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(44f);
        imagen.SetActive(false);
        fondo.SetActive(true);
        titulo.SetActive(true);
        yield return new WaitForSeconds(3f);
        creditos.SetActive(true);
        yield return new WaitForSeconds(3f);
        agradecimiento.SetActive(true);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
