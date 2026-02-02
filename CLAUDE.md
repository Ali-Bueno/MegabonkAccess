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
  - `Components/` - Custom Unity components
    - `DirectionalAudioManager.cs` - Beacon tracking and scheduling
    - `NAudioBeaconPlayer.cs` - NAudio-based 3D audio playback

### References
- `/references/` - Game assemblies and dependencies
- `TolkDotNet.dll` + `Tolk.dll` - Screen reader support (NVDA, JAWS, SAPI)

### Audio Assets
- `MegabonkAccess/sounds/` - Audio cue sound files
  - `beacon.wav` - Default/fallback beacon sound
  - `chests.mp3` - Chest sound (beacon behavior)
  - `shrines.mp3` - Shrine sound (beacon behavior)
  - `portal.mp3` - Portal sound (ambient loop)
  - `boombox.mp3` - Boombox NPC (ambient loop)
  - `microwave.mp3` - Microwave NPC (ambient loop)

### Game Location
- `D:\games\steam\steamapps\common\Megabonk\`
- BepInEx log: `BepInEx\LogOutput.log`

---

## Current Priority Task

### Multi-Sound Audio System with Distinct Behaviors

**Status:** Functional

**Goal:** Multiple distinct sounds with unique audio behaviors based on object type.

#### Audio Behavior Types

| Behavior | Loop | Interval (distance-based) | Pitch (distance-based) | Pan 3D | Use Case |
|----------|------|---------------------------|------------------------|--------|----------|
| **Beacon** | No | Yes (faster when closer) | Yes (higher when closer) | Yes | Interactables (chests, shrines, pots) |
| **Ambient** | Yes (PlaybackStopped event) | No | No | Yes | Portals, boombox, microwave |

#### Current Sound Files (in `sounds/` folder)

| File | Type | Behavior | Interval | Objects |
|------|------|----------|----------|---------|
| `chests.mp3` | chest | Beacon | 1.5s base | All chests (normal + gold) |
| `shrines.mp3` | shrine | Beacon | 3.0s base | All shrines |
| `portal.mp3` | portal | Ambient (loop) | - | All portals |
| `boombox.mp3` | boombox | Ambient (loop) | - | Boombox NPC |
| `microwave.mp3` | microwave | Ambient (loop) | - | Microwave NPC |
| `beacon.wav` | default | Beacon | 2.5s base | Fallback for everything else |

#### NAudio Ambient Loop Implementation
Ambient sounds use `WaveOutEvent.PlaybackStopped` event to restart playback when finished:
```csharp
waveOut.PlaybackStopped += (sender, args) => {
    if (!ambientData.IsDisposed && ambientSounds.ContainsKey(targetId)) {
        reader.Position = 0;
        waveOut.Play();
    }
};
```

#### Pending Sound Files

**Interactables (Beacon behavior):**
- `pot.wav` / `urn.wav` - Vasijas/urnas
- `npc.wav` - NPCs (ShadyGuy, etc.)

**Pickups (Beacon behavior):**
- `pickup_health.wav` - Salud
- `pickup_gold.wav` - Oro
- `pickup_xp.wav` - Experiencia
- `pickup_special.wav` - Powerups

**Hazards (to implement):**
- `hazard_water.wav` - Agua
- `hazard_lava.wav` - Lava

#### Object Categories Reference

See `objetos_para_sonidos.txt` for complete list of game objects.

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

##### Audio System: NAudio
Uses **NAudio** library instead of Unity's AudioSource for better control over 3D audio.

**Why NAudio:**
- Independent of Unity's audio system (avoids IL2CPP issues)
- Precise control over pan, volume, and pitch
- Custom sound files instead of game sounds

**NAudioBeaconPlayer features:**
- Stereo panning based on object position relative to player/camera
- Volume scaling based on distance (quadratic curve)
- Pitch shifting based on distance (closer = higher pitch)
- Pool of 12 concurrent sound players
- Runs audio on separate thread to avoid blocking Unity

**Distance-based effects (quadratic curves for dramatic changes):**
| Effect | Far | Close |
|--------|-----|-------|
| Volume | 10% | 100% |
| Pitch | 0.6x (low) | 1.6x (high) |
| Interval | 2.0x base (slow) | 0.15x base (fast) |
| Pan | Full stereo separation based on angle |

##### Beacon Detection Features
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
- [x] **Multi-sound system** - Implemented: chests, shrines, portals, boombox, microwave
- [ ] **More sounds** - Add pot/urn, npc, pickup sounds
- [ ] **Hazard detection** - Add Water, Lava, DamageZone, Boulder detection
- [ ] **Beneficial zone detection** - Add HealingZone, Campfire detection

##### Fixed Bugs
1. **Gold chests not detected proactively**: The issue was that chests were found by `GameObject.Find()` but beacons weren't created because they were outside the detection radius. Fixed by removing distance check for chest beacon creation - chests now get beacons immediately when found, and sound only plays when player enters range. Added `ScanAllChests()` method with `ProcessChestObject()` that creates beacons without distance verification.
2. **UI reading previous item**: Added delayed speech system (`ScheduleDelayedAction`) - waits 150ms for UI to update before reading
3. **Generic patches interrupting specialized**: Coordination system (`SpeakFromSpecializedPatch`, `ShouldSkipGenericPatch`) blocks generic patches for 0.5s after specialized patch speaks
4. **Beacons during chest window**: Track `IsChestWindowOpen` via `OnClose()` patch, not just animation
5. **Beacons during pause menu**: Added specific pause menu object detection
6. **Beacons during death**: Restored `DeathCamera` check + death button detection
7. **Items reading requirements from other items**: Rewrote menu patches to use Transform-based search. For unlocked items, uses `GetTextsOutsideRequirements()` to skip texts inside requirement containers.
8. **IL2CPP trampoline errors**: Direct property access on patched instances caused crashes. Fixed by using `__instance.transform` and recursive `FindChildByName()` search.
9. **Garbage text mixed with valid text**: Text like "Kill 1000 skeletons fsd fsdfesf efsdfes efs" was being fully discarded. Fixed with `RemoveGarbageFromText()` that strips only the garbage portion while preserving valid text.

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
The game has placeholder text like "fsd fsdfesf efsdfes efs" in some UI elements. Two approaches:

**Detection** - `HasGarbagePattern()` checks if entire text is garbage:
```csharp
if (Regex.IsMatch(text, @"^([sd]{2,}\s*){3,}$", RegexOptions.IgnoreCase)) return true;
if (Regex.IsMatch(text, @"^([a-z]{1,2}\s+){5,}$", RegexOptions.IgnoreCase)) return true;
```

**Removal** - `RemoveGarbageFromText()` strips garbage from mixed text:
```csharp
// Removes 2+ consecutive words made only of f, s, d, e letters
text = Regex.Replace(text, @"\b[fsde]{2,}(\s+[fsde]{2,})+\b", "", RegexOptions.IgnoreCase);
// Example: "Kill 1000 skeletons fsd fsdfesf efsdfes efs. 100 / 10 000"
//       -> "Kill 1000 skeletons. 100 / 10 000"
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
- `DirectionalAudioManager.cs` - Beacon tracking, scanning, and scheduling
- `NAudioBeaconPlayer.cs` - NAudio-based 3D audio with pan/volume/pitch

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

**Files deployed:**
- `MegabonkAccess.dll` - Main plugin
- `NAudio.dll`, `NAudio.Core.dll`, `NAudio.Wasapi.dll`, `NAudio.WinMM.dll` - Audio library
- `TolkDotNet.dll` - Screen reader wrapper
- `sounds/` - All sound files (beacon.wav, chests.mp3, shrines.mp3, portal.mp3, boombox.mp3, microwave.mp3)
- `Tolk.dll`, `nvdaControllerClient64.dll` - To game root folder

---

## Notes

- This is an IL2CPP game (Unity 2023.2.22f1)
- Screen reader support requires Tolk.dll in game root folder
- NAudio requires .NET 6.0 runtime (included with BepInEx IL2CPP)
- Test with BepInEx console or LogOutput.log for debugging
- Decompiled game code in `megabonk code/` folder for reference
- Beacon sound file should be mono or stereo WAV (converted to mono internally for panning)
