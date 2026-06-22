using UnityEngine;

public class ManageBossAnimations : MonoBehaviour
{
    [SerializeField] private BossMovements boss;
    [SerializeField] private EnemyStats stats;
    [SerializeField] public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss.dir.x < 0 || boss.dir.x > 0)
        {
            anim.SetFloat("dir", 1);
        }
        else
        {
            anim.SetFloat("dir", -1);
        }

        if(boss.muerto)
        {
            anim.SetFloat("dir", -1);
            anim.SetTrigger("die");
        }

        if(boss.atacando)
        {
            anim.SetTrigger("atack");
        }
    }
}
