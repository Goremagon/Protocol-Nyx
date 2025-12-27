using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    void Awake()
    {
        // Singleton Setup
        if (Instance == null) 
        { 
            Instance = this; 
            // Fixes the "DontDestroyOnLoad" yellow warning
            if (transform.parent == null) 
            {
                DontDestroyOnLoad(gameObject); 
            }
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }

    public Vector2 GetMoveInput() 
    {
        // Simple WASD / Arrow Keys
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    
    public bool GetFireInput() 
    {
        // Simple Spacebar Check
        return Input.GetKey(KeyCode.Space); 
    }
}