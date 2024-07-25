using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f; // Speed at which the player moves
    public LayerMask collisionMask; // Layers player can collide with

    private Vector2 moveDirection = Vector2.zero;  // The direction the player is moving
    private Rigidbody2D rb2D;  // The Rigidbody2D component attached to the player object

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component from the player object
        DontDestroyOnLoad(gameObject);  // Do not destroy this object when a new scene is loaded
    }

    void Update()
    {
        // Get input from user
        moveDirection.x = Input.GetAxisRaw("Horizontal");  // Get the horizontal input from the user
        moveDirection.y = Input.GetAxisRaw("Vertical");  // Get the vertical input from the user
        moveDirection = new Vector2(moveDirection.x, moveDirection.y).normalized;  // Normalize the direction vector

        // Swap sprite direction based on input
        if (moveDirection.x <= 0)
        {
            if (moveDirection.x < 0)
                transform.localScale = new Vector2(-1, 1); // If 'a' is pressed then sprite faces left
        }
        else
        {
            transform.localScale = Vector2.one; // If 'd' is pressed then sprite faces right
        }
        moveDirection *= speed;  // Multiply the direction vector by the speed value to get the movement vector

        // Check for collisions against collisionMask using BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size, 0, moveDirection, Mathf.Abs(speed * Time.deltaTime), collisionMask);  // Cast a box in the direction of movement to check for collisions

        if (hit.collider != null)
        {
            moveDirection = Vector2.zero;  // Stop the player's movement if there is a collision
        }

        rb2D.velocity = moveDirection;  // Set the player's velocity to the movement vector
    }
}

