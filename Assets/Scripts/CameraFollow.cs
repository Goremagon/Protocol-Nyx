using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform target;          // The ship to follow
    [SerializeField] private float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // Offset to maintain correct Z-depth
    
    [Header("Camera Boundaries")]
    [SerializeField] private bool useCameraBounds = false;
    [SerializeField] private Vector2 cameraBoundsMin = new Vector2(-10, -10);
    [SerializeField] private Vector2 cameraBoundsMax = new Vector2(10, 10);
    
    private Camera mainCamera;
    
    void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;
        
        // If no target is assigned, try to find the player ship
        if (target == null)
        {
            GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
            if (playerShip != null)
            {
                target = playerShip.transform;
            }
        }
    }
    
    void LateUpdate()
    {
        // Only follow if we have a target
        if (target != null)
        {
            // Calculate the desired position with offset
            Vector3 desiredPosition = target.position + offset;
            
            // Apply camera boundaries if enabled
            if (useCameraBounds)
            {
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, cameraBoundsMin.x, cameraBoundsMax.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, cameraBoundsMin.y, cameraBoundsMax.y);
            }
            
            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // Update camera position
            transform.position = smoothedPosition;
        }
    }
    
    // Public method to set the target (useful for dynamic assignment)
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
    // Public method to update offset
    public void SetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }
    
    // Public method to update smooth speed
    public void SetSmoothSpeed(float newSmoothSpeed)
    {
        smoothSpeed = newSmoothSpeed;
    }
}