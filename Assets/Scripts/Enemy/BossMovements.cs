using System.Numerics;
using UnityEngine;

public class BossMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int frecuenceAttack;
    [SerializeField] private Vector2 dir;
    [SerializeField] private bool turn;
    [SerializeField] private Rigidbody2D rB;

    void FixedUpdate()
    {
        rB.AddForce(dir * speed);
    }

    void Update()
    {
        CheckDir();
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
