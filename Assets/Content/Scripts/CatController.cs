using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
   public float walkSpeed = 5f; // Walking speed of the player
    public float runSpeed = 10f; // Running speed of the player
    public float rotationSpeed = 100f; // Rotation speed of the player

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    void Update()
    {
        // Get input from WASD keys and Shift key
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Rotate the player based on movement direction
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Calculate speed based on whether running
        float speed = isRunning ? runSpeed : walkSpeed;

        // Move the player
        rb.velocity = movement * speed;
    }

    // Method to handle collisions with physics objects
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Rigidbody component
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        
        if (otherRigidbody != null)
        {
            // Calculate push direction (opposite to player's movement direction)
            Vector3 pushDirection = -rb.velocity.normalized;

            // Apply force to the other object
            otherRigidbody.AddForce(pushDirection * rb.velocity.magnitude * 100f);
        }
    }
}
