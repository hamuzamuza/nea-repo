using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Colliding
{
    // This is a public variable named sceneName of type string, which will be used to store the name of the scene the player will be teleported to when they collide with the portal.
    // It's marked as public so that it can be easily changed in the Unity editor.
    public string sceneName;

    // Called when the player collides with the portal
    protected override void OnCollide(Collider2D coll)
    {
        // Check if the collider that the portal has collided with is named "Player"
        if (coll.name == "Player")
        {
            // If the collider is the player, load the scene specified in the sceneName variable using the SceneManager class in Unity.
            // This will change the current scene to the scene specified in sceneName.
            SceneManager.LoadScene(sceneName);
        }
    }
}
