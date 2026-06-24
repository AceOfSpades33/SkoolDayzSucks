
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] public float speed =  5;
    [SerializeField] public int currentHealth;
    [SerializeField] public int coins = 0;
    [SerializeField] public int maxCoins = 0;
    [SerializeField] private CoinsNumber coinsNumberScript;
    [SerializeField] private HealthUI barraVida;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public bool entrar;
    public bool abrirPuerta;

    void Awake()
    {
        entrar = false;
        maxHealth = 100;
        abrirPuerta = false;
        SetHealth(maxHealth);
        coins = 0;
    }

    void Start()
    {
        maxCoins = coinsNumberScript.coinsNumberVar; 
    }

    void Update()
    {
        if(abrirPuerta == false)
        {
            CheckCoins();
        }
        if(this.transform.position.y < -50)
        {
            GameOver();
        }
    }

    public void SetHealth(float healthToSet)
    {
        currentHealth = (int) healthToSet;
        barraVida.UpdateHealthAmount((float)currentHealth / maxHealth);
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void CheckCoins()
    {
        if(coins >= maxCoins)
        {
            abrirPuerta = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")
        {
            audioSource.Play();
            coins = coins + 1;
        }
    }

    private void GameOver()
    {
        Destroy(this.gameObject);
    }

}
