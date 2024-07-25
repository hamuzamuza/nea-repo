using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    /*public Transform lookAt;
    //This is the amount of space on the axes the character can move before the camera starts moving
    public float boundX = 0.3f;
    public float boundY = 0.15f;*/
    public Transform lookAt;

    private void Start()
    {
        // Find the position of the player (object) and set it as the target for the camera to follow
        lookAt = GameObject.Find("Player").transform;
    }

    /*private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        //This is to check if we are inside the bound on the X-axis
        //transform.position is the centre/midpoint of where the camera is
        //lookAt.position is the where the character is (in their respective axes)
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //This is to check if we are inside the bound on the Y-axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }*/


    private void LateUpdate()
    {
        // Update the position of the camera to be the same as the position of the player
        transform.position = new Vector3(lookAt.position.x, lookAt.position.y, -10);
    }
}
