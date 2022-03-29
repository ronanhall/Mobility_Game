using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boune_Pad_Gun : MonoBehaviour
{
    public float range = 100f; //range of the bounce pad

    public Camera fpsCam; //reference to the camera

    public GameObject bouncePad; //reference to the bouncepad

    // Update is called once per frame
    void Update()
    {
        //this function basically says when the left mouse button is clocked, the player will shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit; //stores information about what was hit with the ray
        //this is shooting out the ray at the position of the camera on screen and forward of it
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.tag); //displaying objects names that are hit

            Instantiate(bouncePad, hit.point, Quaternion.identity);
        }
    }
}
