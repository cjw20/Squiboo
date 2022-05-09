using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public int remainingLifes;
    public int score;

    [SerializeField] Text scoreText;
    [SerializeField] Text lifeText;
    [SerializeField] Text timeText;

    public static GameControl control;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);  //makes sure there is only one game control in scene. 
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateLifes(0);
        UpdateScore(0);
        UpdateTime(0);
    }


    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateLifes(int amount)
    {
        remainingLifes += amount;
        lifeText.text = "Remaining Lifes: " + remainingLifes.ToString();
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
}
