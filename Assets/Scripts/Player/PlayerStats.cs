
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] public float speed =  5;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damage = 10;
    [SerializeField] private int coins = 0;
    [SerializeField] private int maxCoins = 0;
    [SerializeField] private CoinsNumber coinsNumberScript;
    [SerializeField] public bool entrar;
    public bool abrirPuerta;

    void Awake()
    {
        entrar = false;
        abrirPuerta = false;
        currentHealth = maxHealth;
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
    }

    public void SetHealth(int healthToSet)
    {
        currentHealth = healthToSet;
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
            coins = coins + 1;
        }
    }
}
