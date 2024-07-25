using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // This method is called when the NPC collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string highScoresText = string.Empty; // Create a new empty string
        // Format string as the highScores list vertically
        foreach (int score in HighScoresManager.highScores)
        {
            highScoresText += $"{score.ToString()}\n"; // Separate each score by a newline
        }

        // Access the static GameManager instance and call the ShowText method on the string string
        GameManager.instance.ShowText(highScoresText, 20, Color.white, transform.position, Vector3.zero, 1.5f);
    }
}
