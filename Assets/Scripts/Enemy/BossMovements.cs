using UnityEngine;

public class BossMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int frecuenceAttack;
    [SerializeField] private int step;
    [SerializeField] private Vector2 dir;
    [SerializeField] private bool turn;
    [SerializeField] private Rigidbody2D rB;

    void FixedUpdate()
    {
        Move();
    }

    void Awake()
    {
        dir.x = 1;
    }

    void Move()
    {
        rB.AddForce(dir * speed);
    }

    void Update()
    {
        CheckDir();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Walls")
        {
            dir.x *= -1;
        }
    }

    private void CheckDir()
    {
        if(dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
