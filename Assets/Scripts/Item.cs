using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    float spinSpeed = 10.0f;

    [Tooltip("Pickup item simply by walking over it")]
    [SerializeField]
    bool autoPickup = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, spinSpeed * Time.deltaTime, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player has walked over the item, add it
        if (autoPickup && other.tag == "Player")
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();

            if (inventory != null)
            {
                inventory.Add(this);
                Destroy(this);
            }
        }
    }
}
