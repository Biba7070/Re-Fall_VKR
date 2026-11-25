using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesNumberUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateLivesNumber(PlayerInventory playerInventory)
    {
        livesText.text = playerInventory.livesNumber.ToString();
    }
}
