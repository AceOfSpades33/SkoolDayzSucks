using UnityEngine;

public class TriggerAttackBoss : MonoBehaviour
{
    [SerializeField] private BossMovements boss;
    [SerializeField] private bool yaAtacado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yaAtacado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null)
        {
            this.transform.position = boss.gameObject.transform.position;
            if (boss.dir.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(boss.atacando && yaAtacado == false)
        {
            other.TryGetComponent<PlayerStats>(out PlayerStats player);
            if(player != null)
            {
                player.SetHealth(player.currentHealth - 20);
                yaAtacado = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(boss.atacando && yaAtacado == false)
        {
            other.TryGetComponent<PlayerStats>(out PlayerStats player);
            if(player != null && yaAtacado == false)
            {
                player.SetHealth(player.currentHealth - 20);
                yaAtacado = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        yaAtacado = false;
    }
}
