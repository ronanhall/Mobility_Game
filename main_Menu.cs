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
        //FindObjectOfType<audio_Manager>().Play("Level Music");
        //finding the auido manager, and playing the level music
        //FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
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
        //FindObjectOfType<audio_Manager>().Play("Level Music");
        //finding the auido manager, and playing the level music
        //FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
        //lodaing level 2
    }

    /*private void Update()
    {
        bestTime1.text = timer.instance.bestTime1.ToString();
    }*/

}
