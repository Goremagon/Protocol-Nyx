# Map Boundary System Setup Guide

This document explains how to set up the map boundary system that keeps the player ship within defined limits.

## Overview

The map boundary system prevents the player ship from moving outside of defined boundaries. This replaces the need for screen wrapping since the camera follows the player.

## Setup Instructions

### 1. Attach MapBoundary Component

1. Create an empty GameObject in your scene (e.g., "BoundaryManager")
2. Attach the MapBoundary.cs script to this GameObject
3. Position this GameObject anywhere in the scene (it doesn't need to be in the player's hierarchy)

### 2. Configure Boundary Settings

In the MapBoundary inspector:
- **Boundary Min**: Minimum X and Y coordinates (default: -50, -50)
- **Boundary Max**: Maximum X and Y coordinates (default: 50, 50)
- **Clamp Position**: Enable to keep player within boundaries (default: true)
- **Wrap Around**: Enable to wrap player to opposite side when going out of bounds (default: false)

### 3. Assign Player Ship

1. The system automatically finds the player ship by looking for an object tagged "Player"
2. Ensure your player ship has the "Player" tag in the Inspector

## Usage Examples

### Basic Boundary Setup
```csharp
// The system automatically clamps the player position to the defined boundaries
// No additional code needed
```

### Custom Boundary Limits
```csharp
// In another script, you can modify boundaries
MapBoundary boundarySystem = FindObjectOfType<MapBoundary>();
boundarySystem.SetBoundaries(new Vector2(-100, -100), new Vector2(100, 100));
```

### Switching Between Clamping and Wrapping
```csharp
// Enable wrapping instead of clamping
MapBoundary boundarySystem = FindObjectOfType<MapBoundary>();
boundarySystem.SetWrapAround(true);
boundarySystem.SetClampPosition(false);
```

## Technical Details

### How It Works
1. The system finds the player ship by tag "Player"
2. In LateUpdate, it checks the player's position against boundary limits
3. If clamping is enabled, the player's position is constrained to the boundaries
4. If wrapping is enabled, the player wraps to the opposite side when going out of bounds

### Boundary Matching with Camera
The boundary values are designed to match the camera's movement limits. When the camera follows the player, it will stop at the same boundary edges, ensuring consistent gameplay.

## Troubleshooting

### Player Moving Outside Boundaries
1. Verify the boundary values are set correctly
2. Check that the player ship has the "Player" tag
3. Ensure the MapBoundary component is attached to a GameObject in the scene

### Boundaries Not Working
1. Confirm the MapBoundary component is enabled
2. Check that the player ship is tagged "Player"
3. Verify the component is not disabled in the inspector

### Camera Not Following Boundaries
1. The camera will follow the player, but boundaries are enforced by the MapBoundary system
2. Ensure the boundary values match your camera's movement limits
3. The camera will stop at the boundary edges, but the player will be clamped to those same edges