using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : Colliding
{
    // A boolean that keeps track of whether the object has been collected
    protected bool collected;

    // This method is called whenever the object collides with another collider
    // If the collider is the player, the OnCollect method is called
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            OnCollect();
        }
    }

    // This method is called when the object has been collected
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
