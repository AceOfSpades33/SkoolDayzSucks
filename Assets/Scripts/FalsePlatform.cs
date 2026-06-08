using System.Collections;
using UnityEngine;

public class FalsePlatform : MonoBehaviour
{
    [SerializeField] private float timeToDisappear = 5f;
    [SerializeField] private bool started = false;
    [SerializeField] private GameObject platform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<Player>(out Player player);
        if(player != null)
        {
            if(started == false)
            {
                StartCoroutine(TimeToDestroy());
                started = true;
            }
        }
    }

    public IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(timeToDisappear);
        Destroy(platform);
    }
}
