using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevelName : MonoBehaviour
{
    public GameObject LvlText;

    void Start()
    {
        LvlText.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            LvlText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        LvlText.SetActive(false);
    }
}
