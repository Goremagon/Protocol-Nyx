using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [Header(" targeting Logic")]
    public float range = 20f;        // How far can this gun see?
    public float rotationSpeed = 5f; // How fast can the turret spin?
    
    [Header("Status")]
    public Transform currentTarget;
    public bool lockedOn = false;

    // References
    private WeaponModule weapon;

    void Start()
    {
        weapon = GetComponent<WeaponModule>();
        // If no range set, default to 20
        if (range <= 0) range = 20f;
    }

    void Update()
    {
        // 1. Find a target if we don't have one (or current one died)
        if (currentTarget == null)
        {
            FindNearestEnemy();
            lockedOn = false;
        }
        else
        {
            // 2. Check if target is still in range
            float dist = Vector2.Distance(transform.position, currentTarget.position);
            if (dist > range)
            {
                currentTarget = null; // Lost them!
                return;
            }

            // 3. Aim at them!
            AimAtTarget();
        }
    }

    void FindNearestEnemy()
    {
        // Find ALL objects tagged "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            currentTarget = nearestEnemy.transform;
        }
    }

    void AimAtTarget()
    {
        // Math to calculate angle to target
        Vector2 direction = currentTarget.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 adjustment for Sprite orientation
        
        // Smooth rotation (so it doesn't snap instantly)
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if we are pointing roughly at the enemy (Angle < 10 degrees)
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
        if (angleDifference < 10f)
        {
            lockedOn = true;
            // OPTIONAL: Auto-Fire if locked on?
             weapon.FireWeapon(null); // Passing null because we just fire forward
        }
        else
        {
            lockedOn = false;
        }
    }
    
    // Visualize Range in Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}