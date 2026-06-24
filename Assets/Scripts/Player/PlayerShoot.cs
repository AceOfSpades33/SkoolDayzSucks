using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BulletCounter contador;
    [SerializeField] private GameObject bulletRange;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletAr;
    [SerializeField] private GameObject bulletAb;
    [SerializeField] private Transform puntoMira;
    [SerializeField] private Transform puntoDiagonalArriba;
    [SerializeField] private Transform puntoDiagonalAbajo;
    [SerializeField] private AudioSource audioSource;
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
        contador.balasNum = contador.balasNum + 1;
        StartCoroutine(BulletLife());
    }

    IEnumerator BulletLife()
    {
        balaGenerada = true;
        audioSource.Play();
        GameObject bulletRangeClone = Instantiate(bulletRange, this.transform.position, Quaternion.identity, this.transform);
        Player player = GetComponentInParent<Player>();
        if (player.dir.x < 0)
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
        Instantiate(bulletAr, puntoDiagonalArriba.position, bulletAr.gameObject.transform.localRotation, this.transform);
        Instantiate(bulletAb, puntoDiagonalAbajo.position, bulletAb.gameObject.transform.localRotation, this.transform);

        yield return new WaitForSeconds(0.5f);
        Destroy(bulletRangeClone);
        balaGenerada = false;
    }
}
