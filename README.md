# Unity Collectibles Game

**Author:** Schanelle Jackson  
**Date:** 2025-06-14 

---

## Overview

This Unity project is a simple collectibles game where the player collects collectibles to win the game. The player must avoid two different hazards that cause death and level restart. The game includes score tracking and UI updates.

---

## How to Run & Play

### Requirements

- **Platform:** Windows or macOS  
- **Unity Version:** 2021.3 LTS or newer recommended  
- **Hardware:** Any PC capable of running Unity-built games, with keyboard and mouse input  

### Controls

- **Move Player:** WASD or Arrow keys  
- **Interact:** Automatic on proximity (no key press required)  
- **Objective:** Collect all collectibles to win  

---

## Gameplay Details & Features

- **Collectibles:**  
  - Play a sound when picked up  
  - Increase player score  
  - Destroy themselves after collection  

- **Door:**  
  - Opens automatically when the player is near 
  - Closes when the player leaves the trigger area  

- **Hazards:**
  - Cause player death and restart the level after playing a sound
  - Two different hazards (Red pole and spikes)

- **UI:**  
  - Displays current score  
  - Shows a win panel when all collectibles are collected  

---

##  Game Solutions

- Collect **all 5 collectibles** scattered throughout the scene (indoors and outdoors).  
- Avoid hazards to prevent restarting the level.  

---

## Known Issues and Limitations

- The door closes immediately if the player leaves its trigger area, even after winning conditions are met.  
- UI references depend on specific GameObject names in the scene ("ScoreText" and "WinPanel").  
- AudioSource components must be assigned correctly to avoid warnings.  
---

## Assets and Credits

- **Audio:**  
  -Collectibles, Hazards and Door: https://pixabay.com/sound-effects/search/crash/
  
  -Background music: https://freemusicarchive.org/

- **Code:**
  Written and maintained by Schanelle with credits to Brightspace, Generative AI tools and Chatgpt
  https://nplms.polite.edu.sg/d2l/home
  
  https://chatgpt.com/
---

## Using GitHub Desktop

1. Clone the repository via GitHub Desktop.  
2. Open the project in Unity Editor.  
3. Make changes and commit often with descriptive messages.  
4. Push commits to keep your online repository updated.  

---


