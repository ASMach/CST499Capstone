using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]
    GameObject gun;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gun Picked Up");
        Shoot shoot = other.gameObject.GetComponent<Shoot>();
        if (shoot != null)
        {
            Debug.Log("Shoot component found");
            shoot.Gun = gun;
            Destroy(gameObject);
        }
    }
}
