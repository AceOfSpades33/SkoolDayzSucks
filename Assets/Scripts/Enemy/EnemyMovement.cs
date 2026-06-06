
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool jump;
    [SerializeField] private bool turn;
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Vector2 dir;
    [SerializeField] private bool inRange;
    private bool touchingFloor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        dir.x = 1;
    }

    void FixedUpdate()
    {
        rB.AddForce(dir * speed);
    }

    void Update()
    {
        TryJump();
    }

    private void TryAttack()
    {
        if(inRange)
        {
            Attack(10);
        }
    }

    private void TryJump()
    {
        int salto = Random.Range(1, 11);
        if(salto == 10 && touchingFloor == true)
        {
            jump = true;
            Jump();
        }
        else
        {
            jump = false;
        }
    }

    private void Jump()
    {

        rB.AddForceY(100);
        
    }

    private void Attack(float damage)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Floor")
            touchingFloor = true;
        if(other.tag == "Walls")
        {
            dir.x *= -1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Floor")
            touchingFloor = false;
    }
}
