using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Look : MonoBehaviour
{
    [SerializeField] private float sensX; //sensitivity on the x axis
    [SerializeField] private float sensY; //sensititvity on the y axis

    [SerializeField] Transform cam; //reference to the camera
    [SerializeField] Transform orientation;

    float mouseX; //mouse sensitivity on the x axis
    float mouseY; //mouse sensitivity on the y axis

    float multiplier = 0.05f;

    float xRotation;
    float yRotation;

    [SerializeField] wall_Running wallRun;

    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked; //locking cursur to the middle of the screen
        Cursor.visible = false; //making the cursur invisible
    }

    private void Update()
    {
        
        MyInputs();

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt); //setting camera rotation to the rotation along the x axis
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0); //rotating the player along the y axis
    }

    void MyInputs()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
        //setting the mouse x and y to their respective input axis

        yRotation += mouseX * sensX * multiplier; //adding horizontal input to the y rotation
        xRotation -= mouseY * sensY * multiplier; //subtracting vertical input to the x rotation, iff added it would be inverted

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamping the x rotation
    }
}
