using UnityEngine;

public class WeaponModule : ShipModule
{
    [Header("Weapon Stats")]
    public float damage = 10f;
    public float cooldownTime = 1.0f;
    private float currentCooldown = 0f;

    [Header("Targeting")]
    [Range(0, 360)] public float firingArc = 360f; // 360 = Turret, 10 = Spinal
    public Transform turretPivot; // Assign the part that spins (optional)

    public override void TickModule(Ship ship)
    {
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
        
        // (Optional: Code to rotate the turret graphic toward the mouse goes here)
    }

    public void FireWeapon(Ship targetShip)
    {
        // 1. Check Cooldown & Active Status
        if (currentCooldown > 0 || !isActive) return;

        // 2. CHECK SPINAL MOUNT ANGLE
        // If this is a Spinal weapon (low arc), check if target is in front of us
        if (firingArc < 360 && targetShip != null)
        {
            // Get direction to target
            Vector3 dirToTarget = (targetShip.transform.position - transform.position).normalized;
            // Calculate angle between "Forward" and "Target"
            float angle = Vector3.Angle(transform.up, dirToTarget); // Assumes Y-Up is forward in 2D

            if (angle > firingArc / 2)
            {
                Debug.Log($"🚫 Target out of angle! Turn ship to aim {moduleName}.");
                return; // Don't fire
            }
        }

        // 3. Fire!
        Debug.Log($"💥 {moduleName} FIRED! ({damage} dmg)");
        if (targetShip != null) targetShip.TakeDamage(damage);
        currentCooldown = cooldownTime;
    }
}