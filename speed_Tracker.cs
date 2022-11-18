using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class speed_Tracker : MonoBehaviour
{
    public Rigidbody target;
    //reference to the players rigidbody
    public float maxSpeed;
    //the players max speed  
    public TextMeshProUGUI speedCounter;
    //the text that counts the speed of the player
    private float speed = 0.0f;
    //the speed of the player


    void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
        //setting the speed to the velocity of the players rigidbody multiplied by 3.6 to convert it into kilometers

        if (speedCounter != null)
        {
            speedCounter.text = ((int)speed) + " KM/H";
        }
        //making the spped counter equal the speed of the player plus "KM/H"
    }
}
