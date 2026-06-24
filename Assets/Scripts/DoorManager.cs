using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerStats player;
    [SerializeField] private Collider2D collider;
    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        collider.enabled = false;
    }

    void Update()
    {
        if(player.abrirPuerta)
        {
            OpenDoor();
            player.abrirPuerta = false;
        }
    }

    void OpenDoor()
    {
        anim.SetTrigger("open");
        audioSource.Play();
        collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.entrar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.entrar = false;
        }
    }
}
