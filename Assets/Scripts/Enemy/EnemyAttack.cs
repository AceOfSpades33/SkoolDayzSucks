using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyMovement enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = enemy.gameObject.transform.position;
        if (enemy.dir.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<PlayerStats>(out PlayerStats player);
        if(player != null)
        {
            player.SetHealth(player.currentHealth - 10);
        }
    }

}
