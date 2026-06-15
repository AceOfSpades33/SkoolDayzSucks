using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int currentHealth = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            currentHealth -= 1;
            Destroy(collision.gameObject);
        }
    }

    public void SetHealth(int healthToSet)
    {
        currentHealth = healthToSet;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
