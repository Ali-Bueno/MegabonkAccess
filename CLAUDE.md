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
  - `TolkUtil.cs` - Screen reader wrapper + coordination system
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
- [x] **Character selection**: Reads character name, description, weapon, passive (Transform-based search)
- [x] **Shop menu**: Reads item info via ShopFooter.Set patch (Transform-based search)
- [x] **Unlocks menu**: Reads unlock info via UnlocksFooter.OnUnlockSelected patch (Transform-based search)
- [x] **Locked item handling**: Detects locked items via reqContainer, announces "Bloqueado" + requirements
- [x] **Unlocked item handling**: Reads texts outside requirement containers, filters progress texts
- [x] **Level-up item selection**: (UpgradeButton) reads item name, description, rarity
- [x] **Chest menu**: (ChestWindowUi) announces chest contents when opened
- [x] **Shrine encounters**: (EncounterButton) reads options and rarities
- [x] **Interactables**: (BaseInteractable) announces interaction text on hover

#### Pending
- [ ] **Settings Menu - State Reading**: Current value on focus (IL2CPP issues)
- [ ] **Meta-progression / upgrades**: Not implemented

---

### Phase 2 - Gameplay Accessibility (In Progress)

#### Directional Audio Beacons

**Status:** Functional

##### Implemented Features
- 3D spatialized audio beacons for interactables
- Different sounds/pitches per object type (chest, shrine, portal, urn, etc.)
- Detection radius: 200 units
- Scene change cleanup
- 4-second delay after scene load (skip intro cinematic)
- Beacons removed after interaction (BaseInteractable.Interact patch)
- Beacons removed when `CanInteract()` returns false (catches used objects)
- Sibling scanning: finds ALL interactables in same container (duplicates)
- Proactive scanning: searches for objects by name patterns (Portal, Chest, Shrine, Pot, etc.)
- Container scanning: searches common container objects for interactables
- Specific chest scanning: `ScanAllChests()` searches for `InteractableChest` components directly

##### Menu Detection (sounds pause during menus)
Detection methods in `IsMenuOpen()`:
- `Time.timeScale < 0.1f` - Pause menu (game frozen)
- Pause menu objects: `PauseMenu`, `Pause`, `B_Resume`, etc.
- `ChestAnimationTracker.IsChestWindowOpen` - Entire chest window duration
- `ChestAnimationTracker.IsChestAnimationPlaying` - Chest opening animation
- `MenuStateTracker.IsAnyMenuOpen` - Upgrade buttons, reward windows
- Cached `DeathCamera` reference (searched every 0.5s) - Death sequence
- Death buttons: `B_Continue`, `ContinueButton`, `RestartButton`, `StatsButton`

##### Known Issues / TODO
- None currently

##### Fixed Bugs
1. **Gold chests not detected proactively**: The issue was that chests were found by `GameObject.Find()` but beacons weren't created because they were outside the detection radius. Fixed by removing distance check for chest beacon creation - chests now get beacons immediately when found, and sound only plays when player enters range. Added `ScanAllChests()` method with `ProcessChestObject()` that creates beacons without distance verification.
2. **UI reading previous item**: Added delayed speech system (`ScheduleDelayedAction`) - waits 150ms for UI to update before reading
3. **Generic patches interrupting specialized**: Coordination system (`SpeakFromSpecializedPatch`, `ShouldSkipGenericPatch`) blocks generic patches for 0.5s after specialized patch speaks
4. **Beacons during chest window**: Track `IsChestWindowOpen` via `OnClose()` patch, not just animation
5. **Beacons during pause menu**: Added specific pause menu object detection
6. **Beacons during death**: Restored `DeathCamera` check + death button detection
7. **Items reading requirements from other items**: Rewrote menu patches to use Transform-based search. For unlocked items, uses `GetTextsOutsideRequirements()` to skip texts inside requirement containers.
8. **IL2CPP trampoline errors**: Direct property access on patched instances caused crashes. Fixed by using `__instance.transform` and recursive `FindChildByName()` search.

---

## TolkUtil Coordination System

### Purpose
Prevents generic patches (MyButtonPatch, ButtonPatch, TooltipPatch) from interrupting specialized patches (CharacterInfoUI, Shop, Unlock).

### Methods
- `SpeakFromSpecializedPatch(text)` - Speaks and sets timestamp
- `ShouldSkipGenericPatch()` - Returns true if specialized patch spoke within 0.5s
- `ScheduleDelayedAction(action, delay)` - Schedules action for later (UI update timing)
- `ProcessDelayedSpeech()` - Called from DirectionalAudioManager.Update()

### Usage Pattern
```csharp
// In specialized patch (e.g., CharacterInfoUIPatch)
TolkUtil.ScheduleDelayedAction(() => ReadCharacterInfo(instance));

// In generic patch (e.g., MyButtonPatch)
if (TolkUtil.ShouldSkipGenericPatch()) return;
```

---

## IL2CPP Limitations & Workarounds

### Methods that DON'T work in IL2CPP:
- `FindObjectsOfType<T>()` - "Method not found"
- `Scene.GetRootGameObjects()` - "Method not found"
- `OnEnable()` / `OnDisable()` patches - Not exposed
- Generic method patches in some cases
- `is` operator for type checking (unreliable) - use `GetType().Name` instead

### Workarounds used:
- `GameObject.Find(name)` for specific object names
- Component search via `GetComponent<T>()` on known objects
- Name-based pattern matching with Clone variants
- `ClassInjector.RegisterTypeInIl2Cpp<T>()` for custom MonoBehaviours
- String type name comparison instead of `is` operator
- Transform-based recursive search instead of direct property access (avoids IL2CPP trampoline errors)

### Transform-Based UI Reading Pattern
Direct property access like `__instance.t_name` causes IL2CPP trampoline errors. Use this pattern instead:
```csharp
// Instead of: string name = __instance.t_name.text;
// Use:
Transform root = __instance.transform;
string name = FindTextByObjectName(root, "t_name");

private static string FindTextByObjectName(Transform root, string objectName)
{
    var obj = FindChildByName(root, objectName);
    if (obj == null) return "";
    var tmp = obj.GetComponent<TextMeshProUGUI>();
    if (tmp == null) return "";
    return SanitizeText(tmp.text);
}
```

### Excluding Requirement Texts Pattern
To read item info without mixing in requirements from other items:
```csharp
private static void CollectTextsOutsideRequirements(Transform parent, List<string> list, bool insideReq)
{
    string objName = parent.name.ToLower();
    bool isReqContainer = objName.Contains("requirement") || objName.Contains("reqcontainer") ||
                          objName.Contains("reqprefab") || objName.StartsWith("req");
    if (isReqContainer) insideReq = true;

    if (!insideReq)
    {
        var tmp = parent.GetComponent<TextMeshProUGUI>();
        if (tmp != null) list.Add(SanitizeText(tmp.text));
    }

    for (int i = 0; i < parent.childCount; i++)
        CollectTextsOutsideRequirements(parent.GetChild(i), list, insideReq);
}
```

### Object Naming Patterns
Unity clone naming conventions to search:
- `ObjectName`
- `ObjectName(Clone)`
- `ObjectName (Clone)` (with space)

---

## Key Technical Findings

### Menu State Detection
Objects that ALWAYS exist (can't use for detection):
- `DeathScreen` - Always active, just hidden
- `DeathCamera` component - Check if Camera component is enabled

Objects/states that work for detection:
- `DeathCamera` with enabled Camera component
- Death buttons appearing (B_Continue, etc.)
- `Time.timeScale` changes
- Specific menu panel objects

### Proactive Object Scanning
Objects found proactively by `ScanRootObjectsByName()`:
- Portal, Chest (including gold chests), BossSpawner
- ChargeShrine, Shrine variants
- PotSmall, PotSmallSilver
- Microwave, Boombox (music)

### Garbage Text in Game
The game has placeholder text like "fsd fsdfesf efsdfes efs" in some UI elements. Use `HasGarbagePattern()` regex to detect:
```csharp
if (Regex.IsMatch(text, @"([sd]{2,}\s*){3,}", RegexOptions.IgnoreCase)) return true;
if (Regex.IsMatch(text, @"([a-z]{1,2}\s+){5,}", RegexOptions.IgnoreCase)) return true;
if (Regex.IsMatch(text, @"[fsde]{3,}", RegexOptions.IgnoreCase)) return true;
```

### Progress Text Filtering
The game shows progress like "100 / 10 000" or pure numbers like "5,000". Filter with:
```csharp
private static bool IsProgressText(string text)
{
    if (string.IsNullOrEmpty(text)) return false;
    // Progress: number / number (e.g., "100 / 10 000", "363 / 1.000")
    if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*/\s*[\d.,\s]+\s*$")) return true;
    // Pure numbers: "5,000", "10.000", "100"
    if (Regex.IsMatch(text, @"^\s*[\d.,\s]+\s*$")) return true;
    return false;
}
```

---

## File Reference

### Patches
- `BaseInteractablePatch.cs` - Hover announcements + beacon registration + interaction removal
- `ButtonPatch.cs` - ButtonNavigationBackdropAndText selection (with skip check)
- `MyButtonPatch.cs` - Generic MyButton selection (with skip check + type filtering)
- `TooltipPatch.cs` - Tooltip announcements (with skip check)
- `CharacterInfoUIPatch.cs` - Character selection (delayed speech)
- `ShopPatch.cs` - Shop footer (delayed speech)
- `UnlockPatch.cs` - Unlock footer (delayed speech)
- `UpgradeButtonPatch.cs` - Level-up menu + MenuStateTracker
- `ChestWindowUiPatch.cs` - Chest contents + ChestAnimationTracker + window open/close

### Components
- `DirectionalAudioManager.cs` - 3D audio beacon system

### State Trackers
- `MenuStateTracker` (in UpgradeButtonPatch.cs) - Detects open menus via button search
- `ChestAnimationTracker` (in ChestWindowUiPatch.cs) - Tracks chest window state

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
- Decompiled game code in `megabonk code/` folder for reference
