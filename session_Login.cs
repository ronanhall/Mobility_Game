using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class session_Login : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
