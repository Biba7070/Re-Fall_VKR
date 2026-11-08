using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Arcade : MonoBehaviour
{
    public GameObject ButtonToPress;
    bool isInTrigger;
    public string sceneName; //Название сцены

    void Start()
    {
        ButtonToPress.SetActive(false);
    }

    void Update()
    {
        if (isInTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(sceneName);
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
