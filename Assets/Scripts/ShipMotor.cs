using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMotor : MonoBehaviour
{
    [Header("Movement")]
    public float forwardThrust = 1000f;
    public float rotationSpeed = 200f;

    [Header("Combat")]
    public GameObject projectilePrefab;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private Rigidbody2D rb;

    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        // Handle Shooting
        if (InputManager.Instance != null && InputManager.Instance.GetFireInput())
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null)
        {
            // Simple instantiation - no complex setup needed
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        Vector2 input = (InputManager.Instance != null) ? InputManager.Instance.GetMoveInput() : Vector2.zero;
        
        // Rotate
        rb.AddTorque(-input.x * rotationSpeed * Time.fixedDeltaTime);
        
        // Move Forward
        if (input.y > 0)
            rb.AddForce(transform.up * input.y * forwardThrust * Time.fixedDeltaTime);
            
        // Space Friction (Stop when not inputting)
        if (input.sqrMagnitude < 0.01f)
            rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, 1f * Time.fixedDeltaTime);
    }
}