using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoints : MonoBehaviour
{
     public int pointsToAdd = 10; // Points to add when object enters collider

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a specific tag (you can customize this condition as needed)
        if (other.CompareTag("Player"))
        {
            // Add points when player enters the collider
            ScoreManager.Instance.AddPoints(pointsToAdd);

            // Optionally, you can play a sound effect or perform other actions here
        }
    }
}
