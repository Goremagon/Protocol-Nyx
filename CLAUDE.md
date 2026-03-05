# Protocol Nyx - Coding Guidelines & Agent Protocol

## 1. Tech Stack
- **Engine**: Unity 6 LTS (2D Core)
- **Pipeline**: Universal Render Pipeline (URP) with 2D Renderer
- **Input**: Unity Input System (New)
- **Language**: C# (.NET Standard 2.1)
- **Architecture**: Component-based, Finite State Machines (FSM), ScriptableObject Architecture

## 2. Code Style & Standards
- **Namespace**: All scripts must be wrapped in `namespace ProjectNyx { ... }`.
- **Variables**:
  - `public PascalCase` (Avoid unless necessary for API)
  - `[SerializeField] private camelCase` (Preferred for Inspector exposure)
  - `private _camelCase` or `camelCase` (Internal state)
- **Physics**: 
  - Use `Rigidbody2D` for movement.
  - Apply forces in `FixedUpdate` (or via custom physics methods called in Update if delta time is managed manually).
  - Avoid `transform.Translate` for physics objects.
- **Serialization**: Use `[System.Serializable]` for data classes and structs.

## 3. Core Systems
- **AI (Sentinels)**:
  - **Physics**: Handled by `BoidUnit.cs` (Rigidbody2D wrapper).
  - **Logic**: Handled by `StateMachine.cs` (Generic FSM) + `SentinelStates.cs`.
  - **Data**: Behavior weights are stored in `FlockingBehavior` ScriptableObjects.
- **Player**:
  - `PlayerController.cs` handles Input -> Action mapping.
  - `ShipMotor.cs` handles raw movement physics.
- **Managers**: Singleton pattern used for `GameManager` and `InputManager`.

## 4. Workflows
- **Prefabs**: Always edit logic on Prefabs, not Scene instances.
- **Layers**: Critical layers include "Player", "Enemy", "Sentinel", "Obstacle".
- **Tags**: Use "Eldritch" for enemies, "Player" for the hero.

## 5. Build & Test
- Ensure no compilation errors before finishing a task.
- When creating new AI, ensure `FlockingBehavior` assets are assigned in the Inspector.