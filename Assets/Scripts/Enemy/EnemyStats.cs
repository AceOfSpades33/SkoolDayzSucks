using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int health = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health -= 1;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
