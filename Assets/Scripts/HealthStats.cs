using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats : MonoBehaviour
{
    [SerializeField]
    GameObject hpText;
    [SerializeField]
    float maxHealth = 100.0f;

    float health;

    public float Health {
        get => health;
    }

    public void Start() {
        health = maxHealth;
        UpdateLabel();
    }

    public void UpdateLabel()
    {
        if (hpText != null)
        {
            TMPro.TextMeshProUGUI txt = hpText.GetComponent<TMPro.TextMeshProUGUI>();
            txt.text = health + " HP";
        }
    }

    public void Damage(float damage) {
        health -= damage;
        if (health < 0.0)
        {
            health = 0.0f;
            Die();
        }
        UpdateLabel();
    }

    public void Heal(float bonus)
    {
        health += bonus;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateLabel();
    }

    void Die()
    {
        UpdateLabel();
        Destroy(gameObject);
    }
}
