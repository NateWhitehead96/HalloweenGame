using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed; // how fast the object will fall
    public float RotationSpeed; // some rotation speed
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime); // moving the object down on screen
        transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + RotationSpeed * Time.deltaTime); // rotating the object

        if(transform.position.y < -12) // when its off screen destroy it
        {
            Destroy(gameObject);
        }
    }
}
