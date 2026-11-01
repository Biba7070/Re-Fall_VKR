using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Для смены сцен

public class MainMenu : MonoBehaviour
{
    public GameObject NewLoadMenuCanvas, OptionsMenuCanvas, QuitMenuCanvas;

    public void Start()
    {
        ShowMainMenuCanvas(); //Все окна меню, кроме главного, деактивируются 
    }

    public void ShowMainMenuCanvas() //Скрывает все окна, кроме главного
    {
        OptionsMenuCanvas.SetActive(false);
        QuitMenuCanvas.SetActive(false);
        NewLoadMenuCanvas.SetActive(false);
    }

    public void ShowNewLoadMenuCanvas() //Открывает меню для новой игры и загрузки
    {
        NewLoadMenuCanvas.SetActive(true);
    }

    public void ShowOptionsMenuCanvas() //Показывает меню "Настройки"
    {
        OptionsMenuCanvas.SetActive(true);
    }

    public void ShowQuitMenuCanvas() //Показывает окно выхода из игры
    {
        QuitMenuCanvas.SetActive(true);
    }

    public void CloseGame() //Функция, с помощью которой игра закрывается
    {
        Application.Quit();
    }
}
