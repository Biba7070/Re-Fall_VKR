using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    public GameObject camStartActive, camChange;
    // Start is called before the first frame update
    void Start()
    {
        camStartActive.SetActive(true);
        camChange.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        camStartActive.SetActive(false);
        camChange.SetActive(true);
    }
}
