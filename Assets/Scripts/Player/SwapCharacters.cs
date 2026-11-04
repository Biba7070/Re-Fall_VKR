using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwapCharacters : MonoBehaviour
{
    public Transform character;
    public int whichCharacter;
    public List<Transform> listOfTheCharacters;
    [Header("Later change")]
    /*--------------Позже изменить------------*/
    public CinemachineFreeLook CameraPers1;
    public CinemachineFreeLook CameraPers2;
   // public CinemachineVirtualCamera CameraPers3;
    [SerializeField] private WalkForPlayer scriptmovingChar1;
    [SerializeField] private WalkForPlayer scriptmovingChar2;
    //[SerializeField] private WalkForPlayer scriptmovingChar3;
    /*--------------Позже изменить------------*/


    void Start()
    {
        if (character == null && listOfTheCharacters.Count >= 1)
        {
            character = listOfTheCharacters[0];
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (ActivateAiming.aimingActive == false)
        {
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
            }
        }*/
    
        /*-------------Позже изменить--------------*/
        if(scriptmovingChar1.enabled == true && scriptmovingChar2.enabled == false)
        {
            CameraPers1.Priority = 1;
            CameraPers2.Priority = 0;
           // CameraPers3.Priority = 0;
        }
        else if (scriptmovingChar1.enabled == false && scriptmovingChar2.enabled == true)
        {
            CameraPers1.Priority = 0;
            CameraPers2.Priority = 1;
            //CameraPers3.Priority = 0;
        }
       /* else if(scriptmovingChar1.enabled == false && scriptmovingChar2.enabled == false && scriptmovingChar3.enabled == true)
        {
            CameraPers1.Priority = 0;
            CameraPers2.Priority = 0;
            CameraPers3.Priority = 1;
        }
        /*----------------Позже изменить-----------*/
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
