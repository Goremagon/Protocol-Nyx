using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Transform playerTransform;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Find the player automatically
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            // If player is dead or missing, stop trying to find them
            Debug.LogWarning("Enemy could not find Player!");
        }
    }
    
    void FixedUpdate()
    {
        // Only move if we have a player to chase AND a body to move
        if (playerTransform != null && rb != null)
        {
            // 1. Get the direction
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            
            // 2. Push the enemy towards the player
            rb.AddForce(direction * moveSpeed);

            // 3. Optional: Look at the player (Rotate to face them)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}