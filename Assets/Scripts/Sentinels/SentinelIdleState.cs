using UnityEngine;

namespace ProjectNyx
{
    public class SentinelIdleState : State<SentinelBase>
    {
        public override void Execute()
        {
            // Placeholder behaviour: keep scanning for enemies while idle
            if (owner == null)
            {
                return;
            }

            owner.ScanForNeighbors();
            owner.ScanForEnemies();
        }
    }
}
