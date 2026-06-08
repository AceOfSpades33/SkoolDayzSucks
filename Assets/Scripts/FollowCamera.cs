using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.gameObject.transform.position + new Vector3(0,0,-10);
    }
}
