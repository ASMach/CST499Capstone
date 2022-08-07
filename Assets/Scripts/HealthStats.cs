using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0f;

    float health;

    public float Health {
        get => health;
    }

    public void Start() {
        health = maxHealth;
    }


    public void Damage(float damage) {
        health -= damage;
        if (health < 0.0)
        {
            health = 0.0f;
            Die();
        }
    }

    public void Heal(float bonus)
{
    health += bonus;
    if (health > maxHealth)
    {
        health = maxHealth;
    }
}

    void Die()
    {
        Destroy(gameObject);
    }
}
