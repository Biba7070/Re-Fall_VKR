using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CapsNumberUI : MonoBehaviour
{

    private TextMeshProUGUI capText;
    // Start is called before the first frame update
    void Start()
    {
        capText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCapText(PlayerInventory playerInventory)
    {
        capText.text = playerInventory.capNumber.ToString();
    }
}
