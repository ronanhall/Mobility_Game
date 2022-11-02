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

    public void LoadTutorialVoid()
    {
        StartCoroutine(LoadTutorial());
        //calling the coroutine
    }

    public void LoadLevel1Void()
    {
        StartCoroutine(LoadLevel1());
        //calling the coroutine
    }

    public void LoadLevel2Void()
    {
        StartCoroutine(LoadLevel2());
    }

    public void LoadLevel3Void()
    {
        StartCoroutine(LoadLevel3());
    }

    public void LoadLevel4Void()
    {
        StartCoroutine(LoadLevel4());
    }

    public void LoadLevel5Void()
    {
        StartCoroutine(LoadLevel5());
    }

    IEnumerator LoadTutorial()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        
        FindObjectOfType<audio_Manager>().StopPlaying("Menu Music");


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
            FindObjectOfType<audio_Manager>().Play("Tutorial Music");
            //finding the auido manager, and playing the level music

        }
    }

    IEnumerator LoadLevel1()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level 1 Music");
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

    IEnumerator LoadLevel2()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(3);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level 2 Music");
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

    IEnumerator LoadLevel3()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(4);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level 3 Music");
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

    IEnumerator LoadLevel4()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(5);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level 4 Music");
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

    IEnumerator LoadLevel5()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(6);
        //this loads the next scene asynchronously in the background
        //the operation allows the storing and gathring of information about the loading of the scene
        Cursor.lockState = CursorLockMode.Locked;
        //locking cursur to the middle of the screen
        Cursor.visible = false;
        //making the cursur invisible
        FindObjectOfType<audio_Manager>().Play("Level 5 Music");
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
