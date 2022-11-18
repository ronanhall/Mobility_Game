using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_Manager : MonoBehaviour
{
    private static game_Manager _instance;
    //creating aninstance
    public float currentLevel;
    //the current level the player is on
    public float sensX = 50f;
    //the default sensitivity of the camera on the x axis
    public float sensY = 50f;
    //the default sensitivity of the camera on the x axis

    public static game_Manager instance
    {
        get
        {
            return _instance;
        }
        //returning a _instance
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }
    }
    //the code above is making sure whatever gameobject this script is attatched to isn't destroyed when the scene loads
    //or a new scene is loaded. However if there is another gameobject in the scene, the code will
    //destroy the one that hasn't had its instance set, therefore there is always only one

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        //getting the active scene
        currentLevel = scene.buildIndex;
        //making the currentLevel float the build index number of the current scene
    }

    public float GetCurrentLevel()
    {
        return currentLevel;
        //returns the build index number of the current scene
    }
}
