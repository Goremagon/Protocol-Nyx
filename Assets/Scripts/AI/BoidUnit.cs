using UnityEngine;

namespace ProjectNyx
{
    [System.Serializable]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BoidUnit : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Vector2 velocity = Vector2.zero;
        [SerializeField] private Vector2 acceleration = Vector2.zero;
        [SerializeField] public float perceptionRadius = 10f;
        [SerializeField] private float avoidanceRadius = 3f;
        public float maxSpeed = 5f;
        
        public Rigidbody2D Rigidbody => rb;
        public Vector2 Velocity => velocity;
        public Vector2 Acceleration => acceleration;
        public float PerceptionRadius => perceptionRadius;
        public float AvoidanceRadius => avoidanceRadius;

        private void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }

            if (rb == null)
            {
                Debug.LogWarning($"{nameof(BoidUnit)} on {name} requires a Rigidbody2D. Disabling behavior.");
                enabled = false;
            }
        }

        public void ApplyForce(Vector2 force)
        {
            acceleration += force;
        }
        
        // Physics update: apply force to Rigidbody2D
        public void UpdatePhysics()
        {
            if (rb == null)
            {
                return;
            }

            float deltaTime = Time.fixedDeltaTime;

            velocity += acceleration * deltaTime;
            rb.velocity = velocity;

            // Clamp velocity to prevent excessive speed (optional)
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10f);
            velocity = rb.velocity;

            ResetAcceleration();
            velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
            rb.velocity = velocity;
            acceleration = Vector2.zero;
        }
        
        // Reset acceleration for next frame
        public void ResetAcceleration()
        {
            acceleration = Vector2.zero;
        }
    }
}
