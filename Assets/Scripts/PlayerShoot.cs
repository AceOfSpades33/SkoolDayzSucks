using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject bullet;
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
        GameObject bulletClone = Instantiate(bullet, this.transform.position, Quaternion.identity, this.transform);
        yield return new WaitForSeconds(3f);
        Destroy(bulletClone);
        balaGenerada = false;

    }
}
