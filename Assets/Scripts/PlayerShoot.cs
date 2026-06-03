using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject bulletRange;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform puntoMira;
    private bool balaGenerada = false;

    private void Update()
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if (player.c.Player.Shoot.IsPressed() && balaGenerada == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        StartCoroutine(BulletLife());
    }

    IEnumerator BulletLife()
    {
        balaGenerada = true;
        GameObject bulletRangeClone = Instantiate(bulletRange, this.transform.position, Quaternion.identity, this.transform);
        Player player = GetComponentInParent<Player>();
        if(player.dir.x < 0)
        {
            bulletRangeClone.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            bulletRangeClone.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.SetParent(null);

        bulletRangeClone.transform.SetParent(null);

        Instantiate(bullet, puntoMira.position, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(1f);
        Destroy(bulletRangeClone);
        balaGenerada = false;

    }
}
