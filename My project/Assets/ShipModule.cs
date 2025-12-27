using UnityEngine;

// Your new 5-Tier System
public enum ModuleSize 
{ 
    ExtraSmall, // 20mm: Point Defense / Anti-Drone (Turrets)
    Small,      // 30mm - 57mm: Anti-Fighter / Corvettes
    Medium,     // 76mm - 127mm: Frigate Main Guns
    Large,      // 155mm - 203mm: Cruiser Batteries
    ExtraLarge  // 305mm+: Spinal Mounted Station Killers
}

public class ShipModule : MonoBehaviour
{
    // ... (The rest of the script stays exactly the same) ...
    [Header("Constraints")]
    public ModuleSize size; 
    // ...
}