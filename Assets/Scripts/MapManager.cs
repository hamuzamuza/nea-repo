using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class MapManager : MonoBehaviour
{
    public Area rootNode; // Instance of Area class that represents rood node of map

    /*private void Start()
    {
        // Creating the root node
        rootNode = new Area(null, null);

        // Creating the child nodes
        Area area1 = new Area(null, null);
        Area area1_1= new Area(null, null);

        // This is what the code would look like for creation of an area
        Area area1_2= new Area(null, GameObject.Find("crates1"));
        
        Area area1_3= new Area(null, null);

        Area area2= new Area(null, null);
        Area area2_1= new Area(null, null);
        Area area2_2 = new Area(null, null);

        Area area3= new Area(null, null);
        Area area3_1 = new Area(null, null);
        Area area3_2= new Area(null, null);

        Area area4= new Area(null, null);
        Area area4_1 = new Area(null, null);
        Area area4_2= new Area(null, null);

        Area area5= new Area(null, null);

        // Adding the child nodes to the root node
        rootNode.AddNode(area1);
        rootNode.AddNode(area2);
        rootNode.AddNode(area3);
        rootNode.AddNode(area4);
        rootNode.AddNode(area5);

        // Adding child nodes to parent nodes
        area1.AddNode(area1_1);
        area1.AddNode(area1_2);
        area1.AddNode(area1_3);

        area2.AddNode(area2_1);
        area2.AddNode(area2_2);

        area3.AddNode(area3_1);
        area3.AddNode(area3_2);

        area4.AddNode(area4_1);
        area4.AddNode(area4_2);

        GameObject crateToDestroy = rootNode.childNodes[0].childNodes[1].crate;
        Debug.Log(crateToDestroy);
        GameObject.Destroy(crateToDestroy);
        Debug.Log("Its Working");
        
    }*/

    private void Update()
    {
        // Regularly check if map has been cleared
        // If so, create a message that says they have been cleared
        if (rootNode.IsCleared())
        {
            Debug.Log("They have all been cleared!");
        }

    }
}
