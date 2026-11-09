using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInvent = other.GetComponent<PlayerInventory>();
        if (playerInvent != null)
        {
            playerInvent.capCollected();
            gameObject.SetActive(false);
        }
    }
}
