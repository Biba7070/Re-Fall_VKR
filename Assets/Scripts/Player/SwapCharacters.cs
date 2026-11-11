using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwapCharacters : MonoBehaviour
{
    public Transform character;
    public int whichCharacter;
    public List<Transform> listOfTheCharacters;
    public CinemachineFreeLook ResCamera;
    public CinemachineFreeLook CurioCamera;
    public CinemachineFreeLook SkepCamera;
    [SerializeField] private WalkForPlayer ResScript;
    [SerializeField] private WalkForPlayer CurioScript;
    [SerializeField] private WalkForPlayer SkepScript;
    public static bool isResActive;


    void Start()
    {
        if (character == null && listOfTheCharacters.Count >= 1)
        {
            character = listOfTheCharacters[0];
        }
        Swap();
    }


    void Update()
    {
       /* if (ActivateAiming.aimingActive == false)
        {*/
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (whichCharacter == 0)
                {
                    whichCharacter = listOfTheCharacters.Count - 1;
                }
                else
                {
                    whichCharacter -= 1;
                }
                Swap();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (whichCharacter == listOfTheCharacters.Count - 1)
                {
                    whichCharacter = 0;
                }
                else
                {
                    whichCharacter += 1;
                }
                Swap();
          /*  }*/
             }

        /*-------------Смена активной камеры--------------*/
        if (ResScript.enabled == true && CurioScript.enabled == false && SkepScript.enabled == false)
        {
            ResCamera.Priority = 1;
            isResActive = true;
            CurioCamera.Priority = 0;
            SkepCamera.Priority = 0;
        }
        else if (ResScript.enabled == false && CurioScript.enabled == true && SkepScript.enabled == false)
        {
            ResCamera.Priority = 0;
            isResActive = false;
            CurioCamera.Priority = 1;
            SkepCamera.Priority = 0;
        }
        else if (ResScript.enabled == false && CurioScript.enabled == false && SkepScript.enabled == true)
        {
            ResCamera.Priority = 0;
            isResActive = false;
            CurioCamera.Priority = 0;
            SkepCamera.Priority = 1;
        }

    }
    public void Swap()
    {
        character = listOfTheCharacters[whichCharacter];
        character.GetComponent<WalkForPlayer>().enabled = true;
        for (int i = 0; i < listOfTheCharacters.Count; i++)
        {
            if (listOfTheCharacters[i] != character)              //Отключает неактивным персонажам управление
            {
                listOfTheCharacters[i].GetComponent<WalkForPlayer>().enabled = false;
            }
        }
    }
}
