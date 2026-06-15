using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] public Vector2 dir;
    [SerializeField] public Controls c;
    [SerializeField] private float jumpForce = 20;
    [SerializeField] private bool touchFloor = false;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] public bool falling;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        c = new Controls();
        c.Enable();
        this.transform.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rB.AddForce(dir * playerStats.speed);
    }

    void Update()
    {
        Jump();
        Movement();
        CheckFall();
        CheckEnter();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
            touchFloor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
            touchFloor = false;
    }

    //Que se caiga
    void CheckFall()
    {
        if (rB.linearVelocityY < -2)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }

    void Movement()
    {
        dir = c.Player.Move.ReadValue<Vector2>();
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void CheckEnter()
    {
        if(c.Player.Enter.IsPressed() && playerStats.entrar)
        {
            
        }
    }

    void Jump()
    {
        if (c.Player.Jump.IsPressed() && touchFloor == true)
        {
            rB.AddForceY(jumpForce);
        }
    }

    void CheckDoor()
    {
        
    }

}
