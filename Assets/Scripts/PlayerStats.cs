using System.Runtime.Serialization;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] public float speed =  5;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damage = 10;

    void Awake()
    {
        currentHealth = maxHealth;
    }
}
