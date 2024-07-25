using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float lagSpeed = 5f;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        // Move the camera towards the player's position with a slight lag
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, -5);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lagSpeed);
    }
}
