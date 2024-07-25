using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Tracks whether game is paused or not
    public bool isPaused;

    private void Update()
    {
        // If the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused
            if (isPaused)
            {
                // Resume the game
                ResumeGame();
            }
            // If the game is not paused
            else
            {
                // Pause the game
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Set the game's time scale to 0 to pause all movement
        Time.timeScale = 0.0f;

        // Update the isPaused variable to reflect that the game is now paused
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Set the game's time scale back to 1 to resume movement
        Time.timeScale = 1.0f;

        // Update the isPaused variable to reflect that the game is no longer paused
        isPaused = false;
    }
}
