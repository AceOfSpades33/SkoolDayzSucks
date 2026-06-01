using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;
    [SerializeField] public Controls c;
    [SerializeField] private float jumpForce = 20;
    [SerializeField] private bool touchFloor = false;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        c = new Controls();
        c.Enable();
        this.transform.position = new Vector2(0,0);
    }

    private void FixedUpdate()
    {
        rB.AddForce(dir * speed);
    }

    void Update()
    {
        if(c.Player.Jump.IsPressed() && touchFloor == true)
        {
            rB.AddForceY(jumpForce);
        }
        dir = c.Player.Move.ReadValue<Vector2>();
        if(dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchFloor = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchFloor = false;
    }

}
