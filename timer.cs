using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    private static timer _instance;
    //turning the timer into an instance so it can be accessed by other scripts easily

    public float currentTime;
    //the current time
    public float bestTime1;
    //players best time for level 1
    public float bestTime2;

    public TextMeshProUGUI currentTimeText;
    //reference to the timer text
    //public TextMeshProUGUI bestTimeText;
    //reference to the best time text

    public TextMeshProUGUI timeText;

    public Color timerTextColour = Color.black;
    //the colour of the timer text
    
    public float level;
    //the level the player is on

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    //the text displaying the current score
    
    public TextMeshProUGUI bestScoreText;
    //the text displaying the players best score

    public float scoreAmount;
    //the total score the player achieved

    public float pointIncreasePerSecond;
    //the amount the score increases per second

    //public float scoreDivider = 0.5f;
    //the amount the score divides per 15 seconds

    //public float bestScore;


    public static timer instance
    {
        get
        {
            return _instance;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        //setting the current time to 0 when the game is started
        //bestTime1 = PlayerPrefs.GetFloat("time_1", 0);
        //bestTime2 = PlayerPrefs.GetFloat("time_2", 0);

        scoreAmount = 10000;
        pointIncreasePerSecond = 40;
        bestScoreText.text = PlayerPrefs.GetFloat("score_1").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        //making the time time increase every second
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //allows for the easy conversion from seconds to minutes
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
        //defines how the time will be displayed

        timeText.text = time.ToString(@"mm\:ss\:ff") + " seconds";
        
        level = game_Manager.instance.GetCurrentLevel();
        //referencing the game manager script and the current level the player is on

        /*if (currentTime >= bestTime1)
        {
            PlayerPrefs.SetFloat("time_1", currentTime);
        }
        else if (currentTime >= bestTime2)
        {
            PlayerPrefs.SetFloat("time_2", currentTime);
        }*/
        
        scoreAmount -= pointIncreasePerSecond * Time.deltaTime;
        scoreText.text = "Score: " + (int)scoreAmount;
        
        if (scoreAmount > PlayerPrefs.GetFloat("score_1"))
        {
            PlayerPrefs.SetFloat("score_1", (int)scoreAmount);
            bestScoreText.text = scoreAmount.ToString();
        } 

        LevelTime();

          
    }

    public float GetCurrentTime()
    {
        return currentTime; //returning the current time
    }

    /*public void SaveTime()
    {
        if (currentTime >= bestTime1)
        {
            PlayerPrefs.SetFloat("time_1", currentTime);
        }
        else if (currentTime >= bestTime2)
        {
            PlayerPrefs.SetFloat("time_2", currentTime);
        }

        LevelTime();
    }*/
    //this needs sorting out - ask brad

    public void LevelTime()
    {
        /*if (level == 1)
        {
            bestTime1 = PlayerPrefs.GetFloat("time_1", 0);
            bestTimeText.text = bestTime1.ToString();
        }
        //this means if the level the player is on = 1, their best time for level 1 will be displayed 
        else if (level == 2)
        { 
            bestTime2 = PlayerPrefs.GetFloat("time_2", 0);
            bestTimeText.text = bestTime2.ToString();
        }*/
        //this means the same thing, but for level 2
        
        if (level == 1)
        {
            //bestScore = PlayerPrefs.GetFloat("score_1", 0);
            bestScoreText.text = PlayerPrefs.GetFloat("score_1").ToString();
        }
        
    }
    //this needs sorting out

}
