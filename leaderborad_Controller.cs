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

    int leaderboardID = 2878;
    //the ID of the leaderboard online

    int maxScores = 5;

    public TextMeshProUGUI[] Entries;

    private void Start()
    {
       // StartCoroutine(SetUpRoutine());
       
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                //PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                //getting the players name from their PlayerPref
                Debug.Log("Success");
                
            }
            else
            {
                Debug.Log("Failed");
                
            }
        });

        playerScore.text = PlayerPrefs.GetFloat("time_1", 0).ToString();
        //turning the playerScore text in the input field to the saved score for level 1 in PlayerPrefs
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(memberID.text, int.Parse(playerScore.text), leaderboardID, (response) =>
        {
            if (response.success)
            {
                //PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                //getting the players name from their PlayerPref
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
                }

                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ". none";
                    }
                }

            }
            else
            {
                Debug.Log("Failed");

            }
        });
    }

    /*IEnumerator SetUpRoutine()
    {
        yield return PlayerLogin();
        yield return GetTopHighScores();
    }

    IEnumerator PlayerLogin()
    {
        bool done = false;
        //checking if the call to the server is complete
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                //getting the players name from their PlayerPref
                Debug.Log("Success");
                done = true;
            }
            else
            {
                Debug.Log("Failed");
                done = true;
            }
        });
        //this is authenticating if a player is playing the game, and tracking whether it was successful or not
        yield return new WaitWhile(() => done == false); 
    }

    //things to do: make the leaderboard save a score when hitting the end of the level
    //have the players best time be the score, convert it into a float

    public IEnumerator SubmitScore(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (respone) =>
        {
            if (respone.success)
            {
                Debug.Log("success");
                done = true;
            }
            else
            {
                Debug.Log("failed");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator GetTopHighScores()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboardID, 5, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != " ")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("failed");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }*/

}
