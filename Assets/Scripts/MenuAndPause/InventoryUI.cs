using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    private TextMeshProUGUI capText;
    private TextMeshProUGUI livesText;
   
    void Start()
    {
        capText = GetComponent<TextMeshProUGUI>();
        livesText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCapText(PlayerInventory playerInventory)
    {
        capText.text = playerInventory.capNumber.ToString();
    }

    public void UpdateLivesText(PlayerInventory playerInventory)
    {
        livesText.text = playerInventory.livesNumber.ToString();
    }
}
