using System.Collections;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    [SerializeField] public int balasNum;
    [SerializeField] private Player player;
    [SerializeField] private ManageAnimations animations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        balasNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (balasNum >= 30)
        {
            StartCoroutine(Recargar());
        }
    }

    private IEnumerator Recargar()
    {
        balasNum = 0;
        player.c.Disable();
        animations.anim.SetTrigger("recharge");
        yield return new WaitForSeconds(1.1f);
        player.c.Enable();
    }
}
