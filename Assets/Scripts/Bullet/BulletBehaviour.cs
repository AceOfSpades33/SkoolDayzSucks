
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 40;
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Vector2 dir;
    [SerializeField] private float dirY;

    private void Awake()
    {
        Player player = GetComponentInParent<Player>();
        if (player.dir.x >= 0)
        {
            dir.x = 1;
        }
        else
        {
            dir.x = -1;
        }
        transform.SetParent(null);
        dir.y = dirY;
    }

    private void FixedUpdate()
    {
        rB.AddForce(dir * speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rango")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
