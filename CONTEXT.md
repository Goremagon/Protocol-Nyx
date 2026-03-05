# Aether-Sight Context

## 🎯 Mission
A high-fidelity "Sniper Scope" for Magic: The Gathering remote play.
**Goal:** User points webcam at card -> System identifies card in <200ms -> Displays overlay.

## 🏗 System State (The "Speedster" Build)
We are currently running the **Speedster Architecture** to fix lag and memory bloat.

### 1. The Backend (`backend/`)
- **Engine:** Python FastAPI + OpenCV.
- **Algorithm:** ORB (Oriented FAST and Rotated BRIEF) + Color Histogram + pHash.
- **Optimization:**
  - `N_FEATURES = 250` (Lite mode).
  - `BFMatcher` with KNN (k=2) and Ratio Test (0.75).
  - **Nuclear Crop:** We aggressively crop the center 50% of images to ignore playmat borders.

### 2. The Frontend (`frontend/`)
- **Tech:** React + Vite.
- **Key Component:** `GameRoom.jsx`.
- **UI UX:**
  - **AR Box:** User manually resizes a red box to fit the card.
  - **Scroll Hack:** We globally disable `<body>` scrolling so the mouse wheel resizes the box instead of moving the page.
  - **Communication:** Sends base64 snapshots to `/analyze` endpoint.

## ⚠️ Known Traps
1. **The Sync Trap:** `compile_brain.py` and `main.py` MUST have the exact same `N_FEATURES` and `get_center_crop` logic. If they drift, detection fails.
2. **The 404 Error:** The backend (:8000) has no homepage. Always test via Frontend (:3000).
3. **Github Limits:** `cards.db` and `brain.pkl` are ignored via `.gitignore` because they are massive.

## 📝 Current Focus
- Speed. Latency must be under 200ms.
- Reliability. Stop the "Color Veto" false negatives.