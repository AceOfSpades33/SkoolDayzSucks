using UnityEngine;

public class EnemyBuletBehavoiur : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Vector2 dir;
    [SerializeField] private float dirY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        EnemyMovement enemy = GetComponentInParent<EnemyMovement>();
        if (enemy.dir.x >= 0)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
