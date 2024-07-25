using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerMovement : MonoBehaviour
{
    //public Rigidbody2D rBody2d;
    public float moveSpeed;
    private Vector2 moveDirection;
    private BoxCollider2D bCollider;


    void Start()
    {
        //rBody2d = gameObject.GetComponent<Rigidbody2D>();
        //bCollider = GetComponent<BoxCollider2D>();
        DontDestroyOnLoad(gameObject);
        bCollider = GetComponent<BoxCollider2D>();
        //will use this as this makes it easier to keep the characters stats
    }

    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        Debug.Log(transform.position);
    }

    private void FixedUpdate()
    {
        //Swapping sprite direction based on x-value in moveDirection
        if (moveDirection.x <= 0)
        {
            if (moveDirection.x < 0)
                transform.localScale = new Vector2(-1, 1); //If a is pressed then sprite faces left
            CheckforCollision();
        }
        else
        {
            transform.localScale = Vector2.one; //If d is pressed then sprite faces right
            CheckforCollision();
        }
    }

    private void CheckforCollision()
    {
        // Cast a box in the direction of movement
        BoxCastHit2D hit = Physics2D.BoxCast(transform.position, bCollider.size, 0f, moveDirection, Mathf.Abs(moveDirection.y * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // No collision was detected, so move the player
            transform.Translate(0, moveDirection.y * Time.fixedDeltaTime, 0);
        }

        // Cast a box in the direction of movement
        hit = Physics2D.BoxCast(transform.position, bCollider.size, 0f, moveDirection, Mathf.Abs(moveDirection.x * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // No collision was detected, so move the player
            transform.Translate(moveDirection.x * Time.fixedDeltaTime, 0, 0);
        }
    }
}
*/