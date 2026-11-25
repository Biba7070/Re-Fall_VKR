using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

     public TextMeshProUGUI capText;
   
    void Start()
    {
        capText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCapText(PlayerInventory playerInventory)
    {
        capText.text = playerInventory.capNumber.ToString();
    }
}
