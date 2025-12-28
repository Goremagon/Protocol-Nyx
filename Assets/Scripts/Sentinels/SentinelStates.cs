using UnityEngine;

namespace ProjectNyx
{
    public class SentinelIdleState : State<SentinelBase>
    {
        public override void Execute()
        {
            if (owner == null)
            {
                return;
            }

            owner.ScanForNeighbors();
            owner.ScanForEnemies();

            Vector2 force = owner.flockingConfig.CalculateForce(owner.Boid, owner.neighbors);
            owner.Boid.ApplyForce(force);

            if (owner.currentTarget != null)
            {
                stateMachine.ChangeState(new SentinelChaseState());
            }
        }
    }

    public class SentinelChaseState : State<SentinelBase>
    {
        public override void Execute()
        {
            if (owner == null)
            {
                return;
            }

            if (owner.currentTarget == null)
            {
                stateMachine.ChangeState(new SentinelIdleState());
                return;
            }

            owner.ScanForNeighbors();
            Vector2 force = owner.flockingConfig.CalculateForce(owner.Boid, owner.neighbors, owner.currentTarget);
            owner.Boid.ApplyForce(force);

            float distanceToTarget = Vector2.Distance(owner.transform.position, owner.currentTarget.position);
            if (distanceToTarget <= owner.attackRange)
            {
                stateMachine.ChangeState(new SentinelAttackState());
            }
        }
    }

    public class SentinelAttackState : State<SentinelBase>
    {
        public override void Execute()
        {
            if (owner == null)
            {
                return;
            }

            if (owner.currentTarget == null)
            {
                stateMachine.ChangeState(new SentinelChaseState());
                return;
            }

            float distanceToTarget = Vector2.Distance(owner.transform.position, owner.currentTarget.position);
            if (distanceToTarget > owner.attackRange)
            {
                stateMachine.ChangeState(new SentinelChaseState());
                return;
            }

            owner.Boid.ApplyForce(-owner.Boid.Velocity * 0.5f);

            Vector2 toTarget = owner.currentTarget.position - owner.transform.position;
            if (toTarget.sqrMagnitude > 0.0001f)
            {
                owner.transform.up = toTarget.normalized;
            }
        }
    }
}
