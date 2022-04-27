using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_Bullet : MonoBehaviour
{
    GameObject target; 
    //the target that the bullet will fly towards
    public float bulletSpeed; 
    //the speed/force that will be applied to the bullet when it fires
    Rigidbody bulletRB;
    //a reference to the Rigidbody that is on the bullet

    player_Movement pm;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>(); 
        //accessing the RigidBody2D on the bullet
        target = GameObject.FindGameObjectWithTag("Player");
        //the code above makes the target a gameobject with the tag of "Player"
        Vector3 moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        bulletRB.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        //the code above calculates the players position and then fires the bullet, with it moving towards
        //that calculated direction

        //pm = GetComponent<player_Movement>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        //the code above is making sure that the trigger is only called when an object
        //of the tag "Player" collides with it 
        {
            //pm.moveSpeed = 3f;
            Destroy(gameObject);
            Debug.Log("collides with player");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Debug.Log("collides with " + gameObject.tag);
        }
        //the code above destroys the bullet whenever it collides with an object, with it reloading the scene
        //when it collides with a gameobject with the tag of "Player"
    }
}
