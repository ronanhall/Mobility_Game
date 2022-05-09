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
    

    bool wallLeft = false; 
    //whether there is a wall on the left
    bool wallRight = false; 
    //whether there is a wall on the right

    private Rigidbody rb; 
    //reference to the players rigidbody

    RaycastHit leftWallHit; 
    //storing if the raycast hit a wall to the left
    RaycastHit rightWallHit; 
    //storing if the raycast hit a wall to the right

    [Header("Camera")]
    [SerializeField] private Camera cam; 
    //reference to the camera
    [SerializeField] private float fov; 
    //the players field of view
    [SerializeField] private float wallRunFOV; 
    //the players field of view whilst on a wall
    [SerializeField] private float wallRunFOVTime; 
    //the time the player can run on a wall
    [SerializeField] private float camTilt; 
    //the tilt of the camera when wall running
    [SerializeField] private float camTiltTime;
    //the amount of time the camera remains tilted

    player_Movement pm;
    public bool inAir;

    public float tilt { get; private set; }
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight); 
    }

    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallDistance);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallDistance);
        //checking if there a wall to the left and right of the player
    }

    private void Update()
    {
        CheckWall();

        if (CanWallRun())
        {
            if (wallLeft)
            {
                StartWallRun();
                //Debug.Log("wall is to the left");
                //Debug.Log("wallrunning left");
            }
            else if (wallRight)
            {
                StartWallRun();
                //Debug.Log("wall is to the right");
                //Debug.Log("wallrunning right");
            }
            else
            {
                StopWallRun();

            }
        }
        else
        {
            StopWallRun();
        }
        //checking if there is a wall to the left and right of the player, and if there is they will start wall running, if there isn't they 
        //won't begin wall running
    }

    void StartWallRun()
    {
        //if ()
        //{
            inAir = true;
            
            rb.useGravity = false;
            //setting the players gravity to 0

            rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

            //Invoke(nameof(StopWallRun), maxWallRunTime);

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
                    rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Force);
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
            }
        //}
        
       
    }

    void StopWallRun()
    {
        inAir = false;
        
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunFOVTime * Time.deltaTime);

        tilt = Mathf.Lerp(tilt, 0, Time.deltaTime);
        //when the player stops wall running, it turns their gravity on, changes their field of view to normal and not tilting the camera
    }
}
