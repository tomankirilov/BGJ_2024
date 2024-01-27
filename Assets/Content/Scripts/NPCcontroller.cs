using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
   public Transform[] waypoints;           // Array of waypoints for the NPC to move to
    public float moveSpeed = 3f;            // Movement speed of the NPC
    public float rotationSpeed = 5f;        // Rotation speed of the NPC
    public float pauseDuration = 2f;        // Default duration to pause at each waypoint (in seconds)
    public Transform[] pauseTriggers;       // Array of Transform objects to trigger pauses

    private int currentWaypointIndex = 0;   // Index of the current waypoint
    private bool isPaused = false;          // Flag to indicate if NPC is paused at a waypoint
    private float pauseTimer = 0f;          // Timer to track pause duration

    void Update()
    {
        if (!isPaused)
        {
            // Move towards the current waypoint
            MoveTowardsWaypoint();

            // Check if the NPC has reached the current waypoint
            if (HasReachedWaypoint())
            {
                // Check if the current waypoint matches any pause trigger
                foreach (Transform trigger in pauseTriggers)
                {
                    if (trigger != null && trigger.position == waypoints[currentWaypointIndex].position)
                    {
                        StartPause();
                        return; // Exit the loop early if a pause trigger is found
                    }
                }

                // Move to the next waypoint if no pause trigger is found
                MoveToNextWaypoint();
            }
            else
            {
                // Rotate towards the next waypoint
                RotateTowardsWaypoint();
            }
        }
        else
        {
            // Increment pause timer
            pauseTimer += Time.deltaTime;

            // Check if pause duration has elapsed
            if (pauseTimer >= pauseDuration)
            {
                // Move to the next waypoint
                MoveToNextWaypoint();
                isPaused = false;
            }
        }
    }

    void MoveTowardsWaypoint()
    {
        // Move NPC towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
    }

    bool HasReachedWaypoint()
    {
        // Check if NPC has reached the current waypoint
        float distance = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        return distance < 0.1f;
    }

    void MoveToNextWaypoint()
    {
        // Move to the next waypoint in the array
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void StartPause()
    {
        // Start pause timer
        isPaused = true;
        pauseTimer = 0f;
    }

    void RotateTowardsWaypoint()
    {
        // Calculate direction to the next waypoint
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        direction.y = 0f; // Ignore vertical difference

        // Calculate rotation towards the next waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the NPC towards the next waypoint
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
