using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
    public Rigidbody playerRb;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // relative direction
        Vector3 direction = transform.right * x + transform.forward * z;
        direction *= moveSpeed;
        direction.y = playerRb.velocity.y;

        playerRb.velocity = direction;
    }
}
