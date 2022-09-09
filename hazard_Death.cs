using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hazard_Death : MonoBehaviour
{
    
    void Die()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        //reloading the current scene
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                FindObjectOfType<audio_Manager>().Play("Player Fail");
                Die();
                break;
         //when the player collides with this object, they will die (restart the scene)
        }
    }
}
