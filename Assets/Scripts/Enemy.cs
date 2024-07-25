using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed; // The speed at which the enemy moves
    public new BoxCollider2D collider; // The collider attached to the enemy

    private Vector2 targetPosition; // The position the enemy is moving towards

    private void Start()
    {
        targetPosition = transform.position; // Initialize the target position to the enemy's current position
        collider = gameObject.GetComponent<BoxCollider2D>(); // Get the collider component on the enemy game object
    }

    // Checking for collisions
    private void Update()
    {
        // Check if there's a wall in the way
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized; // The direction the enemy is moving
        Vector2 size = collider.size; // The size of the enemy's collider
        float distance = Vector2.Distance(transform.position, targetPosition); // The distance between the enemy and the target position
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, size, 0, direction, distance, LayerMask.GetMask("Blocking")); // Cast a box to check for obstacles in the enemy's path

        // If there's no wall, move towards the target position
        if (hit.collider == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        // If there's a wall, stop moving
        else
        {
            return;
        }
    }

    public void Attract(Vector2 target)
    {
        // Update the target position to move towards the player's position
        targetPosition = target;
    }
}
