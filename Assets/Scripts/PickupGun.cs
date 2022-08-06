using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    [SerializeField]
    GameObject gun;

    void Update()
    {
        Vector3 nRot = new Vector3(0, 10 * Time.deltaTime, 0);
        transform.eulerAngles = nRot;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gun Picked Up");
        Shoot shoot = other.gameObject.GetComponent<Shoot>();
        if (shoot != null)
        {
            shoot.Gun = gun;
            Destroy(gameObject);
        }
    }
}
