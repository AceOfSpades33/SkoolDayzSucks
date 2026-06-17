
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private EnemyBuletBehavoiur bullet;
    [SerializeField] private float shootDelay = 5f;
    [SerializeField] private Transform shootPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryShoot();
    }

    void TryShoot()
    {
        if(Time.time > shootDelay)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.identity, this.transform);
            shootDelay = Time.time + 5;
        }
    }
}
