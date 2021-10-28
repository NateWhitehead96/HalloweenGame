using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMovement : MonoBehaviour
{
    public float speed; // how fast the bag can move
    public int Bounds; // to tell the bag to stay on screen

    public int score;
    public int lives;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") && transform.position.x > -Bounds) // when pressing A move left
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey("d") && transform.position.x < Bounds) // when pressing D move right
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Candy")) // when colliding with candy gain 1 score
        {
            score++;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Rock")) // when colliding with rock lose 1 life
        {
            lives--;
            Destroy(collision.gameObject);
        }
    }
}
