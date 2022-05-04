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
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quitting");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        //loading level 1
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
        //lodaing level 2
    }

    /*private void Update()
    {
        bestTime1.text = timer.instance.bestTime1.ToString();
    }*/

}
