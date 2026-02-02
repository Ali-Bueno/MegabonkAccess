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
  - `shrines.mp3` - Shrine sound (ambient loop)
  - `portal.mp3` - Portal sound (ambient loop)
  - `boombox.mp3` - Boombox NPC (beacon behavior)
  - `microwave.mp3` - Microwave NPC (beacon behavior)

### Game Location
- `D:\games\steam\steamapps\common\Megabonk\`
- BepInEx log: `BepInEx\LogOutput.log`

---

## Audio System

### Audio Behavior Types

| Behavior | Loop | Interval (distance-based) | Pitch (distance-based) | Pan 3D | Use Case |
|----------|------|---------------------------|------------------------|--------|----------|
| **Beacon** | No | Yes (faster when closer) | Yes (higher when closer) | Yes | Chests, pots, NPCs |
| **Ambient** | Yes (LoopStream) | No | No | Yes | Portals, Shrines |

### Current Sound Configuration

| File | soundType | Behavior | Objects |
|------|-----------|----------|---------|
| `chests.mp3` | chest | Beacon | All chests (normal + gold) |
| `shrines.mp3` | shrine | Ambient (loop) | All shrines |
| `portal.mp3` | portal | Ambient (loop) | Portals, BossSpawner |
| `boombox.mp3` | boombox | Beacon | Boombox NPC |
| `microwave.mp3` | microwave | Beacon | Microwave NPC |
| `beacon.wav` | default | Beacon | Fallback for everything else |

### NAudio Implementation

#### LoopStream (Ambient Sounds)
Custom `WaveStream` wrapper that loops audio infinitely:
```csharp
public class LoopStream : WaveStream
{
    public override int Read(byte[] buffer, int offset, int count)
    {
        int totalBytesRead = 0;
        while (totalBytesRead < count)
        {
            int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
            if (bytesRead == 0)
            {
                sourceStream.Position = 0; // Loop back to start
            }
            else
            {
                totalBytesRead += bytesRead;
            }
        }
        return totalBytesRead;
    }
}
```

#### Pause/Resume System
Ambient sounds are **paused** during menus (not destroyed), avoiding recreation issues:
```csharp
// When entering menu/pause state:
naudioPlayer.PauseAllAmbientSounds();  // Just pauses playback

// When exiting menu/pause state:
naudioPlayer.ResumeAllAmbientSounds();  // Resumes from where it left off
```

#### Distance-Based Effects (Beacon only)
| Effect | Far | Close |
|--------|-----|-------|
| Volume | 10% | 100% |
| Pitch | 0.6x (low) | 1.6x (high) |
| Interval | 2.0x base (slow) | 0.15x base (fast) |
| Pan | Full stereo separation based on angle |

### Object Type Detection

**Language-independent** - uses only GameObject names and component type names (always English in Unity):
```csharp
private string IdentifyType(string name)
{
    if (name.Contains("chest")) return "chest";
    if (name.Contains("shrine") || name.Contains("pylon")) return "shrine";
    if (name.Contains("bossspawner")) return "boss_portal";
    if (name.Contains("portal")) return "portal";
    if (name.Contains("pot") || name.Contains("urn")) return "urn";
    // ... etc
}

private string IdentifyTypeFromInteractable(BaseInteractable interactable, string objName)
{
    // First try by object name
    string typeFromName = IdentifyType(objName);
    if (typeFromName != "unknown") return typeFromName;

    // Then by component type name (always English)
    string typeName = interactable.GetType().Name.ToLower();
    if (typeName.Contains("chest")) return "chest";
    if (typeName.Contains("shrine")) return "shrine";
    // ... etc - NO localized text checks
}
```

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
- Pitch shifting based on distance (closer = higher pitch) - Beacon only
- Pool of 12 concurrent sound players for beacon sounds
- LoopStream for infinite ambient loops
- Pause/Resume for menu transitions

##### Beacon Detection Features
- Detection radius: 200 units
- Scene change cleanup
- 4-second delay after scene load (skip intro cinematic)
- Beacons removed after interaction (BaseInteractable.Interact patch)
- Beacons removed when `CanInteract()` returns false (catches used objects) - **except Ambient beacons**
- Ambient beacons persist even if Target is destroyed (continue playing at last known position)
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
- [x] **Ambient loop system** - LoopStream for infinite loops, Pause/Resume for menus
- [ ] **More sounds** - Add pot/urn, npc, pickup sounds
- [ ] **Hazard detection** - Add Water, Lava, DamageZone, Boulder detection
- [ ] **Beneficial zone detection** - Add HealingZone, Campfire detection

##### Fixed Bugs
1. **Gold chests not detected proactively**: Fixed by removing distance check for chest beacon creation.
2. **UI reading previous item**: Added delayed speech system (`ScheduleDelayedAction`) - waits 150ms for UI to update.
3. **Generic patches interrupting specialized**: Coordination system blocks generic patches for 0.5s after specialized patch speaks.
4. **Beacons during chest window**: Track `IsChestWindowOpen` via `OnClose()` patch.
5. **Beacons during pause menu**: Added specific pause menu object detection.
6. **Beacons during death**: Restored `DeathCamera` check + death button detection.
7. **Items reading requirements from other items**: Transform-based search with `GetTextsOutsideRequirements()`.
8. **IL2CPP trampoline errors**: Use `__instance.transform` and recursive `FindChildByName()` search.
9. **Garbage text mixed with valid text**: `RemoveGarbageFromText()` strips only garbage portion.
10. **Multiple ambient sounds accumulating**: Changed from PlaybackStopped event to LoopStream for reliable looping.
11. **Ambient sounds recreating during menu flicker**: Changed from Stop/Recreate to Pause/Resume.
12. **Ambient beacons removed when target destroyed**: Skip removal for Ambient behavior beacons.
13. **Localized text breaking detection**: Removed all localized text checks, use only object/component names.

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
text = Regex.Replace(text, @"\b[fsde]{2,}(\s+[fsde]{2,})+\b", "", RegexOptions.IgnoreCase);
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
- `NAudioBeaconPlayer.cs` - NAudio-based 3D audio with pan/volume/pitch, LoopStream, Pause/Resume

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
- Object detection is language-independent (uses object/component names, not localized text)
