using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If this object collides with the Player object
        if (collision.gameObject.name == "Player")
        {
            // Get the Health component of the Player object
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            // Call the TakeDamage function of the Health component to damage the player
            playerHealth.TakeDamage(damage);
        }
    }
}
