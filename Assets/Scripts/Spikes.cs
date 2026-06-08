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
            playerStats.SetHealth(0);
        }
        if(collision.tag == "Enemy")
        {
            collision.TryGetComponent<EnemyStats>(out EnemyStats enemyStats);
            enemyStats.SetHealth(0);
        }
    }
}
