using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, verticalInput);
        moveDirection *= speed;

        transform.position += moveDirection * Time.deltaTime;
    }
}
