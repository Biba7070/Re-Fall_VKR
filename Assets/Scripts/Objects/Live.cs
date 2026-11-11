using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInvent = other.GetComponent<PlayerInventory>();
        if (playerInvent != null)
        {
            playerInvent.liveCollected();
            gameObject.SetActive(false);
        }
    }
}
