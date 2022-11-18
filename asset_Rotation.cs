using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asset_Rotation : MonoBehaviour
{
    float rotateSpeed = 50f;
    //the speed of the rotation

    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        //rotating the object right by the rotate speed
    }
}
