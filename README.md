Project Nyx (Protocol Nyx)
==========================

High level repository README for the Unity 6 LTS project.

Quick start
-----------
- Open Unity Hub and add the project at `My project`.
- Unity version: 6 LTS.
- Render pipeline: URP with 2D lighting.

Repo layout
-----------
- `My project/`: Unity project root (Assets, ProjectSettings, Packages).
- `Documentation/`: setup guides for camera, input, prefabs, and projectiles.
- `MASTER_DESIGN.md`: master design doc (GDD).
- `Master_Plan.md`: roadmap and technical constraints.
- `General Outline.md`: narrative and gameplay overview.

Key constraints
---------------
- 2D physics only (`Rigidbody2D`, `Collider2D`).
- Swarm scale performance requires pooling and spatial partitioning.
- New Unity Input System for touch plus mouse/keyboard.
