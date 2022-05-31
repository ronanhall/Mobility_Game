using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class level_Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    //reference to the loading screen game object
    public Slider slider;
    //reference to the slider
    public TextMeshProUGUI progressText;
    //reference to the progress text

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynch());
        //calling the coroutine
    }

    IEnumerator LoadAsynch()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level Music");
        //finding the auido manager, and playing the level music
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");
        //finding the audio manager, and stopping the menu music

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //making the progress value go from 0.9 to 1
            loadingScreen.SetActive(true);
            //making the loading screen active
            slider.value = progress;
            //making the sliders value the progress of loading the next level
            progressText.text = progress * 100f + "%";
            yield return null;
            //waits one frame after every message
        }
    }
}
