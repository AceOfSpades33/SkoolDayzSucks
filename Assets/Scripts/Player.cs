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

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        c = new Controls();
        c.Enable();
        this.transform.position = new Vector2(0,0);
    }

    private void FixedUpdate()
    {
        rB.AddForce(dir * playerStats.speed);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        touchFloor = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        touchFloor = false;
    }

}
