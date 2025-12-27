using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    
    private float nextFireTime;
    private Transform playerTransform;
    
    void Start()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("EnemyShooting has no projectilePrefab assigned. Disabling.");
            enabled = false;
            return;
        }

        // Find the player automatically
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("No object found with tag 'Player'. Enemy will not shoot.");
        }
        
        nextFireTime = Time.time;
    }
    
    void Update()
    {
        if (playerTransform != null && Time.time >= nextFireTime)
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
            
            // Rotate bullet to face player
            Vector2 direction = playerTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            // Set next fire time
            nextFireTime = Time.time + fireRate;
        }
    }
}
