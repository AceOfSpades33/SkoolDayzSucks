using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool jump;
    [SerializeField] private bool turn;
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private Vector2 dir;
    [SerializeField] private bool inRange;
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Walls")
        {
            dir.x *= -1;
        }
    }

    private void TryAttack()
    {
        if(inRange)
        {
            Attack(10);
        }
    }

    private void Attack(float damage)
    {
        
    }
}
