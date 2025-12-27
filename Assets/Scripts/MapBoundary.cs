using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    [Header("Boundary Settings")]
    [SerializeField] private Vector2 boundaryMin = new Vector2(-50f, -50f);  // Minimum boundary coordinates
    [SerializeField] private Vector2 boundaryMax = new Vector2(50f, 50f);   // Maximum boundary coordinates
    
    [Header("Boundary Behavior")]
    [SerializeField] private bool clampPosition = true;  // Whether to clamp position to boundaries
    [SerializeField] private bool wrapAround = false;    // Whether to wrap around when going out of bounds
    
    private Transform targetTransform;
    private Camera mainCamera;
    
    void Start()
    {
        // Find the player ship (assuming it has "Player" tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetTransform = player.transform;
        }
        
        // Get the main camera
        mainCamera = Camera.main;
    }
    
    void LateUpdate()
    {
        // Only process if we have a target
        if (targetTransform != null)
        {
            Vector3 newPosition = targetTransform.position;
            
            // Apply boundary constraints
            if (clampPosition)
            {
                // Clamp the position to the boundary limits
                newPosition.x = Mathf.Clamp(newPosition.x, boundaryMin.x, boundaryMax.x);
                newPosition.y = Mathf.Clamp(newPosition.y, boundaryMin.y, boundaryMax.y);
            }
            else if (wrapAround)
            {
                // Wrap around the boundaries
                if (newPosition.x < boundaryMin.x)
                    newPosition.x = boundaryMax.x;
                else if (newPosition.x > boundaryMax.x)
                    newPosition.x = boundaryMin.x;
                    
                if (newPosition.y < boundaryMin.y)
                    newPosition.y = boundaryMax.y;
                else if (newPosition.y > boundaryMax.y)
                    newPosition.y = boundaryMin.y;
            }
            
            // Update the target's position
            targetTransform.position = newPosition;
        }
    }
    
    // Public method to set boundary limits
    public void SetBoundaries(Vector2 min, Vector2 max)
    {
        boundaryMin = min;
        boundaryMax = max;
    }
    
    // Public method to get current boundaries
    public Vector2 GetBoundaryMin()
    {
        return boundaryMin;
    }
    
    public Vector2 GetBoundaryMax()
    {
        return boundaryMax;
    }
    
    // Public method to enable/disable clamping
    public void SetClampPosition(bool clamp)
    {
        clampPosition = clamp;
    }
    
    // Public method to enable/disable wrapping
    public void SetWrapAround(bool wrap)
    {
        wrapAround = wrap;
    }
}