using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject primaryRound;
    [SerializeField]
    GameObject secondaryRound;

    [SerializeField]
    int primaryAmmo = 10;
    [SerializeField]
    int secondaryAmmo = 10;

    [SerializeField]
    Vector3 primaryFirePoint;
    [SerializeField]
    Vector3 secondaryFirePoint;

    public void PrimaryFire()
    {
        if (primaryAmmo > 0)
            Instantiate(primaryRound, primaryFirePoint, this.transform.rotation);
    }

    public void SecondaryFire()
    {
        if (secondaryAmmo > 0)
            Instantiate(secondaryRound, secondaryFirePoint, this.transform.rotation);
    }
}
