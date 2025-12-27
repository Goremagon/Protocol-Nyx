using UnityEngine;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{
    [Header("Ship Identity")]
    public string shipName;
    public string shipClass; // "Shuttle", "Frigate"

    // --- HEALTH & DEFENSE ---
    [Header("Health & Armor")]
    public float hullCurrent;
    public float hullMax;
    public float baseArmor; // Flat damage reduction
    
    // --- RESOURCES ---
    [Header("Crew & Power")]
    public int crewCurrent;
    public int crewMax; // Defined by the Hull size (e.g. 5 for Shuttle)
    
    public float reactorPowerCurrent;
    public float reactorPowerMax;

    // --- LOADOUT ---
    [Header("Installed Modules")]
    public List<ShipModule> modules = new List<ShipModule>();

    void Start()
    {
        RecalculateStats();
        hullCurrent = hullMax; // Heal to full on start
        reactorPowerCurrent = reactorPowerMax;
    }

    void Update()
    {
        // Run logic for every installed gun/shield
        foreach (var mod in modules)
        {
            // Only run if we have enough crew/power
            if (mod.isActive) 
            {
                mod.TickModule(this);
            }
        }
    }

    // Call this when you equip items or lose crew
    public void RecalculateStats()
    {
        // 1. Reset Stats to Hull Defaults
        float totalArmor = baseArmor;
        float totalMaxHP = 100f; // Example base HP

        // 2. Check Resources
        int crewUsed = 0;

        foreach (var mod in modules)
        {
            // Add up bonuses (e.g. Armor Plates)
            totalArmor += mod.addedArmor;
            totalMaxHP += mod.addedHull;

            // Check Crew Requirement
            if (mod.crewCost > 0)
            {
                if (crewCurrent - crewUsed >= mod.crewCost)
                {
                    mod.isActive = true;
                    crewUsed += mod.crewCost;
                }
                else
                {
                    mod.isActive = false; // Not enough people to run this gun!
                    Debug.LogWarning($"🚫 {mod.moduleName} Offline: Understaffed.");
                }
            }
        }

        // 3. Apply Totals
        hullMax = totalMaxHP;
        baseArmor = totalArmor;
        
        // Clamp HP
        if (hullCurrent > hullMax) hullCurrent = hullMax;
    }

    // --- COMBAT ---
    public void TakeDamage(float incomingDamage)
    {
        // 1. Armor Reduction
        float actualDamage = incomingDamage - baseArmor;
        if (actualDamage < 1) actualDamage = 1; // Always take at least 1 damage

        // 2. Apply Damage
        hullCurrent -= actualDamage;

        Debug.Log($"💥 {shipName} hit! Took {actualDamage} dmg. (HP: {hullCurrent}/{hullMax})");

        if (hullCurrent <= 0)
        {
            Debug.Log($"💀 {shipName} DESTROYED!");
            Destroy(gameObject); // Poof
        }
    }

    // --- DEBUG TESTER ---
    [ContextMenu("Test Fire All Guns")]
    public void TestFireAll()
    {
        foreach (var mod in modules)
        {
            // Check if this module is actually a Weapon
            WeaponModule weapon = mod as WeaponModule;
            if (weapon != null)
            {
                // Fire at... ourselves for testing? Or just into space.
                weapon.FireWeapon(this); 
            }
        }
    }
}