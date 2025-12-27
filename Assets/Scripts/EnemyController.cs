using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        // Destroy if off screen
        if (transform.position.y < -10f) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Note: For collisions, we check 'collision.gameObject'
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            // Destroy the enemy immediately so it doesn't pin the player
            Destroy(gameObject);
        }
    }
}