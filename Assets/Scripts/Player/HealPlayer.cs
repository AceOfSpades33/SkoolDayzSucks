using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Player player;
    [SerializeField] private float colddonw;
    [SerializeField] private float colddnowTime = 10f;
    [SerializeField] private ManageAnimations animations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        colddonw = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        colddonw = Time.time;
        TryHeal();
    }

    void TryHeal()
    {
        if(player.c.Player.Heal.IsPressed() && colddnowTime < colddonw)
        {
            StartCoroutine(Heal());
            colddnowTime = Time.time + 10;
        }
    }

    IEnumerator Heal()
    {
        if(playerStats.currentHealth < playerStats.maxHealth - 10)
        {
            playerStats.SetHealth(playerStats.currentHealth + 10);
            player.c.Disable();
            animations.anim.SetTrigger("healing");
            yield return new WaitForSeconds(3.2f);
            player.c.Enable();
        }
    }
}
