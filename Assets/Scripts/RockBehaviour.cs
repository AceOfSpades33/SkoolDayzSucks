using UnityEngine;
using System.Collections;

public class RockBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RockLife());
    }

    IEnumerator RockLife()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<PlayerStats>(out PlayerStats player);
        if(player != null)
        {
            player.SetHealth(player.currentHealth - 10);
            Destroy(this.gameObject);
        }
    }
}
