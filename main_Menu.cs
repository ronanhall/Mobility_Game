using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //loading the next scene in the queue
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<music_Manager>().Play("Tutorial Music");
        //finding the auido manager, and playing the level music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
        //quiting the game
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
        //loading level 1
        FindObjectOfType<music_Manager>().Play("Tutorial Music");
        //finding the auido manager, and playing the tutorial music
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
        //lodaing level 1
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 1 Music");
        //finding the auido manager, and playing the level 1 music
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
        //lodaing level 2
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 2 Music");
        //finding the auido manager, and playing the level 1 music
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
        //lodaing level 3
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 3 Music");
        //finding the auido manager, and playing the level 3 music
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
        //lodaing level 4
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
        FindObjectOfType<music_Manager>().Play("Level 4 Music");
        //finding the auido manager, and playing the level 4 music
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(6);
        //lodaing level 5
        FindObjectOfType<music_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void MenuConfirmSound()
    {
        FindObjectOfType<audio_Manager>().Play("Menu Confirm");
        //playing the menu confirm sound
    }

    public void MenuBackSound()
    {
        FindObjectOfType<audio_Manager>().Play("Menu Back");
        //playing the menu back sound
    }
}
