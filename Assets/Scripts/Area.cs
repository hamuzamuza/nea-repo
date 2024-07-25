using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public List<Area> childNodes; // A list of child nodes of this area.
    public List<GameObject> enemies; // A list of enemies in this area.
    public GameObject crate; // A crate object in this area.
    //public bool cleared;

    // Constructor for the Area class that sets initial values for its fields.
    // Only used when MapManager is privately creating the Areas
    // Otherwise it is redundant
    /*public Area(List<GameObject> enemies, GameObject crates)
    {
        this.childNodes = new List<Area>();
        this.enemies = enemies;
        this.crate = crates;
    }

    // Adds a child node to this area.
    // This is also redundant if areas are created through Unity inspector
    public void AddNode(Area node)
    {
        childNodes.Add(node);
    }*/

    // Returns true if all enemies in this area and its child nodes have been defeated, and false otherwise.
    public bool IsCleared()
    {
        if (enemies.Count > 0) // If there are still enemies in this area, it is not yet cleared and return false.
        {
            return false;
        }

        foreach (Area node in childNodes) // Check if all child nodes are cleared.
        {
            if (!node.IsCleared()) // If any child node is not cleared, this area is not cleared.
            {
                return false;
            }
        }

        // Disable the collider of the crate.
        Collider collider = crate.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Hide the crate object.
        crate.SetActive(false);

        return true; // All enemies in this area and its child nodes have been defeated, so this area is cleared.
    }

}
