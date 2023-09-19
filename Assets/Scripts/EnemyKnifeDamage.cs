using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnifeDamage : MonoBehaviour
{
    public int currentHealth;

    public int maxHealth;
    public int CurrentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }


    void Die()
    {
        // Handle enemy death.
        Destroy(gameObject);
    }
}
