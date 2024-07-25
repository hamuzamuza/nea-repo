using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // A static reference to the GameManager instance so it can be accessed from other scripts
    public static GameManager instance;

    // The number of prescriptions the player has collected
    public int prescriptions;

    // A reference to the TextOnScreenManager script for displaying text on screen
    public TextOnScreenManager txtOnScreenManager;

    // The player's current score
    public int currentScore;

    // A reference to the PlayerDamage script for calculating the score
    public Weapon weapon;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Set the instance variable to this script so it can be accessed from other scripts
        instance = this;

        // Don't destroy the GameManager when a new scene is loaded, so it stays persistent throughout the game
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Load the high scores from a text file as soon as the game starts
        HighScoresManager.LoadHighScores();
    }

    // A public method for displaying text on screen
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        // Call the Show method of the TextOnScreenManager script
        txtOnScreenManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // A method for increasing the number of prescriptions the player has collected and updating the score
    public void IncreasePre(int amount)
    {
        // Increment the number of prescriptions
        prescriptions += amount;

        // Calculate the score based on the number of prescriptions collected and the backstab multiplier from the PlayerDamage script
        float score = amount * weapon.backstabMultiplier;

        // Round the score to the nearest integer and set it as the current score
        currentScore = Mathf.RoundToInt(score);
    }

    // Called when the application is about to quit
    private void OnApplicationQuit()
    {
        // Update and save the high scores as soon as the game closes
        HighScoresManager.UpdateHighScores(currentScore);
    }

}
