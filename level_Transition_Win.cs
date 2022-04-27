using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_Transition_Win : MonoBehaviour
{
    //timer time;
    //[SerializeField] GameObject timer;

    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(2);
            //chage this when needed

            FindObjectOfType<audio_Manager>().Play("Finish Level");
            //

            timer.instance.SaveTime();
            //this needs sorting out
        }
    }

    
}
