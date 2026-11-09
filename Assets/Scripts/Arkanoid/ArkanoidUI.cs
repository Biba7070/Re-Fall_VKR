using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArkanoidUI : MonoBehaviour
{
    public GameObject titleScreen, chooseCharacterScreen, topScreen,  GirlPilot, BoyPilot;

    [SerializeField] private BallBalling ballBalling;
    [SerializeField] private ArkanoidControl arkanoidControl;

    [Header("-------------------------")]
    public GameObject MainCam, girlMenuCam, boyMenuCam;



    void Start()
    {
        OpenTitleScreen();
        ballBalling.enabled = false;
        arkanoidControl.enabled = false;
    }

    public void OpenTitleScreen()
    {
        titleScreen.SetActive(true);
        GirlPilot.SetActive(false);
        chooseCharacterScreen.SetActive(false);
        topScreen.SetActive(false);
        BoyPilot.SetActive(false);
        MainCam.SetActive(true);
        girlMenuCam.SetActive(false);
        boyMenuCam.SetActive(false);
    }

    public void OpenChooseCharacterScreen()
    {
        titleScreen.SetActive(false);
        chooseCharacterScreen.SetActive(true);
        girlMenuCam.SetActive(true);
    }

    public void ShowGirlPilotInMenu()
    {
        girlMenuCam.SetActive(true);
        boyMenuCam.SetActive(false);
    }

    public void ShowBoyPilotInMenu()
    {
        girlMenuCam.SetActive(false);
        boyMenuCam.SetActive(true);
    }

    public void ChoosePilotGirl()
    {
        GirlPilot.SetActive(true);
        BoyPilot.SetActive(false);
        chooseCharacterScreen.SetActive(false);
        MainCam.SetActive(true);
        girlMenuCam.SetActive(false);
        boyMenuCam.SetActive(false);
        ActivateBallAndControl();
    }

    public void ChoosePilotBoy()
    {
        GirlPilot.SetActive(false);
        BoyPilot.SetActive(true);
        chooseCharacterScreen.SetActive(false);
        MainCam.SetActive(true);
        girlMenuCam.SetActive(false);
        boyMenuCam.SetActive(false);
        ActivateBallAndControl();
    }

    public void ActivateBallAndControl()
    {
        ballBalling.enabled = true;
        arkanoidControl.enabled = true;
        topScreen.SetActive(true);
    }

    public void QuitToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}
