using UnityEngine;

namespace ProjectNyx
{
    [CreateAssetMenu(fileName = "New Flocking Behavior", menuName = "Project Nyx/Flocking Behavior")]
    public class FlockingBehavior : ScriptableObject
    {
        [SerializeField] private float separationWeight = 1.0f;
        [SerializeField] private float alignmentWeight = 1.0f;
        [SerializeField] private float cohesionWeight = 1.0f;
        [SerializeField] private float targetWeight = 1.0f;
        
        public Vector2 CalculateForce(BoidUnit boid, List<BoidUnit> neighbors, Transform target = null)
        {
            Vector2 force = Vector2.zero;
            
            // Separation: steer away from nearby boids
            if (neighbors != null && neighbors.Count > 0)
            {
                Vector2 separationForce = Vector2.zero;
                int closeNeighbors = 0;
                
                foreach (var neighbor in neighbors)
                {
                    float distance = Vector2.Distance(boid.transform.position, neighbor.transform.position);
                    if (distance < boid.AvoidanceRadius)
                    {
                        separationForce += (boid.transform.position - neighbor.transform.position).normalized;
                        closeNeighbors++;
                    }
                }
                
                if (closeNeighbors > 0)
                {
                    separationForce /= closeNeighbors;
                    force += separationForce * separationWeight;
                }
            }
            
            // Alignment: steer towards average heading of neighbors
            if (neighbors != null && neighbors.Count > 0)
            {
                Vector2 alignmentForce = Vector2.zero;
                int validNeighbors = 0;
                
                foreach (var neighbor in neighbors)
                {
                    float distance = Vector2.Distance(boid.transform.position, neighbor.transform.position);
                    if (distance < boid.PerceptionRadius)
                    {
                        alignmentForce += neighbor.Velocity;
                        validNeighbors++;
                    }
                }
                
                if (validNeighbors > 0)
                {
                    alignmentForce /= validNeighbors;
                    force += alignmentForce * alignmentWeight;
                }
            }
            
            // Cohesion: steer towards average position of neighbors
            if (neighbors != null && neighbors.Count > 0)
            {
                Vector2 cohesionForce = Vector2.zero;
                int validNeighbors = 0;
                
                foreach (var neighbor in neighbors)
                {
                    float distance = Vector2.Distance(boid.transform.position, neighbor.transform.position);
                    if (distance < boid.PerceptionRadius)
                    {
                        cohesionForce += neighbor.transform.position;
                        validNeighbors++;
                    }
                }
                
                if (validNeighbors > 0)
                {
                    cohesionForce /= validNeighbors;
                    force += (cohesionForce - boid.transform.position) * cohesionWeight;
                }
            }
            
            // Target: steer towards target object
            if (target != null)
            {
                Vector2 directionToTarget = (target.position - boid.transform.position).normalized;
                force += directionToTarget * targetWeight;
            }
            
            return force;
        }
    }
}