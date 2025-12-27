using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Move the bullet forward (up)
        if (rb != null) rb.linearVelocity = transform.up * speed;
        
        // Destroy bullet after 3 seconds so it doesn't clutter the game
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If we hit an enemy, destroy both the enemy and the bullet
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);
            // Add score before destroying bullet
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(15);
            }
            else
            {
                Debug.LogWarning("GameManager.Instance is null. Score not updated.");
            }
            // Destroy the bullet
            Destroy(gameObject);
        }
        // If we hit an obstacle, just destroy the bullet
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
