using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collecting
{
    // Sprite to show when the chest is empty
    public Sprite emptyChest;
    // Amount of prescription the player gains when they collect the chest
    public int prescriptionAmount;

    // Called when the player collects the chest
    protected override void OnCollect()
    {
        // If the chest hasn't already been collected
        if (!collected)
        {
            collected = true;
            // If the chest hasn't already been assigned a prescription amount
            if (prescriptionAmount < 1)
            {
                // Assign a random number between 1 and 4 to prescriptionAmount
                prescriptionAmount = Random.Range(1, 4);
            }
            // Change the sprite to the emptyChest sprite
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            // Show a text message indicating the player has gained prescriptionAmount prescriptions
            GameManager.instance.ShowText($"Gained {prescriptionAmount} pr...", 24, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            // Increase the player's prescription count
            GameManager.instance.IncreasePre(prescriptionAmount);
        }
    }
}
