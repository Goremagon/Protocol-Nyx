[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;
    public Transform shootPoint;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Movement (WASD or Arrow keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveInput = new Vector2(moveX, moveY);
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        // 2. Shooting (Spacebar or Mouse Click)
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }

    void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
            // Play sound if AudioManager exists
            if (AudioManager.Instance != null) AudioManager.Instance.PlayShoot();
        }
    }
}
