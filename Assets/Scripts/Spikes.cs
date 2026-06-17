using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats);
            float healthToLose = (float) playerStats.currentHealth - 70;
            if(healthToLose <= 0)
            {
                healthToLose = 0;
            }

            playerStats.SetHealth(healthToLose);
        }
        if(collision.tag == "Enemy")
        {
            collision.TryGetComponent<EnemyStats>(out EnemyStats enemyStats);
            enemyStats.SetHealth(0);
        }
    }
}
