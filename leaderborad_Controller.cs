using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LootLocker.Requests;
//using the site I've set up that keeps track of the leaderboard and scores
using UnityEngine;
using TMPro;

public class leaderborad_Controller : MonoBehaviour
{
    public TMP_InputField memberID;
    //input fields for the players name and score
    
    public TextMeshProUGUI playerScore;
    //text that will display the players score
    
    int leaderboardID = 2878;
    //the ID of the leaderboard online
    
    int maxScores = 5;
    //the maximum amount of scores the leaderboard will display
    
    public TextMeshProUGUI[] Entries;
    //the text objects that will become the leaderboard
    
    public timer timer;
    //private float scoreAmount;

    private void Start()
    {
       // StartCoroutine(SetUpRoutine());
       
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");   
            }
            else
            {
                Debug.Log("Failed");
            }
        });
        //logging the player into the session so they are able to submit and view scores

        playerScore.text = (Mathf.FloorToInt(timer.scoreAmount)).ToString();
        //turning the playerScore text into the scoreAmount the player just attained
        memberID.characterLimit = 8;
        //setting the limit to players name to 8 characters
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(memberID.text, int.Parse(playerScore.text), leaderboardID, (response) =>
        {
            //the code above is submitting the players name and their score amount to the specific leaderboardID
            if (response.success)
            {
                Debug.Log("Success");

            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(leaderboardID, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ". " + scores[i].member_id + ":   " + scores[i].score);
                    //displaying the leaderboard text as rank, player name and their score
                }

                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ". none";
                    }
                } //if there is less than 5 scores submitted, it will read "rank. none"

            }
            else
            {
                Debug.Log("Failed");

            }
        });
    }
}
