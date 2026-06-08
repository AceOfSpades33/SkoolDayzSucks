
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
        if(jump == false)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
        }

        rB.AddForce(dir * speed);
    }

    void Update()
    {
        TryJump();
        CheckDir();
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
        int salto = Random.Range(1, 101);
        if(salto == 100 && touchingFloor == true)
        {
            if(speed > 0)
            {
                Jump();
            }
        }
        if(salto < 3)
        {
            jump = false;
        }
    }

    private void Jump()
    {
        rB.AddForceY(50);
        jump = true;
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
            speed = -3;
            dir.x *= -1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Floor")
            touchingFloor = false;
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
