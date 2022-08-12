using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    [SerializeField]
    float huntRadius = 10.0f;

    bool hunting = false;

    GameObject player;

    UnityEngine.AI.NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        agent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < huntRadius)
        {
            hunting = true;
        }

        if (hunting)
        {
            agent.destination = player.transform.position;
        }
    }
}
