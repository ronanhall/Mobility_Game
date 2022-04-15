using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Turret : MonoBehaviour
{
    private Transform player;
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
    //public Transform head;
    //reference to the head of the turret


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //the code above is the enemy looking for the player
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        //getting the distance from the players positon and the turrets position
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(enemyBullet, enemyFirePoint.transform.position, Quaternion.identity);
            //the code above is spawning a bullet at the enemy's firepoint position and making sure it doesn't rotate
            nextFireTime = fireRate + Time.time;
        }
        //this void fires a bullet only when the player is within the shootingRange and the nextFireTime is less
        //than the time that has passed

        //if (distanceFromPlayer <= shootingRange)
        //{
          //  head.LookAt(player);
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
