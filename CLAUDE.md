# Megabonk Accessibility Project (Technical Overview)

## Project Goal

This project aims to **add full accessibility support to the Unity game *Megabonk*** using **BepInEx IL2CPP** modding.

The main objective is to make the game **fully playable by blind and visually impaired players**, using:
- Audio feedback
- Text-to-speech (TTS) via Tolk
- Directional 3D audio beacons for navigation

Accessibility is implemented as an **additional layer**, without altering the core gameplay design.

---

## Project Structure

### Mod Code
- `MegabonkAccess/` - Main BepInEx plugin
  - `Plugin.cs` - Entry point
  - `TolkUtil.cs` - Screen reader wrapper
  - `Patches/` - Harmony patches for game hooks
  - `Components/` - Custom Unity components (DirectionalAudioManager)

### References
- `/references/` - Game assemblies and dependencies
- `TolkDotNet.dll` + `Tolk.dll` - Screen reader support (NVDA, JAWS, SAPI)

### Game Location
- `D:\games\steam\steamapps\common\Megabonk\`
- BepInEx log: `BepInEx\LogOutput.log`

---

## Development Phases

### Phase 1 - Menu Accessibility (Complete)

**Status:** Functional

#### Completed
- [x] **Project Setup**: BepInEx IL2CPP + Tolk integration
- [x] **Main Menu**: Title and navigation announced
- [x] **Button Navigation**: Reads button text (Play, Settings, etc.)
- [x] **Settings Menu**: Reads new values when changing options
- [x] **Character selection**: Reads character name, description, weapon, passive abilities
- [x] **Level-up item selection**: (UpgradeButton) reads item name, description, rarity
- [x] **Chest menu**: (ChestWindowUi) announces chest contents when opened
- [x] **Shrine encounters**: (EncounterButton) reads options and rarities
- [x] **Interactables**: (BaseInteractable) announces interaction text on hover

#### Pending
- [ ] **Settings Menu - State Reading**: Current value on focus (IL2CPP issues)
- [ ] **Meta-progression / upgrades**: Not implemented
- [ ] **Pause menu accessibility**: Basic detection works

---

### Phase 2 - Gameplay Accessibility (In Progress)

#### Directional Audio Beacons

**Status:** Partially working with known bugs

##### Implemented Features
- 3D spatialized audio beacons for interactables
- Different sounds/pitches per object type (chest, shrine, portal, urn, etc.)
- Detection radius: 120 units
- Scene change cleanup
- 4-second delay after scene load (skip intro cinematic)
- Beacons removed after interaction (BaseInteractable.Interact patch)

##### Menu Detection (sounds pause during menus)
Working detection methods:
- `Time.timeScale < 0.1f` - Pause menu
- `MenuStateTracker.IsAnyMenuOpen` - Upgrade/chest menus via button detection
- `DeathCamera` active and enabled - Death sequence
- `EventSystem.currentSelectedGameObject` - UI focus detection
- Death buttons: "ContinueButton", "RestartButton", "StatsButton", etc.

##### Known Bugs (TODO)
1. **Multiple objects with same name**: `GameObject.Find()` only returns first match. Objects like multiple pots only get beacons after hover detection, not proactive scan.
2. **Chest opening animation**: Beacons still play during chest open animation
3. **Some interactables don't remove beacons**: Boss summoner and others persist after use
4. **Object naming inconsistencies**: Game uses both "ShrineCursed" and "CursedShrine" patterns

---

## IL2CPP Limitations & Workarounds

### Methods that DON'T work in IL2CPP:
- `FindObjectsOfType<T>()` - "Method not found"
- `Scene.GetRootGameObjects()` - "Method not found"
- `OnEnable()` / `OnDisable()` patches - Not exposed
- Generic method patches in some cases

### Workarounds used:
- `GameObject.Find(name)` for specific object names
- Component search via `GetComponent<T>()` on known objects
- Name-based pattern matching with Clone variants
- `ClassInjector.RegisterTypeInIl2Cpp<T>()` for custom MonoBehaviours

### Object Naming Patterns
Unity clone naming conventions to search:
- `ObjectName`
- `ObjectName(Clone)`
- `ObjectName (Clone)`
- `ObjectName(Clone) (1)`, `(2)`, etc.

---

## Key Technical Findings

### Menu State Detection
Objects that ALWAYS exist (can't use for detection):
- `DeathScreen` - Always active, just hidden
- `DeathCamera` component - Always enabled

Objects/states that work for detection:
- `DeathCamera` as `Camera.main` - Only during death
- Death buttons appearing (ContinueButton, etc.)
- `Time.timeScale` changes
- `EventSystem.currentSelectedGameObject` focus

### Interactable Object Names (from logs)
```
CursedShrine(Clone)
PotSmall(Clone)
PotSmallSilver(Clone)
Portal
```

### Audio Clips Available (from AudioManager children)
- Gold sound
- Silver sound
- Bullseye sound
- XP sound
- Dungeon door (removed - confusing at start)

---

## File Reference

### Patches
- `BaseInteractablePatch.cs` - Hover announcements + beacon registration + interaction removal
- `UpgradeButtonPatch.cs` - Level-up menu + MenuStateTracker
- `ChestWindowUiPatch.cs` - Chest contents announcement
- `EncounterButtonPatch.cs` - Shrine options

### Components
- `DirectionalAudioManager.cs` - 3D audio beacon system

---

## Build & Deploy

```bash
cd MegabonkAccess
dotnet build --configuration Release
```

Auto-copies to: `D:\games\steam\steamapps\common\Megabonk\BepInEx\plugins\`

---

## Notes

- This is an IL2CPP game (Unity 2023.2.22f1)
- Screen reader support requires Tolk.dll in game root folder
- Test with BepInEx console or LogOutput.log for debugging
