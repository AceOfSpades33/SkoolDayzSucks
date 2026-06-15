using UnityEngine;

public class Muelle : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rB);
        Debug.Log(rB);
        anim.SetTrigger("uso");
        if(rB != null)
        {
            Vector2 dir = new Vector2(0, 600);          
            rB.AddForce(dir);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rB);
        Debug.Log(rB);
        if(rB != null)
        {
            Vector2 dir = new Vector2(0, 600);          
            rB.AddForce(dir);
        }
    }
}
