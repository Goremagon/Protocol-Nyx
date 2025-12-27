# CameraFollow Component Setup Guide

This document explains how to set up the CameraFollow component to keep the player's ship centered on the screen at all times.

## Overview

The CameraFollow component automatically follows a target (typically the player's ship) with smooth movement and maintains the correct Z-depth. It uses LateUpdate to prevent jitter and provides several configuration options.

## How to Set Up

### 1. Attach the Component
1. Select your Main Camera in the Hierarchy
2. Drag the CameraFollow.cs script onto the camera object
3. The component will be added to the camera's inspector

### 2. Configure the Target
In the CameraFollow inspector:
- **Target**: Assign the Transform of your player ship
  - If left empty, the component will automatically search for an object tagged "Player"
  - You can also assign it dynamically using the SetTarget() method

### 3. Adjust Camera Settings
- **Smooth Speed**: Controls how smoothly the camera follows the target (0.125f is a good default)
- **Offset**: Position offset from the target (default: Vector3(0, 0, -10) to maintain proper Z-depth)

### 4. Camera Boundaries (Optional)
- **Use Camera Bounds**: Enable to limit camera movement to specific area
- **Camera Bounds Min/Max**: Define the boundaries for camera movement

## Usage Examples

### Basic Setup
For a simple following camera:
1. Assign the player ship's Transform to the Target field
2. Keep default offset (-10 on Z-axis)
3. Adjust smooth speed as needed

### Dynamic Target Assignment
```csharp
// In another script, you can change the target dynamically
CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
cameraFollow.SetTarget(newTargetTransform);
```

### Custom Offset
```csharp
// Change the camera offset
cameraFollow.SetOffset(new Vector3(0, 0, -15)); // Move camera further back
```

## Technical Details

### Why LateUpdate?
The camera uses LateUpdate instead of Update to ensure it follows the target after all movement has been processed, preventing jitter or lag.

### Automatic Target Detection
If no target is assigned, the component will automatically search for any GameObject tagged "Player" in the scene.

### Smooth Movement
The camera uses Vector3.Lerp to create smooth, fluid movement between positions rather than immediate jumps.

## Troubleshooting

### Camera Not Following
1. Ensure the Target field is assigned to the player ship's Transform
2. Verify the player ship has a Transform component
3. Check that the camera's Z position is appropriate for your scene

### Camera Jittering
1. Increase the Smooth Speed value
2. Ensure the component is attached to the Main Camera
3. Verify that no other scripts are modifying the camera's position

### Camera Going Outside Bounds
1. Check that Camera Bounds are enabled
2. Verify the boundary values are appropriate for your scene
3. Ensure the target doesn't move outside the defined boundaries