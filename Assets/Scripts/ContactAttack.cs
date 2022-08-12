using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
    [SerializeField]
    float damage = 5.0f;

    void OnCollisionEnter(Collider other)
    {
        HealthStats stats = other.gameObject.GetComponent<HealthStats>();

        if (stats != null)
        {
            stats.Damage(damage);
        }
    }
}
