using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_Running : MonoBehaviour
{
    [SerializeField] Transform orientation; //reference to the players orientation

    [Header("Wall Running")]
    [SerializeField] float wallDistance = 0.5f;
    [SerializeField] float minJumpHeight = 1.5f;
    [SerializeField] private float wallRunGravity;
    [SerializeField] private float wallJumpForce;

    bool wallLeft = false;
    bool wallRight = false;

    private Rigidbody rb;

    RaycastHit leftWallHit;
    RaycastHit rightWallHit;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private float fov;
    [SerializeField] private float wallRunFOV;
    [SerializeField] private float wallRunFOVTime;
    [SerializeField] private float camTilt;
    [SerializeField] private float camTiltTime;

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
            }
            else if (wallRight)
            {
                StartWallRun();                
                //Debug.Log("wall is to the right");
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
    }

    void StartWallRun()
    {
        rb.useGravity = false;

        rb.AddForce(Vector3.down * wallRunGravity, ForceMode.Force);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, wallRunFOV, wallRunFOVTime * Time.deltaTime);

        if (wallLeft)
        {
            tilt = Mathf.Lerp(tilt, -camTilt, Time.deltaTime);
        }
        else if (wallRight)
        {
            tilt = Mathf.Lerp(tilt, camTilt, Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallLeft)
            {
                Vector3 wallRunJumpDirection = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Force);
                Debug.Log("wallrunning left");
            }
            else if (wallRight)
            {
                Vector3 wallRunJumpDirection = transform.up + rightWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(wallRunJumpDirection * wallJumpForce * 100, ForceMode.Force);
                Debug.Log("wallrunning right");
            }
        }
    }

    void StopWallRun()
    {
        rb.useGravity = true;

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, wallRunFOVTime * Time.deltaTime);

        tilt = Mathf.Lerp(tilt, 0, Time.deltaTime);
    }
}
