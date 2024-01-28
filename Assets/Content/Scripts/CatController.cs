using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
   public float walkSpeed = 5f; // Walking speed of the player
    public float runSpeed = 10f; // Running speed of the player
    public float rotationSpeed = 100f; // Rotation speed of the player
    public float jumpForce = 10f; // Force applied when jumping

    private Animator anim;

    private Rigidbody rb;
    private bool isGrounded; // Flag to track if the player is grounded


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
        Physics.gravity = new Vector3(0, -100, 0);
         
        
    }

    void Update()
    {
       Walk();
       jump();
        

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

    private void walk()
    {
        anim.SetBool("Walk", true);
    }

    private void Idle()
    {
        anim.SetBool("Walk", false);
    }

    private void Walk()
    {
// Get input from WASD keys and Shift key

if(Input.GetKeyDown(KeyCode.W) && (KeyCode.A) && (KeyCode.D) && (Input.GetKeyDown(KeyCode.S)))
{
    
}
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
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
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
