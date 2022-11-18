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
    public TextMeshProUGUI currentTimeText;
    //reference to the timer text
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
    public bool timerStart;
    //bool to check if the timer has started


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
        scoreAmount = 10000;
        //setting the score at each level to 1000
        pointIncreasePerSecond = 40;
        //the amount the score will decrease per second
        //bestScoreText.text = PlayerPrefs.GetFloat("score_1").ToString();
        timerStart = false;
        //setting the bool to false
        currentTimeText.text = "00" + ":00" + ":00";
        //setting the timer text to "00: 00: 00" at the start of the game
        currentTimeText.color = Color.red;
        //setting the timer texts colour to red
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart == true)
        {
            currentTime = currentTime + Time.deltaTime;
            //making the time time increase every second
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            //allows for the easy conversion from seconds to minutes
            currentTimeText.text = time.ToString(@"mm\:ss\:ff");
            //defines how the time will be displayed
            currentTimeText.color = Color.white;
            //setting the timer texts colour to white
            timeText.text = time.ToString(@"mm\:ss\:ff");
            //formatting the timer text  
        }
        
        scoreAmount -= pointIncreasePerSecond * Time.deltaTime;
        //subracting the pointIncreasePerSecond from the score amount
        scoreText.text = "Score: " + (int)scoreAmount;
        //setting the socre text to "Score" + the score amount
    }

    public float GetCurrentTime()
    {
        return currentTime; //returning the current time
    }

    public void StartTimer()
    {
        timerStart = true;
        //setting the bool to true
    }

}
