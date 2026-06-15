using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        //Sonidito de recoger moneda o some shi
    }
}
