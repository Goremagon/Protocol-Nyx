using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMotor : MonoBehaviour
{
    [Header("Engine Specs")]
    public float forwardThrust = 1000f;  // Power to move forward
    public float strafeThrust = 400f;    // Power to move sideways (weaker)
    public float rotationSpeed = 200f;   // Power to turn (Torque)

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Read Input (WASD / Arrows)
        // Returns -1 to 1 based on key press
        float x = Input.GetAxisRaw("Horizontal"); // A/D
        float y = Input.GetAxisRaw("Vertical");   // W/S
        
        moveInput = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        // 2. Apply Rotation (Torque)
        // Negative because "Right" (D) means turning Negative Degrees (Clockwise)
        float turn = -moveInput.x * rotationSpeed * Time.fixedDeltaTime;
        rb.AddTorque(turn);

        // 3. Apply Forward/Back Thrust (Force)
        // We push in the direction the ship is FACING (transform.up)
        Vector2 force = transform.up * moveInput.y * forwardThrust * Time.fixedDeltaTime;
        rb.AddForce(force);

        // Optional: Drift dampening (Space brakes)
        if (moveInput.sqrMagnitude == 0)
        {
            // If let go of keys, slow down slightly faster (Space friction)
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 1f * Time.fixedDeltaTime);
        }
    }
}
