using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_Movement : MonoBehaviour
{
    [Header("Movement")]
    private float initialMoveSpeed;
    public float moveSpeed = 6f;
    //players base move speed
    public float speedBoostSpeed = 7f;
    //players move speed when on a speed boost
    public float movementMultiplier = 10f;
    [SerializeField] float airMultiplier = 0.4f;
    [SerializeField] Transform orientation;
    public float slowSpeed = 3f;
    //the speed of the player when they step on a hazard
    public bool slowedDown;
    public float boostTotal = 100f;
    //the total amount of boost the player has
    public float currentBoost;
    //the players current speed boost total
   

    [Header("Jumping")]
    public float jumpForce = 5f;
    public float bounceForce = 10f;
    //[SerializeField] private Animator bounce_Pad_Animation;
    //[SerializeField] private string springUp = "Spring Up";

    float playerHeight = 2f;
    //height of the player

    float horizontalMovement; 
    //horizontal movement of the player
    float verticalMovement; 
    //vertical movement of the player

    Vector3 moveDirection; 
    //the direction the player is moving
    Vector3 slopeMoveDirection; 
    //direction the player moves whilst on a slope

    Rigidbody rb; 
    //reference to the rigidbody
    float groundDrag = 6f;
    //drag on the player whilst they're on the ground
    float airDrag = 2f;
    //drag on the player whilst they're in the air

    [Header("Ground Detection")]
    public bool isGrounded; 
    //checking to see if the player is grounded
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    public Transform groundCheck;

    RaycastHit slopeHit;

    [Header("Crouching")]
    public float crouchSpeed; 
    //the speed of the player when crouching
    public float crouchYScale; 
    //the scale on the y that the player will change to when crouching
    private float startYScale;
    //the original scale of the player on the y
    public float slideSpeed;
    //the speed of the player whilst sliding

    [Header("Effects")]
    public GameObject speedLines;
    public bool speedLinesActive;

    private static player_Movement _instance;

    public speed_Boost speedBoost;
    //reference to the speed_boost script

    public GameObject hurtUI;
    //reference to the hurtUI

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        //getting the rigidbody
        rb.freezeRotation = true; 
        //freezing the rotation of the rigidbody

        startYScale = transform.localScale.y;
        //setting the startYScale to the players y scale

        initialMoveSpeed = moveSpeed;
        //setting the initial move speed to the moveSpeed variable

        currentBoost = boostTotal;
        //setting the players speed boost to the boostTotal
        speedBoost.SetMaxSpeedBoost(boostTotal);
        //setting the sliders max value to the boostTotal 
        slowedDown = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, out slopeHit, 1.5f)) 
        //casting a raycast downwards
        {
            if (slopeHit.normal != Vector3.up) 
            //checking to see if the hit normal doesn't equal vector3.up
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //shooting a ray down from the player postion at groundChecks position

        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
        //projecting the players movement based on the angle of the ground object

    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); 
        //the input for horizontal movement
        verticalMovement = Input.GetAxisRaw("Vertical"); 
        //the input for vertical movement

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        //moving the player using those inputs

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            //reloading the current scene
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            //changing the players scale on the y
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            //adding force downwards to the player so that they aren't floating when the scale gets changed
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            //setting the player scale back to the original scale when the player lets go of the crouch button
        }

        if (Input.GetKey(KeyCode.LeftShift) && slowedDown == false)
        {
            if (currentBoost > 0)
            {
                moveSpeed = speedBoostSpeed;
                //setting the players move speed to the speed boost move speed
                UseBoost(0.2f);
                //subtracting 0.2 from the players total amount of speed boost they have when the player is pressing/holding down left shift
                
            }
            else
            {
                moveSpeed = initialMoveSpeed;
            }

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = initialMoveSpeed;
            FindObjectOfType<audio_Manager>().StopPlaying("Boost Sound");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HazardEnabled();
        }

    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        //resetting the y velocity to 0
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void Bounce()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        //resetting the y velocity to 0
        rb.AddForce(transform.up * bounceForce, ForceMode.Impulse);
        //bounce_Pad_Animation.Play(springUp, 0, 0.0f);
        FindObjectOfType<audio_Manager>().Play("Bounce Pad Spring");
        //finding the audio manager, and playing the bounce pad spring sound effect
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag; 
            //adding drag so the player doesn't slide around whilst on the ground
        }
        else
        {
            rb.drag = airDrag; 
            //doesnt add the drag whilst the player is in the air
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        //MyInput();
    }

    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            //adding a force to the rigidbody in the movement direction whilst on the ground 
            StopSpeedLines();
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            //adding a force to the rigidbody based on the angle of the slope
            StopSpeedLines();
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            //whilst in the air, changing the drag to that of the air drag
            StartSpeedLines();
        }
    }

    public void UseBoost(float subtractBoost)
    {
        currentBoost -= subtractBoost;
        //subtracting the subtractBoost from the players currentBoost
        speedBoost.SetSpeedBoost(currentBoost);
        //setting the speed boost sliders current value to the currentBoost value
        FindObjectOfType<audio_Manager>().Play("Boost Sound");
    }

    public void AddBoost(float addBoost)
    {
        currentBoost += addBoost;
        //adding the addBoost amount back to the player's boost meter
        speedBoost.SetSpeedBoost(currentBoost);
        //setting the speed boost sliders current value to the currentBoost value
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bounce Pad":
                Bounce();
                break;
            //when the player collides with an object with the tag "Bounce Pad", they will be bounced into the air by the Bounce() function
        }
       /*switch (collision.gameObject.tag)
        {
            case "Speed Boost":
                moveSpeed = speedBoostSpeed;
                Debug.Log("speed boost");
                break;
            //when the player collides with an object with the tag "Speed Boost", their speed increases as long as they're on the object
        }
        switch (collision.gameObject.tag)
        {
            case "Ground":
                moveSpeed = initialMoveSpeed;
                break;
            //the the player collides with an object with the tag "Ground", their speed will revert back to their normal speed
        }
        switch (collision.gameObject.tag)
        {
            case "Enemy Bullet":
                HazardEnabled();
                Debug.Log("speed slowed");
                break;
            //when the player collides with an object with the tag "Speed Hazard", their speed will decrease as long as they're on the object
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            HazardEnabled();
            //if the players comes into contact with a gameObject with the tag Enemy Bullet, the HazardEnabled coroutine will start
            BulletUIStart();
        }
    }

    public void StartSpeedLines()
    {
        speedLines.SetActive(true);
        //setting the particle effect of the speed lines to active
        speedLinesActive = true;
        //seeting this bool to true
    }

    public void StopSpeedLines()
    {
        speedLines.SetActive(false);
        //deactivating the speed lines particle effect
        speedLinesActive = false;
        //setting this bool to false
    }

    public void HazardEnabled()
    {
        slowedDown = true;
        //setting the slowedDown bool to true
        moveSpeed = slowSpeed;
        //setting the players moveSpeed to the slowSpeed
        StartCoroutine(HazardPowerDownRoutine());
        //starting the coroutine that dictates how long the player gets slowed down for
    }

    IEnumerator HazardPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        //how long the coroutine lasts (5 seconds)
        slowedDown = false;
        //after that time is up, setting the slowedDown bool back to false
        moveSpeed = 10f;
        //setting the players moveSpeed back to their initial speed
    }

    public void BulletUIStart()
    {
        hurtUI.SetActive(true);
        //setting the hurtUI to active
        StartCoroutine(BulletUIStop());
        //starting the coroutine
    }

    IEnumerator BulletUIStop()
    {
        yield return new WaitForSeconds(0.2f);
        //waiting for 0.2 seconds before turning the hurtUI off 
        hurtUI.SetActive(false);
        //deactivating the hurtUI
    }
}
