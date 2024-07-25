using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The maximum/starting amount of health this entity can have/has
    public float startHealth = 10f;

    // The current amount of health this entity has
    public float currentHealth;

    // A reference to the Area script
    public Area area;

    private void Start()
    {
        // Set the current health to the maximum health at the start of the game
        currentHealth = startHealth;
    }

    // Method for taking damage
    public void TakeDamage(float damage)
    {
        // Subtract the damage from the current health
        currentHealth -= damage;

        // If the current health is less than or equal to 0, call the Die method
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method for handling death
    private void Die()
    {
        // If the Player dies then destroy the Player gameObject and end the game/quit the application
        if (gameObject.name == "Player")
        {
            Destroy(gameObject);
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        // Search for this enemy in the list of enemies managed by the Area script, and remove it from the list
        for (int i = 0; i < area.enemies.Count; i++)
        {
            if (area.enemies[i].name == gameObject.name)
            {
                area.enemies.RemoveAt(i);
                break;
            }
        }

        Destroy(gameObject);
    }

}
