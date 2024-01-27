using UnityEngine;
using UnityEngine.AI;

public class NPCChasePlayer : MonoBehaviour
{
    public float chaseRadius = 10f;         // Radius within which NPC starts chasing the player
    public LayerMask playerLayer;           // Layer mask for the player

    private NavMeshAgent agent;             // Reference to the NavMeshAgent component
    private Transform playerTransform;      // Reference to the player's transform
    private bool isChasingPlayer = false;   // Flag to indicate if NPC is chasing the player

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component attached to the NPC
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    void Update()
    {
        // Check if the player is within the chase radius
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= chaseRadius)
        {
            isChasingPlayer = true;
        }
        
        // If the player is within the chase radius or NPC is already chasing the player, set player's position as the target destination
        if (isChasingPlayer)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to represent the chase radius in the Unity editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}