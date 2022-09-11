using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_Running : MonoBehaviour
{
    [SerializeField] Transform orientation; 
    //reference to the players orientation

    [Header("Wall Running")]
    [SerializeField] float wallDistance = 0.5f; 
    //the minimum distance that detects a wall
    [SerializeField] float minJumpHeight = 1.5f; 
    //the minimum jump height the player needs to reach to start wall running
    [SerializeField] private float wallRunGravity; 
    //the gravity whilst on the wall
    [SerializeField] private float wallJumpForce;
    //the force the player jumps off at the wall
    [SerializeField] public float maxWallRunTime;
    //the amount of time the player can wall run for
    public Transform groundCheck;

    public float sphereRadius = 0.6f;
    //the radius of the OverlapSphere
    public LayerMask wallLayer;
    //the layermask specifying what layer the OverLapSphere interacts with
    private Collider[] wallHitColliders;
    //the group of colliders that detects if there is a wall next to the player
    

    bool wallLeft = false; 
    //whether there is a wall on the left
    bool wallRight = false;
    //whether there is a wall on the right
    bool wallBack = false;
    //whether there is a wall behind the player
    public bool wallNextToPlayer = false;
    //whether there is a wall next to the player

    private Rigidbody rb; 
    //reference to the players rigidbody

    RaycastHit leftWallHit; 
    //storing if the raycast hit a wall to the left
    RaycastHit rightWallHit;
    //storing if the raycast hit a wall to the right
    RaycastHit backWallHit;
    //storing if the raycast hit a wall to the back of the player

    [Header("Camera")]
    [SerializeField] private Camera cam; 
    //reference to the camera
    [SerializeField] private float fov; 
    //the players field of view
    [SerializeField] private float wallRunFOV; 
    //the players field of view whilst on a wall
    [SerializeField] private float wallRunFOVTime; 
    //the time it takes for the camera to transition between the two FOV's
    [SerializeField] private float camTilt; 
    //the tilt of the camera when wall running
    [SerializeField] private float camTiltTime;
    //the amount of time the camera remains tilted

    player_Movement pm;
    public bool inAir;
    //private object wallHitCollider;

    public float wallStickiness = 20f;

    public float tilt { get; private set; }
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    bool CanWallRun()
    {
        return !Physics.Raycast(groundCheck.position, Vector3.down, minJumpHeight);
        //casting a raycast at the position of the groundCheck, downwards and at the legnth of the minJumpHeight float
    }

    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);
        //setting the bools to true if there is a wall to the left and right of the player
        wallBack = Physics.Raycast(transform.position, -orientation.forward, out backWallHit, wallDistance);
        //setting the bool to true if there is a wall behind the player
        wallHitColliders = Physics.OverlapSphere(transform.position, sphereRadius, wallLayer, QueryTriggerInteraction.Ignore);
        //this is creating a sphere at the players position, with the radius of the sphereRadius float, and is interacting with the wallLayer layerMask
        if (wallHitColliders.Length != 0)
        {
            Debug.Log("wall is next to player");
            wallNextToPlayer = true;
            //when the collider length is 0, it means the player is close to the wall, so the wallNextToPlayer bool is set to true
        }
        else
        {
            wallNextToPlayer = false;
            //if the colliders don't equal 0, it means the player isn't close to a wall, so the wallNextToPlayer bool is set to false
        }       
    }

    private void Update()
    {
        CheckWall();

        if (CanWallRun())
        {
            /*if (wallLeft)
            {
                StartWallRun();
                Debug.Log("wall is to the left");
                //Debug.Log("wallrunning left");
            }
            else if (wallRight)
            {
                StartWallRun();
                Debug.Log("wall is to the right");
                //Debug.Log("wallrunning right");
            }
            else
            {
                StopWallRun();

            }*/
            if (wallNextToPlayer)
            {
                StartWallRun();
                Debug.Log("wallrunning");
                //if the wallNextToPlayer bool is equal to true and the player can wallrun, they start wallrunning
            }
            else
            {
                StopWallRun();
                //if not, they stop wallrunning
            }
            
        }
        else
        {
            StopWallRun();
        }
    }

    void StartWallRun()
    {
        inAir = true;
            
        rb.useGravity = false;
        //setting the players gravity to 0

        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunFOV, wallRunFOVTime * Time.deltaTime);
        //changing the camera's field of view when on a wall

       

        if (wallLeft)
        {
            tilt = Mathf.Lerp(tilt, -camTilt, Time.deltaTime);
            //tilting the camera to the right if on a wall to the left
           
        }
        else if (wallRight)
        {
            tilt = Mathf.Lerp(tilt, camTilt, Time.deltaTime);
            //tilting the camera to the left if on a wall to the right
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallLeft)
            {
                Vector3 wallRunJumpDirection = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Acceleration);
                Debug.Log("walljump left");
                    //

            }
            else if (wallRight)
            {
                Vector3 wallRunJumpDirection = transform.up + rightWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Force);
                Debug.Log("walljump right");
                    //

            }
            else if (wallBack)
            {
                Vector3 wallRunJumpDirection = transform.up + backWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Force);
                Debug.Log("walljump forward");
            }
        }
        
        //this needs sorting out
       
    }

    void StopWallRun()
    {
        inAir = false;
        
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunFOVTime * Time.deltaTime);

        tilt = Mathf.Lerp(tilt, 0, camTiltTime * Time.deltaTime);
        //when the player stops wall running, it turns their gravity on, changes their field of view to normal and not tilting the camera
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
        //drawing the shooting range in the colour of red
    }


}
