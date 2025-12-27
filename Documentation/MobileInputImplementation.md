# Mobile Input Implementation for Unity Game

This document describes the implementation of a mobile input system that supports both desktop and mobile platforms using Unity's Input System.

## Overview

The implementation provides a seamless input experience across platforms by:
1. Automatically detecting if the game is running on mobile or desktop
2. Using Unity's Input System for desktop platforms
3. Providing a virtual joystick for mobile platforms

## Files Created

### 1. InputManager.cs
This is the central input manager that handles platform detection and input routing.

**Key Features:**
- Singleton pattern for global access
- Automatic platform detection (Android/iOS vs Desktop)
- Input routing between desktop Input System and virtual joystick
- Virtual joystick settings configuration

### 2. VirtualJoystick.cs
A draggable on-screen joystick component for mobile platforms.

**Key Features:**
- Touch-based drag interaction
- Configurable size and sensitivity
- Deadzone handling for precise control
- Integration with InputManager

### 3. ShipMotor.cs (Updated)
Modified to use the new InputManager instead of direct Input.GetAxis calls.

**Key Features:**
- Uses InputManager for input retrieval
- Maintains existing ship movement logic
- Compatible with both desktop and mobile input

## Implementation Details

### Platform Detection
The system automatically detects the platform:
- Mobile: Android or iOS platforms
- Desktop: All other platforms (Windows, Mac, Linux)

### Input Flow
1. **Desktop**: Uses Unity's Input System with Player input map
2. **Mobile**: Uses virtual joystick that sends input to InputManager
3. **Both**: ShipMotor.cs receives input through InputManager.GetMoveInput()

## Usage

1. Attach InputManager.cs to a GameObject in your scene
2. Attach VirtualJoystick.cs to a UI element in your scene
3. Configure the virtual joystick in the inspector
4. The system will automatically route input based on platform

## Configuration

### InputManager Settings
- `useVirtualJoystick`: Boolean flag (read-only, set automatically)
- `joystickDeadzone`: Sensitivity threshold for joystick input

### VirtualJoystick Settings
- `joystickSize`: Size of the joystick UI element
- `maxDistance`: Maximum distance the joystick can be dragged
- `background`: Reference to the joystick background UI element
- `joystick`: Reference to the joystick handle UI element

## Integration Notes

The implementation maintains backward compatibility with existing code while providing enhanced mobile support. The ShipMotor.cs file was updated to work with the new input system without changing the core movement logic.