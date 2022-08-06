using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject gun;

    public GameObject Gun
    {
        get
        {
            return gun;
        }
        set
        {
            if (value != null)
            {
                gun = Instantiate(value, new Vector3(0.0f, 0.0f, 10.0f), this.transform.rotation);
            }
        }
    }

    void OnPrimaryFire()
    {
        if (gun != null)
            gun.GetComponent<Gun>().PrimaryFire();
    }

    void OnSecondaryFire()
    {
        if (gun != null)
            gun.GetComponent<Gun>().SecondaryFire();
    }
}
