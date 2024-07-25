

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector2 movePlayer;
    private RaycastHit2D hit;
    private float moveSpeed;


    private void Start()
    {
        //DontDestroyOnLoad(gameObject); hasnt been used as
        //this would cause the player to appear in a random location in the next scene
        //when they teleport
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //private RaycastHit2D GetHit()
    //{
        //return hit;
    //}

    /*private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        movePlayer = new Vector2(x, y);
        Move();
    }*/


    private void FixedUpdate()
    {
        if (hit.collider == null)
        {
            //Make the sprite move
            transform.Translate(movePlayer.x, movePlayer.y * Time.deltaTime, 0);

        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
   



        //Resetting movePlayer
        movePlayer = new Vector2(x, y);

        //Swapping sprite direction
        if (movePlayer.x > 0)
            transform.localScale = Vector2.one; //If d is pressed then sprite faces right
        else if (movePlayer.x < 0)
            transform.localScale = new Vector2(-1, 1); //If a is pressed then sprite faces left
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movePlayer.y), Mathf.Abs(movePlayer.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        Move(hit);
        //if (hit.collider == null)
        {
            //Make the sprite move
            //transform.Translate(0, movePlayer.y * Time.deltaTime, 0);

        }
        //Same thing but for the x-axis
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movePlayer.x, 0), Mathf.Abs(movePlayer.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        Move(hit);
        //if (hit.collider == null)
        {
            //Make the sprite move
            //transform.Translate(movePlayer.x * Time.deltaTime, 0, 0);

        }
    }
    private void Move(RaycastHit2D hit)
    {
        if (hit.collider == null)
        {
            transform.Translate(movePlayer.x * Time.deltaTime, movePlayer.y * Time.deltaTime, 0);
        }
    }



}
