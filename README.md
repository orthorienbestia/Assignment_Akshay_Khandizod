# Assignment_Akshay_Khandizod

### Note:
- No third party utilities, unity packages or libraries were used.
- Only packages and libraries provided directly by unity are used.
- Textures, images and few model are taken from internet.

### Extra Features Added:
- **Addressables**: Food Configuration Data JSON is loaded using addressables.
- **Snake Navigator**: Arrow on top of snake's head is added for better navigation on map. The arrow always points to the last food object spawned on the map !!
- **Cinemachine**: Camera view can be switched smoothly while inside gameplay.
- **Android Support**: 
  - Touch support: Added using Unity Event Trigger
  - APK: It is created, tested and provided with the project.

### Links
- [Android Build / APK] (https://github.com/orthorienbestia/Assignment_Akshay_Khandizod/releases/tag/Final_Submission)
- [Gameplay Recording] (https://youtu.be/cw_v4XDbQdc)

### Game Summary:
- This project is a simple 3D game where player has to collect food.
- Snake moves continuously in forward direction and player can steer it left or right.
- Random food is spawned at random location on the map.
- Random food is selected from the list of food items mentioned in FoodConfigurationData.json file.
- Different food items have different score value.
- Eating same food item consecutively increases the score multiplier.
- User can change camera view by pressing button on top left corner of the screen.

### Code Design:
The design used is modular and non dependent.

- **Snake Game Manager:** This is the main game manager which handles callbacks and game events. It intermediates between different systems.
- **Snake:** This is the main snake class which handles snake movement, collision and streaks.
- **Scoring System:** This system handles score calculation and streaks and visually updating on screen.
- **Food Configuration System:** This system loads food configuration data from JSON file using Addressables.
- **Food Spawning System:** This system handles spawning of random food from food configuration data at random location.
- **Food Item:** This MonoBehaviour handles food item data and collision with snake head.

### Utility Classes Created:
- **List Extensions:** Extended function to get random element from list is added to List class.
- **Saved Variables:** Intermediary/Proxy class for PlayerPrefs.
- **Saved Variables Viewer:** MonoBehaviour to view saved variables in TextMeshPro Text.
- **Mono Scene Manager:** MonoBehaviour to switch between scenes directly from editor from unity events or triggers.
- **Mono Logger:** MonoBehaviour to log messages in console directly from inspector.

### Unity Version Used: 2021.3.25f1
