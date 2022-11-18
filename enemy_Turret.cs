using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Turret : MonoBehaviour
{
    private Transform target;
    //the target of the turret

    public GameObject enemyBullet; 
    //the enemy bullet prefab
    public GameObject enemyFirePoint; 
    //the point at which the bullet prefab will be instantiated
    public float shootingRange; 
    //the range at which the enemy will shoot
    public float fireRate = 5; 
    //the amount of times the enemy will fire
    private float nextFireTime;
    //the time the enemy will wait to fire again
    public Transform head;
    //reference to the head of the turret
    public string playerTag = "Player Head";
    //the name of the tag of the object the turret will target
    public float lookSpeed;
    //the speed at which the turret locks onto the player 
    public bool playerEnteredRange = false;
    //bool to check if the player has entered the turrets range

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //calling the UpdateTarget method 2 times every second
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        //if there is no target locked, the turret will do nothing

        Vector3 dir = target.position - transform.position;
        //calculating the direction the turret will look in when targeting the player
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //calculating how to rotate the object in order to look in the direction calculated (dir)
        Vector3 rotation = Quaternion.Lerp(head.rotation, lookRotation, Time.deltaTime * lookSpeed).eulerAngles;
        //smoothing out the rotation of the turret once it gains a new target
        head.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
        //setting the rotation of the head to the x and y rotation calculated, but not the z rotation    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        //drawing the shooting range in the colour of red
    }

    void UpdateTarget()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag(playerTag);
        //getting an array of the objects with the playerTag
        float shortestDistance = Mathf.Infinity;
        //the shortest distance to an enemy that has been found so far
        GameObject nearestPlayer = null;
        //storing the nearestPlayer to null

        foreach (GameObject Player in player)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            //getting the distance to the enemy
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                //setting the shortestDistance to this distance
                nearestPlayer = Player;
                //setting the nearestPlayer to this player
               
            }
        }

        if (nearestPlayer != null && shortestDistance <= shootingRange) 
        {
            target = nearestPlayer.transform;
            //setting the target to the nearestPlayer's transform
            Shoot();
            //shooting
            playerEnteredRange = true;
            //setting the bool to true
        }
        else
        {
            target = null;
            //setting the target back to nothing       
            playerEnteredRange = false;
            //setting the bool to false
        }
    }

    public void Shoot()
    {
        if (nextFireTime < Time.time)
        {
            Instantiate(enemyBullet, enemyFirePoint.transform.position, Quaternion.identity);
            //the code above is spawning a bullet at the enemy's firepoint position and making sure it doesn't rotate
            nextFireTime = fireRate + Time.time;
            //resseting the turrets fire time
            FindObjectOfType<audio_Manager>().Play("Enemy Shoot");
            //finding the audio manager and playing the enemy shoot sound effect
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<audio_Manager>().Play("Enemy Reaction");
            FindObjectOfType<audio_Manager>().Play("Enemy Rotation");
        }
        //when the player is enetering the trigger, the audio manager is playing the enemy sounds 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<audio_Manager>().StopPlaying("Enemy Rotation");
        }
        //when the player exits the trigger, the audio manager stops playing the rotation sound
    }
}
