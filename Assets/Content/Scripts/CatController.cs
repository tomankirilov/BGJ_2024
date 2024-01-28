using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
   public float walkSpeed; // Walking speed of the player
    public float runSpeed = 10f; // Running speed of the player
    public float rotationSpeed = 100f; // Rotation speed of the player
    public float jumpForce = 10f; // Force applied when jumping

    public Animator anim;

    private Rigidbody rb;
    private bool isGrounded; // Flag to track if the player is grounded


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        Physics.gravity = new Vector3(0, -50, 0);
        anim.GetComponentInChildren<Animator>();
         
        
    }

    void Update()
    {
        Walk();
       jump();
        

    }

    void FixedUpdate() 
    {

    }

    // Check if the player is grounded
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Walk()
    {
// Get input from WASD keys and Shift key
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (movement.magnitude > 0 && isGrounded)
    {
        // Trigger animation here
        anim.SetBool("Walk", true);
    }
    else if(movement.magnitude == 0 && isGrounded)
    {
        // Set animation parameter to false if there is no movement
        anim.SetBool("Walk", false);
    }
        // Rotate the player based on movement direction
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Calculate speed based on whether running
        float speed = isRunning ? runSpeed : walkSpeed;

        // Move the player
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        Debug.Log("Working");
    }

    private void jump()
    {
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        // Jumping
        if (isGrounded && isJumping)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Player is no longer grounded after jumping
        }
    }

}
