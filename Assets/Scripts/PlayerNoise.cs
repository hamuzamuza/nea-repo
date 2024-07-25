using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNoise : MonoBehaviour
{
    public float noiseLimit; // The maximum amount of noise the player can make before the enemies are alerted
    public float noiseRange; // The range at which enemies can detect the player's noise
    public LayerMask enemyMask; // Layer mask for enemies
    public float timeInterval = 0.5f; // Time interval at which the noise level is calculated

    private float noiseLevel; // The current level of noise made by the player
    private float timer; // The timer used to calculate the noise level
    private Vector2 prePosition; // The previous position of the player
    private AudioSource audioSource; // The audio source component attached to the player

    private void Start()
    {
        timer = 0.0f;
        prePosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime; // Set timer to the current time + timer

        if (timer >= timeInterval) // If the timer (timeElapsed) is greater than the specified interval
        {
            // Calculate noise level based on distance covered every time interval
            float distanceCovered = Vector2.Distance(transform.position, prePosition);
            noiseLevel += Mathf.Min(distanceCovered, noiseLimit);
            timer = 0.0f;
            prePosition = transform.position;

            if (noiseLevel > noiseLimit) // If the amount of noise being made is greater than the limit
            {
                // Emit sound where the volume of said sound is based on how much noise the user is making
                float volume = (noiseLevel - (noiseLimit * 1.2f)) / noiseLimit;
                audioSource.volume = Mathf.Clamp(volume, 0, 1);
                noiseRange = Mathf.Clamp(volume, 0, 1);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                MakeNoise();

                // Reset noise level
                noiseLevel = 0.0f;
            }
        }
    }

    // Attracts nearby enemies towards the player based on the noise range
    private void MakeNoise()
    {
        // Find all colliders in the radius noiseRange with layer Enemy
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, noiseRange, enemyMask);

        // Attract each enemy to the position of the player 
        foreach (Collider2D enemy in enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.Attract(transform.position);
        }
    }
}
