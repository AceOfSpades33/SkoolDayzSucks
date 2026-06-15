using UnityEngine;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField] public int coinsNumberVar = 0;

    void Awake()
    {
        coinsNumberVar = this.gameObject.transform.childCount;
    }
}
