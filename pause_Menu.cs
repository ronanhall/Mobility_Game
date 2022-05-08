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
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false); 
        //disables the gameobject
        gameIsPaused = false;
        Time.timeScale = 1f; 
        //setting the time back to passing at normal speed
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().TurnUp();
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true); 
        //enables the gameobject
        Time.timeScale = 0f; 
        //this is the speed at which time is passing, and because it is set to 0, time is frozen
        gameIsPaused = true;
        player.GetComponent<player_Look>().enabled = false;
        player.GetComponent<player_Movement>().enabled = false;
        gun.GetComponent<bounce_Pad_Gun>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        //unlocking cursur from the middle of the screen
        Cursor.visible = true;
        //making the cursur visible
        FindObjectOfType<audio_Manager>().TurnDown();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quitting");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        FindObjectOfType<audio_Manager>().StopPlaying("Level Music");
        //finding the audio manager, and stopping the level music
        FindObjectOfType<audio_Manager>().Play("Menu Music");
        //finding the auido manager, and playing the menu music
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameIsPaused = false;
        Time.timeScale = 1f;
        //setting the time back to passing at normal speed
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
    }
}
