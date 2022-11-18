using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class level_Transition_Win : MonoBehaviour
{
    public static bool levelIsFinished = false;
    //bool tracking if the level is finished
    public GameObject leaderboardUI;
    //reference to the leaderboard UI
    public GameObject onScreenUI;
    //reference to the onscreen UI    
    public GameObject player;
    //reference to the player
    public GameObject gun;
    //reference to the bounce pad gun
    public GameObject boostController;
    //reference to the boost controller
   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FinishLevel();
            FindObjectOfType<music_Manager>().Play("Menu Music");
            //finding the auido manager, and playing the menu music
            FindObjectOfType<music_Manager>().StopPlaying("Level 1 Music");
            //finding the audio manager, and stopping the level
            FindObjectOfType<music_Manager>().StopPlaying("Level 2 Music");
            //finding the audio manager, and stopping the level music
            FindObjectOfType<music_Manager>().StopPlaying("Level 3 Music");
            //finding the audio manager, and stopping the level music
            FindObjectOfType<music_Manager>().StopPlaying("Level 4 Music");
            //finding the audio manager, and stopping the level music
            FindObjectOfType<music_Manager>().StopPlaying("Level 5 Music");
            //finding the audio manager, and stopping the level music
            FindObjectOfType<audio_Manager>().Play("Finish Level");
            //finding the auido manager, and playing the finish level sound effect
        }
    }

    public void FinishLevel()
    {
        leaderboardUI.SetActive(true);
        //setting the leaderboard UI to active
        onScreenUI.SetActive(false);
        //deactivating the onscreen UI
        Time.timeScale = 0f;
        //pausing time
        player.GetComponent<player_Look>().enabled = false;
        player.GetComponent<player_Movement>().enabled = false;
        gun.GetComponent<bounce_Pad_Gun>().enabled = false;
        //truning all these player components off
        Cursor.lockState = CursorLockMode.None;
        //unlocking cursur from the middle of the screen
        Cursor.visible = true;
        //making the cursur visible
        levelIsFinished = true;
        //setting the bool to true
        boostController.gameObject.SetActive(false);
        //deactivating the boost controller
    }

    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 2 Music");
        //finding the audio manager, and stopping the level music
    }

    public void Level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 3 Music");
        //finding the audio manager, and stopping the level music
    }

    public void Level4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 4 Music");
        //finding the audio manager, and stopping the level music
    }

    public void Level5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 5 Music");
        //finding the audio manager, and stopping the level music
    }

    public void OutroCutscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //loading the next level
        Time.timeScale = 1f;
        //turning time back on
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void RetryLevel1()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().Play("Level 1 Music");
        //finding the audio manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void RetryLevel2()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().Play("Level 2 Music");
        //finding the audio manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void RetryLevel3()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().Play("Level 3 Music");
        //finding the audio manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void RetryLevel4()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().Play("Level 4 Music");
        //finding the audio manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void RetryLevel5()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
        Time.timeScale = 1f;
        player.GetComponent<player_Look>().enabled = true;
        player.GetComponent<player_Movement>().enabled = true;
        gun.GetComponent<bounce_Pad_Gun>().enabled = true;
        //turning all these player components on
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursor visible
        FindObjectOfType<music_Manager>().Play("Level 5 Music");
        //finding the audio manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the sudio manager, and stopping the menu music
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //loading scene 0, which is the main menu
        Time.timeScale = 1f;
        //resuming time
    }

    
}
