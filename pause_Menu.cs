using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_Menu : MonoBehaviour
{

    public static bool gameIsPaused = false; 
    //this variable keeps track of whether or not the game is paused

    public GameObject pauseMenuUi; 
    //this is a public reference for our pause menu

    public GameObject player;
    //a public reference for the player

    public GameObject gun;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        }

        //restart button code
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false); //disables the gameobject
        gameIsPaused = false;
        Time.timeScale = 1f; //setting the time back to passing at normal speed
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true); //enables the gameobject
        Time.timeScale = 0f; //this is the speed at which time is passing, and because it is set to 0, time is frozen
        gameIsPaused = true;
        player.GetComponent<player_Look>().enabled = false;
        player.GetComponent<player_Movement>().enabled = false;
        gun.GetComponent<bounce_Pad_Gun>().enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitting");
    }
}
