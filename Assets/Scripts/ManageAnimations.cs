using UnityEngine;

public class ManageAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Player player;

    void Update()
    {
        if(player.dir.x < 0 || player.dir.x > 0)
        {
            anim.SetFloat("dir", 1);
        }
        else
        {
            anim.SetFloat("dir", -1);
        }
    }


}
