using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public int score;
    public int targetScore = 100;
    public Text scoreText;
    public Text timeText;
    public int timePerLevel = 120;
    public GameObject youWon;
    public GameObject gameOver;
    public GameObject titleScreen;
    public Sprite[] lives;
    public Image livesImageDisplay;


    private float clockSpeed = 1f;
    [SerializeField]
    private GameObject credits;


    void Awake()
    {
        scoreText.text = score.ToString();


    }

    public void StartClock()
    {
        InvokeRepeating("Clock", 0, clockSpeed);
    }

    void Clock()
    {
        timePerLevel--;
        timeText.text = (timePerLevel.ToString());
        if (timePerLevel == 0)
        {
            CheckGameOver(1);
        }
    }

    public void AddPoints(int pointsScored)
    {
        score += pointsScored;
        scoreText.text = score.ToString();

    }

    public void CheckGameOver(int lives)
    {
        if (score >= targetScore && lives > 0)
        {
            Time.timeScale = 0;
            youWon.SetActive(true);
            credits.SetActive(true);

            
        }
        else
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            credits.SetActive(true);


        }
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
       
    }
}
