using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArkanoidGameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public bool gameOver;
    public int bricksNumber;
  //  public GameObject clearLevelTimeline;

    public bool isLevelComplete; // ƒл€ активации анимации победы модели персонажа

    void Start()
    {
        livesText.text = "" + lives;
        scoreText.text = "" + score;
        bricksNumber = GameObject.FindGameObjectsWithTag("ArkanoidBrick").Length;
       // clearLevelTimeline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeLives)
    {
        lives += changeLives;
        if (lives < 0)
        {
            lives = 0;
            gameOver = true;
        }
        livesText.text = "" + lives;
    }

    public void UpdateScore(int changeScore)
    {
        score += changeScore;

        scoreText.text = "" + score;
    }

    public void UpdateBricksNumber()
    {
        bricksNumber--;
        if (bricksNumber == 0)
        {
       //     clearLevelTimeline.SetActive(true);
            isLevelComplete = true;
        }
    }

    public void GameOver()
    {
        //Timeline GameOver
        gameOver = true;
    }
}
