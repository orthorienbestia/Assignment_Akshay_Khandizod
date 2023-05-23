# TASK BREAKDOWN STRUCTURE

### The project development is divided into 3 phases:

#### Phase 1: Game's base [Git branch: phase_1]
- Scoring System
- Food Configuration System [Using JSON loaded using **Addressables**]
- High Score System
  - Saved Variable and Viewer
- Mono Scene Manager [For switching between scenes]

#### Phase 2: Actual Gameplay [Git branch: phase_2]
- Snake Game Manager
- Environment creation
- Random food spawning at random location with proper color set from food configuration data.
- Snake
  - Snake Movement
  - Snake head and food collision
  - Snake head collision with body and walls
  - Handle Streaks
- Camera Switching
- OnGameEnd, OnFoodEaten Callbacks
- Game Over Screen
- High Score

#### Phase 3: UI, UX and Visuals [Git branch: phase_3]
- Home screen graphics
- Game scene UI images
- Code refactoring
- Adding Snake Navigator Arrow
- Creating README.md
- Adding TASK_BREAKDOWN_STRUCTURE.md
- Test on device and Solve bugs
- Update README.md
- Game Recording
- Create APK