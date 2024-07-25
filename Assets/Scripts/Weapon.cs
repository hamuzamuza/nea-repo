using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1; // Base damage dealt
    public float backstabMultiplier = 3; // The multiplier applied to damage if the attack is a backstab
    public LayerMask enemyMask; // The layer mask used to detect enemies
    public float cooldown = 3f; // Cooldown till next attack

    private GameObject enemy; // The enemy that the player is currently attacking

    // Getter for cooldown value
    public float Cooldown
    {
        get { return cooldown; }
    }

    // This method runs when a collision occurs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyMask == (enemyMask | (1 << collision.gameObject.layer))) // Check if the collision is with an enemy layer
        {
            enemy = collision.gameObject; // Set the GameObject the player collided with to enemy

            // Check which way the enemy is facing
            bool facingRight = enemy.transform.localScale.x < 0;

            // Calculate damage dealt based on whether the weapon is behind the enemy
            if (IsBackstab(facingRight))
            {
                damage *= backstabMultiplier++; // If the attack is a backstab then multiply the damage by the backstab multiplier and increment by 1
            }

            // Deal damage to the enemy
            Health enemyHealth = enemy.GetComponent<Health>(); // Get the enemy's Health component
            if (enemyHealth != null) // Check if the enemy has a Health component
            {
                enemyHealth.TakeDamage(damage); // Deal damage to the enemy
            }
            damage = 1;
        }
    }

    // Check if the attack is a backstab based on the weapon's direction and the enemy's facing direction
    private bool IsBackstab(bool facingRight)
    {
        // Direction of the player's weapon
        Vector2 weaponDirection = transform.right;

        // Direction of weapon to enemy
        Vector2 weaponToEnemy = transform.position - enemy.transform.position;

        // Flip the weaponToEnemy vector if the enemy is facing left
        if (facingRight)
        {
            weaponToEnemy = -weaponToEnemy;
        }

        // Calculate dot product
        float dotProduct = Vector2.Dot(weaponDirection, weaponToEnemy.normalized);

        // Check if the weapon is behind the enemy
        return dotProduct < 0;
    }
}
