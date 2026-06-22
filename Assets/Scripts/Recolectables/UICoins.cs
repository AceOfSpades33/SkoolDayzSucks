using UnityEngine;
using TMPro;

public class UICoins : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI texto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = playerStats.coins + "/" + playerStats.maxCoins;
    }
}
