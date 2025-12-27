# Prefab Setup Guide for 2D Space Shooter

This document provides a complete guide for setting up the prefabs required for the 2D Space Shooter game in Unity.

## Overview

The game requires three main prefabs:
1. **Bullet/Projectile Prefab** - For player shooting mechanics
2. **Boundary Manager Prefab** - For keeping player within game boundaries
3. **Player Ship Prefab** - Main player character with all required components

## 1. Bullet/Projectile Prefab Setup

### Steps:
1. Create a new GameObject (e.g., a simple circle or sprite)
2. Add a Rigidbody2D component to the GameObject
3. Add a Collider2D component (e.g., CircleCollider2D)
4. Add the Projectile.cs script to the GameObject
5. Create a prefab from this GameObject
6. Name the prefab "Projectile"

### Configuration:
- **Rigidbody2D Settings:**
  - Body Type: Dynamic
  - Gravity Scale: 0 (no gravity)
  - Freeze Rotation: True (optional, to keep projectile upright)
  
- **Collider2D Settings:**
  - Is Trigger: True (to detect collisions without physical interaction)
  - Shape: Circle (or appropriate shape for your projectile)
  
- **Projectile Script Settings:**
  - Speed: 20f (default)
  - Damage: 1 (default)
  - Lifetime: 3f (default)

## 2. Boundary Manager Prefab Setup

### Steps:
1. Create an empty GameObject in your scene (e.g., "BoundaryManager")
2. Attach the MapBoundary.cs script to this GameObject
3. Position this GameObject anywhere in the scene (it doesn't need to be in the player's hierarchy)

### Configuration:
- **MapBoundary Script Settings:**
  - Boundary Min: (-50, -50) (default)
  - Boundary Max: (50, 50) (default)
  - Clamp Position: True (default)
  - Wrap Around: False (default)

## 3. Player Ship Prefab Setup

### Steps:
1. Create a new GameObject (e.g., a ship sprite)
2. Add a Rigidbody2D component to the GameObject
3. Add a Collider2D component (e.g., PolygonCollider2D or BoxCollider2D)
4. Add the ShipMotor.cs script to the GameObject
5. Add the InputManager.cs script to the GameObject
6. Create a prefab from this GameObject
7. Name the prefab "Player"

### Configuration:
- **Rigidbody2D Settings:**
  - Body Type: Dynamic
  - Gravity Scale: 0 (no gravity)
  - Freeze Rotation: False (to allow rotation)
  
- **Collider2D Settings:**
  - Is Trigger: False (to interact with other objects)
  - Shape: Polygon or Box (appropriate for your ship shape)
  
- **ShipMotor Script Settings:**
  - Forward Thrust: 1000f (default)
  - Strafe Thrust: 400f (default)
  - Rotation Speed: 200f (default)
  - Projectile Prefab: Assign the Projectile prefab created earlier
  - Fire Rate: 0.2f (default)
  - Projectile Speed: 20f (default)

- **InputManager Script Settings:**
  - Use Virtual Joystick: Should be set to true for mobile platforms

## Scene Setup

1. Create a new scene or open the existing "playership test.unity" scene
2. Place the Player prefab in the scene
3. Place the BoundaryManager prefab in the scene
4. Add a CameraFollow component to the main camera
5. Assign the player as the target for the camera

## Input System Setup

1. Ensure the InputSystem_Actions.inputactions file is properly configured
2. The "Player" action map should contain:
   - "Move" action (Vector2)
   - "Fire" action (Button)
3. The InputManager component should be attached to a GameObject in the scene

## Testing

1. Play the scene to verify:
   - Player movement works with keyboard or virtual joystick
   - Shooting works with spacebar or virtual fire button
   - Player stays within boundaries
   - Projectiles are destroyed after lifetime expires
   - Projectiles damage enemies on contact