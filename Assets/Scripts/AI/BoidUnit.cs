using UnityEngine;

namespace ProjectNyx
{
    [System.Serializable]
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

        public void ApplyForce(Vector2 force)
        {
            acceleration += force;
        }
        
        // Physics update: apply force to Rigidbody2D
        public void UpdatePhysics()
        {
            velocity += acceleration * Time.deltaTime;
            rb.velocity = velocity;

            // Clamp velocity to prevent excessive speed (optional)
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10f);
            velocity = rb.velocity;

            ResetAcceleration();
            velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
            rb.linearVelocity = velocity;
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
