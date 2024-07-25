using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTutorial : Chest
{
    // Called when the player collects the Tutorial Chest
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            prescriptionAmount = Random.Range(1, 25);
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText($"Grant {prescriptionAmount} pr...", 13, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            GameManager.instance.ShowText("These will increae your score, so make sure to collect as many as you can!", 20, Color.white, transform.position, Vector3.down * 10, 4f);
        }
    }
}
