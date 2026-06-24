using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryHeal();
    }

    void TryHeal()
    {
        if(player.c.Player.Heal.IsPressed())
        {
            Heal();
        }
    }

    void Heal()
    {
        if(playerStats.currentHealth < playerStats.maxHealth - 10)
        {
            playerStats.SetHealth(playerStats.currentHealth + 10);
        }
    }
}
