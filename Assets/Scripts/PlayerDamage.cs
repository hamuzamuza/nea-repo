using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Controls when the player can do damage
public class PlayerDamage : MonoBehaviour
{
    private GameObject weapon; // Reference to the player's weapon
    private float nextTime = 0; // The time until the player can attack again
    private bool isAttacking = false;

    private void Start()
    {
        weapon = GameObject.Find("Weapon");
    }

    private void Update()
    {
        if (Time.time >= nextTime) // Check if enough time has passed since the last attack
        {
            if (Input.GetButtonDown("Fire1") && !isAttacking) // Check if the attack button has been pressed and the player is not already attacking
            {
                isAttacking = true;
                nextTime = Time.time + weapon.GetComponent<Weapon>().Cooldown; // Set the next attack time
                Invoke("EndAttack", 0.2f); // Call EndAttack after 0.2 seconds
                weapon.GetComponent<BoxCollider2D>().enabled = true; // Enable the weapon's collider to detect collisions
            }
        }
    }

    // Disable the weapon's collider and set attacking to false
    private void EndAttack()
    {
        weapon.GetComponent<BoxCollider2D>().enabled = false;
        isAttacking = false;
    }
}

