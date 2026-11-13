using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public GameObject ButtonToPress, objectToShow;
    bool isInTrigger;

    void Start()
    {
        ButtonToPress.SetActive(false);
        objectToShow.SetActive(false);
    }

    void Update()
    {
        if (isInTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            objectToShow.SetActive(true);
            ButtonToPress.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider) // При входе персонажа с типом "Player" в зону триггера, сцена меняется на сцену, заданную в параметре sceneName
    {
            ButtonToPress.SetActive(true);
            isInTrigger = true;
    }

    void OnTriggerExit(Collider collider)
    {
        ButtonToPress.SetActive(false);
        isInTrigger = false;
    }
}
