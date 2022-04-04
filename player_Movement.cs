using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f; //players move speed
    public float movementMultiplier = 10f;
    [SerializeField] float airMultiplier = 0.4f;
    [SerializeField] Transform orientation;

    [Header("Jumping")]
    public float jumpForce = 5f;

    float playerHeight = 2f;

    float horizontalMovement; //horizontal movement of the player
    float verticalMovement; //vertical movement of the player

    Vector3 moveDirection; //the direction the player is moving
    Vector3 slopeMoveDirection; //direction the player moves whilst on a slope

    Rigidbody rb; //reference to the rigidbody
    float groundDrag = 6f;
    float airDrag = 2f;

    [Header("Ground Detection")]
    bool isGrounded; //checking to see if the player is grounded
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    public Transform groundCheck;

    RaycastHit slopeHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting the rigidbody
        rb.freezeRotation = true; //freezing the rotation of the rigidbody
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.5f)) //casting a raycast downwards
        {
            if (slopeHit.normal != Vector3.up) //checking to see if the hit normal doesnt equal vector3.up
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
        //shooting a ray down from the player postion at groundchecks position

        

        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal); //projecting the players movement based on the angle
        //of the ground object
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); //the input for horizontal movement
        verticalMovement = Input.GetAxisRaw("Vertical"); //the input for vertical movement

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement; //moving the player using those inputs
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); //resetting the y velocity to 0
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag; //adding drag so the player doesnt slide around whilst on the ground
        }
        else
        {
            rb.drag = airDrag; //doesnt add the drag whilst the player is in the air
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            //adding a force to the rigidbody in the movement direction whilst on the ground
            //rb.useGravity = true;
            //if (rb.velocity.y > 0)
            //{
              //  rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            //}
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
            //rb.useGravity = false;
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            //whilst in the air, changing the drag to that of the air drag
           // rb.useGravity = true;
        }

        
    }
}
