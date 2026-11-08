using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    public string sceneName; //Название сцены

    void OnTriggerEnter(Collider collider) // При входе персонажа с типом "Player" в зону триггера, сцена меняется на сцену, заданную в параметре sceneName
    {
        if (collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
