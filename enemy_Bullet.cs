using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemy_Bullet : MonoBehaviour
{
    GameObject target; 
    //the target that the bullet will fly towards
    public float bulletSpeed; 
    //the speed/force that will be applied to the bullet when it fires
    Rigidbody bulletRB;
    //a reference to the Rigidbody that is on the bullet
    

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>(); 
        //accessing the RigidBody2D on the bullet
        target = GameObject.FindGameObjectWithTag("Player Head");
        //the code above makes the target a gameobject with the tag of "Player"
        Vector3 moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        bulletRB.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        //the code above calculates the players position and then fires the bullet, with it moving towards
        //that calculated direction
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Head"))
        //the code above is making sure that the trigger is only called when an object
        //of the tag "Player" collides with it 
        {
            Debug.Log("collides with player");
            Destroy(gameObject);
            //destroys the object when it collides with the player, and printing out "collides with player"
            //so it is easy to check if it actually collides with the player
        }
        else if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            //destroying the game object when it collides with a wall or the ground
        }        
    }
}
