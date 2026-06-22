using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int maxLive;
    [SerializeField] public int currentHealth = 10;
    [SerializeField] private ShakeFeedback shakeFeedback;
    
    void Awake()
    {
        currentHealth = maxLive;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            SetHealth(currentHealth - 10);
            Destroy(collision.gameObject);
        }
    }

    public void SetHealth(int healthToSet)
    {
        shakeFeedback?.DoShake();
        currentHealth = healthToSet;
        if(currentHealth <= 0 && this.gameObject.name != "Boss")
        {
            Die();
        }
    }

    void Update()
    {
        
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
