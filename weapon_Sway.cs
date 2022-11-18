using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_Sway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    //the smoothing of the weapon sway
    [SerializeField] private float swayMultiplier;
    //the sway multiplier


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        //getting the input of the mouse on the x axis
        float mouseY = Input.GetAxisRaw("Mouse Y") + swayMultiplier;
        //getting the input of the mouse on the y axis

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        //calculating the target rotation on the x axis
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        //calculating the target rotation on the y axis
        Quaternion targetRotation = rotationX * rotationY;
        //combining the x rotation and the y rotation

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        //rotating the weapon between two quaternions in a certain time frame
    }
}
