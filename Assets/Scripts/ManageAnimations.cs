using UnityEngine;

public class ManageAnimations : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] private Player player;

    void Update()
    {
        if (player.dir.x < 0 && player.falling == false || player.dir.x > 0 && player.falling == false)
        {
            anim.SetFloat("dir", 1);
        }
        else
        {
            anim.SetFloat("dir", -1);
        }

        if (player.falling == true)
        {
            anim.SetBool("falling", true);
        }
        else
        {
            anim.SetBool("falling", false);
        }
    }


}
