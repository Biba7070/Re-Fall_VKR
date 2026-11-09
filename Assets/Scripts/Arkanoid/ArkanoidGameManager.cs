using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArkanoidGameManager : MonoBehaviour
{
    public int lives, score, bricksNumber;
    public TextMeshProUGUI livesText, scoreText;
    public bool gameOver;
    public GameObject gameOverScreen;

    public bool isLevelComplete; // ƒл€ активации анимации победы модели персонажа

    void Start()
    {
        livesText.text = "" + lives;
        scoreText.text = "" + score;
        bricksNumber = GameObject.FindGameObjectsWithTag("ArkanoidBrick").Length;
        gameOverScreen.SetActive(false);
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
            GameOver();
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
            GameOver();
            isLevelComplete = true;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOver = true;
    }
}
