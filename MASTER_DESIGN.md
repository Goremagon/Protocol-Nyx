# PROJECT NYX: MASTER DESIGN DOCUMENT (GDD)

## 🤖 AI SYSTEM DIRECTIVES (READ FIRST)
**Role:** You are the Lead Unity Architect for "Project Nyx."
**Constraint Checklist:**
1.  **Engine:** Unity 6 LTS (2D URP).
2.  **Physics:** STRICTLY 2D (`Rigidbody2D`, `Vector2`, `Collider2D`). Do not use 3D physics.
3.  **Performance:** This is a "Swarm" game. Never use `FindObjectsOfType` or `FindNearestEnemy` in Update loops. Use **Spatial Hashing** or **Object Pooling**.
4.  **Input:** Must support hybrid controls (Touchscreen for Mobile + Mouse/Keyboard for PC) using the new Unity Input System.
5.  **Code Style:** Defensive coding. Always check for nulls. Use State Machines for AI.

---

## 1. THE VISION (Creative Overview)
**Genre:** Top-Down Space RTS / Cosmic Horror / Automation RPG.
**Visual Style:** High-fidelity Pixel Art, URP 2D Lighting, "Dyson Sphere" eternal night aesthetic.
**Core Hook:** "The Gardener of War." The player does NOT build units from a factory. You explore the fog of war to find dormant "Sentinel" hulks, reboot them, and they autonomously fight for you using Flocking logic.

### Narrative Arc
* **Protagonist:** A customizable Captain with a background (War Hero, Mechanic, etc.) that affects stats.
* **The Copilot:** "HELIOS," a glitched, sarcastic Ancient AI fused to the ship.
* **The Threat:** "The Dimming" caused by Eldritch Horrors (biological space swarms) and the "Corrupted Ones" (enslaved aliens).
* **The Goal:** Progress through 5 Acts, waking ancient "Sentinel" fleets to stop the Reaping Cycle of the Elder Gods.

---

## 2. GAMEPLAY MECHANICS
### A. The Sentinel System (Autonomy)
* **Discovery:** Player finds drifting hulks in the dark.
* **Reboot:** Spending resources activates the unit.
* **Behavior:** Units are NOT directly controllable. They use a **Finite State Machine (FSM)**:
    * *State 1:* Dormant.
    * *State 2:* Patrol (Flocking around beacons).
    * *State 3:* Engage (Swarm attacks against Eldritch).

### B. Economy & Automation
* **Mining:** Laser-fracturing asteroids.
* **Logistics:** "Collector Drones" automatically retrieve ore.
* **Loop:** Ore -> Refined Material -> Energy/Ammo.

### C. Combat & Equipment
* **Inventory:** Hull & Slot system (Tetris-style size constraints).
* **Weapons:** Tiered progression (Gauss -> Coil -> Rail).
* **Control:** Player pilots the Hero Ship manually; turrets can be automated or manual.

---

## 3. TECHNICAL ARCHITECTURE (The "How")
### Performance Optimization
* **Swarm Logic:** Enemy Eldritch horrors move in massive swarms. Standard Unity physics will fail. We must use light-weight "Boid" algorithms.
* **Object Pooling:** Projectiles and enemies must be pooled to avoid Garbage Collection (GC) spikes on mobile.
* **Targeting:** Use layer-based masking or spatial partitioning to handle 50+ ships on screen.

### Milestones (Development Roadmap)
* **M1: Mobile Input Refactor:** Touch controls for thrust/rotation.
* **M2: Projectile Pooling:** Zero-allocation firing system.
* **M3: Spatial Hashing:** Optimized targeting system.
* **M4: Passive Modules:** Tick-free armor/cargo systems.
* **M8: AI Swarms:** Flocking behavior implementation.

---

## 4. CONTEXT FOR AI CODING
* **SentinelIdleState:** The default state for rebooted ships before they are assigned a beacon.
* **Eldritch AI:** Needs to feel "organic" and "fluid," not robotic. Use noise filters on movement.
* **Save System:** JSON serialization for cross-platform parity.
