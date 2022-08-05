using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youko : MonoBehaviour
{
    public GameObject NPC14;

    void OnTriggerEnter(Collider collider)
    {
        NPC14.GetComponentInChildren<Conversation14>().HasVisitedRed = true;
    }
}
