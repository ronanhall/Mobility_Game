using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Camera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position; //setting the position to the camera holders position
    }
}
