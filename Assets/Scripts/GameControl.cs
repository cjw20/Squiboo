using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    public int remainingLives;
    public int score;
    
    

    [SerializeField] Text scoreText;
    [SerializeField] Text lifeText;
    [SerializeField] Text timeText;
    [SerializeField] GameObject gameOverScreen;

    public static GameControl control;

    void Awake()
    {
        if (control == null)
        {
            //DontDestroyOnLoad(gameObject);  //makes sure there is only one game control in scene. 
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateLives(0);
        UpdateScore(0);
        UpdateTime(0);
    }


    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateLives(int amount)
    {
        remainingLives += amount;
        lifeText.text = "Remaining Lives: " + remainingLives.ToString();

        if(remainingLives <= 0)
        {
            GameOver();
        }
    }

    public void UpdateTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        if(seconds >= 10)
        {
            timeText.text = "Elapsed Time: " + minutes.ToString() + ":" + seconds.ToString();
        }
        else
        {
            timeText.text = "Elapsed Time: " + minutes.ToString() + ":0" + seconds.ToString();
        }
        
    }

    void GameOver()
    {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
