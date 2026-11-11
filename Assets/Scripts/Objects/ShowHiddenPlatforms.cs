using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenPlatforms : MonoBehaviour
{
    public GameObject ButtonToPress, Platforms;
    bool isInTrigger;

    void Start()
    {
        ButtonToPress.SetActive(false);
        Platforms.SetActive(false);
    }

    void Update()
    {
        if (isInTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            Platforms.SetActive(true);
            ButtonToPress.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider) // При входе персонажа с типом "Player" в зону триггера, сцена меняется на сцену, заданную в параметре sceneName
    {
        if (collider.gameObject.tag == "Player")
        {
            ButtonToPress.SetActive(true);
            isInTrigger = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        ButtonToPress.SetActive(false);
        isInTrigger = false;
    }
}
