using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Player's transform
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the player
    public float smoothSpeed = 0.125f; // Smoothness of camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = target.position + offset;
            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera's position
            transform.position = smoothedPosition;

            // Make the camera look at the player
            transform.LookAt(target);
        }
    }
}
