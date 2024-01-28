using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoints : MonoBehaviour
{
    public int pointsToAdd = 10; // Points to add when object enters collider
    private int totalPoints = 0; // Total points earned

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a specific tag (you can customize this condition as needed)
        if (other.CompareTag("GroundPoints"))
        {
            // Add points when player enters the collider
            totalPoints += pointsToAdd;

            // Optionally, you can play a sound effect or perform other actions here

            Debug.Log("Total points: " + totalPoints); // Print total points to console (optional)
        }
    }
}
