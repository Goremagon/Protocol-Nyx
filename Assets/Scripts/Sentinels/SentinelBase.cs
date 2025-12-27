using UnityEngine;
using System.Collections.Generic; // Needed for Lists

namespace ProjectNyx
{
    // FIX: Require the correct StateMachine type
    [RequireComponent(typeof(BoidUnit))]
    public class SentinelBase : MonoBehaviour
    {
        [Header("Settings")]
        public float detectionRange = 15f;
        public float attackRange = 5f;
        public FlockingBehavior flockingConfig; // Link the ScriptableObject!

        // State & Data
        private BoidUnit boid;
        private StateMachine<SentinelBase> stateMachine;
        
        [HideInInspector] public Transform currentTarget;
        [HideInInspector] public List<BoidUnit> neighbors = new List<BoidUnit>();

        // Properties for States to access
        public BoidUnit Boid => boid;

        private void Awake()
        {
            boid = GetComponent<BoidUnit>();
            
            // Add StateMachine manually if missing, or get it
            stateMachine = GetComponent<StateMachine<SentinelBase>>();
            if (stateMachine == null) stateMachine = gameObject.AddComponent<StateMachine<SentinelBase>>();
            
            stateMachine.Initialize(this); // Tell the machine "I am the owner"
        }

        private void Start()
        {
            // Start in Idle
            stateMachine.ChangeState(new SentinelIdleState());
        }

        private void Update()
        {
            // Run the brain
            stateMachine.Update();
            
            // Run the physics
            boid.UpdatePhysics();
        }

        // Helper methods for States
        public void ScanForNeighbors()
        {
            neighbors.Clear();
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, boid.perceptionRadius);
            foreach (var hit in hits)
            {
                BoidUnit unit = hit.GetComponent<BoidUnit>();
                if (unit != null && unit != boid)
                {
                    neighbors.Add(unit);
                }
            }
        }

        public void ScanForEnemies()
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRange, LayerMask.GetMask("Enemy")); // Optimize with LayerMask later
            if (hit != null)
            {
                currentTarget = hit.transform;
            }
        }
    }
}