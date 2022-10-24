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
        FindObjectOfType<audio_Manager>().Play("Tutorial Music");
        //finding the auido manager, and playing the level music
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
        //loading level 1
        FindObjectOfType<audio_Manager>().Play("Tutorial Music");
        //finding the auido manager, and playing the level music
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
        //lodaing level 1
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
        //lodaing level 2
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
        //lodaing level 3
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
        //lodaing level 4
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(6);
        //lodaing level 5
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
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
