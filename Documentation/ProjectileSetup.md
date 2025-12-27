# Projectile System Setup Guide

This document explains how to set up the projectile system for shooting in your Unity game.

## Overview

The projectile system allows your player ship to fire projectiles with configurable speed, damage, and lifetime. It includes automatic cleanup after the projectile's lifetime expires.

## Setup Instructions

### 1. Create Projectile Prefab

1. Create a new GameObject (e.g., a simple circle or sprite)
2. Add a Rigidbody2D component to the GameObject
3. Add a Collider2D component (e.g., CircleCollider2D)
4. Add the Projectile.cs script to the GameObject
5. Create a prefab from this GameObject
6. Name the prefab "Projectile" (or any name you prefer)

### 2. Configure Projectile Settings

In the Projectile inspector:
- **Speed**: Adjust how fast the projectile moves (default: 20f)
- **Damage**: Set the damage amount (default: 1)
- **Lifetime**: Time in seconds before projectile is destroyed (default: 3f)

### 3. Assign Projectile Prefab to Ship

1. Select your player ship in the Hierarchy
2. In the ShipMotor component, assign the projectile prefab to the "Projectile Prefab" field
3. Adjust fire rate and projectile speed as needed

## Usage Examples

### Basic Shooting
```csharp
// The system automatically handles firing when Spacebar is pressed
// or when a UI button is pressed (if using virtual joystick)
```

### Custom Projectile Settings
```csharp
// In another script, you can modify projectile properties
Projectile projectile = projectilePrefab.GetComponent<Projectile>();
projectile.SetDamage(5);  // Set damage to 5
projectile.SetSpeed(30f); // Set speed to 30
```

## Technical Details

### How It Works
1. When the fire input is detected, a projectile is instantiated at the ship's position
2. The projectile moves forward based on its rotation
3. The projectile automatically destroys itself after its lifetime expires
4. On collision with enemies or obstacles, damage is applied and projectile is destroyed

### Collision Handling
- Projectiles destroy themselves when hitting objects tagged "Enemy" or "Obstacle"
- If the hit object implements IDamageable, damage is applied through the TakeDamage() method
- Projectiles are destroyed on impact with any tagged object

## Troubleshooting

### No Projectiles Being Fired
1. Ensure the player ship has a ShipMotor component
2. Verify the projectile prefab is assigned in the ShipMotor component
3. Check that the InputManager has a "Fire" action configured
4. Ensure the player ship has the "Player" tag

### Projectiles Not Destroying
1. Check that the projectile has a Rigidbody2D component
2. Verify the lifetime value is set correctly
3. Ensure the projectile is not being destroyed by other scripts

### Projectiles Not Damaging Enemies
1. Ensure enemy objects have the "Enemy" tag
2. Verify enemy objects implement the IDamageable interface
3. Check that the projectile's OnTriggerEnter2D method is working correctly