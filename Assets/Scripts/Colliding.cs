using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    // The ContactFilter2D object that determines which colliders should trigger collisions
    public ContactFilter2D filter;

    // The BoxCollider2D component attached to the game object
    private BoxCollider2D boxCollider;

    // An array of Collider2D objects that stores information about the colliders that have collided with the box collider
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        // Initialises boxCollider variable
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // This method is called every frame and checks for collisions between the box collider and other colliders
    protected virtual void Update()
    {
        // Checking for collisions
        boxCollider.OverlapCollider(filter, hits);

        // Loop through each collider that collided with the box collider
        for (int i = 0; i < hits.Length; i++)
        {
            // If the collider is null, skip to the next one
            if (hits[i] == null)
            {
                continue;
            }
            else
            {
                // Call the OnCollide method and pass the collider as a parameter
                OnCollide(hits[i]);

                // Clean up the array for the next use
                hits[i] = null;
            }
        }
    }

    // This method is called whenever the box collider collides with another collider
    // It shows the name of the collider that it collided with
    // This method can be overridden in sub-classes to do certain things when colliding with certain objects or players
    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
    }
}
