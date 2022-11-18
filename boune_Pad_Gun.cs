using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bounce_Pad_Gun : MonoBehaviour
{
    public LayerMask layerMask;
    //the layer that the bounce pads will be instantiated on    
    public Camera cam; 
    //reference to the camera
    public GameObject bouncePad;
    //reference to the bouncepad
    public int ammoAmount;
    //the amount of ammo the player has
    public TextMeshProUGUI ammoCounter;
    //the text that displays the ammo


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoAmount > 0)
        {
            Shoot();
            //shooting when the player presses down the "Fire1" key
        }
        else if (Input.GetButtonDown("Fire1") && ammoAmount == 0)
        {
            FindObjectOfType<audio_Manager>().Play("Can't Shoot Bounce Pad");
            //playing the can't shoot sound effect
        }

        ammoCounter.text = ammoAmount.ToString();
        //setting the ammo counter text to the ammo amount
    }

    void Shoot()
    {
        RaycastHit hit; 
        //stores information about what was hit with the ray
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, layerMask))
        //this is shooting out the ray at the position of the camera on screen and forward of it
        {
            Debug.Log(hit.transform.name); 
            //displaying objects names that are hit

            if (hit.collider.CompareTag("Ground"))
            {
                Instantiate(bouncePad, hit.point, Quaternion.LookRotation(hit.normal));
                //if the raycast hits an object with the tag "ground", the bounce pad will instantiate
                ammoAmount -= 1;
                //subtracting one ammo amount whenever the player shoots
                FindObjectOfType<audio_Manager>().Play("Shooting Sound");
                ///playing the shooting sound effect
            }
            else
            {
                FindObjectOfType<audio_Manager>().Play("Can't Shoot Bounce Pad");
                //playing the can't shoot sound effect
            }
        }
    }
}
