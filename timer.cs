using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class timer : MonoBehaviour
{
    public float currentTime;
    //the current time
    public float bestTime;
    //players best time

    public TextMeshProUGUI currentTimeText;
    //reference to the timer text
    public TextMeshProUGUI bestTimeText;
    //reference to the best time text

    public Color timerTextColour = Color.black;
    //the colour of the timer text

    public static timer _instance;
    //turning the timer into an instance so it can be accessed by other scripts easily

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
        bestTime = PlayerPrefs.GetFloat("Time", 0);
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
        bestTimeText.text = bestTime.ToString();
        
        if (currentTime < bestTime)
        {
            PlayerPrefs.SetFloat("Time", currentTime);
        }
    }

    //public void GetCurrentTime()
    //{
        //return currentTime;
        //returning the current time
        
      //  bestTime = PlayerPrefs.GetFloat("Time", 0);
    //}
}
