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
- Beacons removed when `CanInteract()` returns false (catches used objects) - **except portals**
- Shrine ambient sounds stop after interaction (one-time use objects)
- Portal ambient beacons persist until player enters (continue playing at last known position)
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
14. **Shrine sounds persisting after use**: Shrine ambient beacons now removed when `CanInteract()` is false (portals excluded).
15. **Shrine detection via reflection**: Added `IsShrineUsed()` method that checks `done` and `completed` properties via reflection (avoids IL2CPP issues with direct property access).

---

#### Wall Navigation Audio System

**Status:** Functional

##### Overview
Soft audio feedback for wall proximity detection + collision sound. Helps blind players navigate the map by providing:
1. Subtle continuous tones when walls are nearby
2. 8-bit "thump" sound when colliding with walls (SMB3 style)

##### Frequencies (Softer than before)
| Direction | Frequency | Description |
|-----------|-----------|-------------|
| Forward | 500 Hz | Medium - wall ahead |
| Back | 180 Hz | Low - wall behind |
| Left/Right | 300 Hz | Medium-low - walls to sides |

##### Audio Behavior
- **Soft triangle waves** mixed with sine (70% triangle + 30% sine) - much less harsh than pure sine
- **Low volume** (0.15 base) - subtle background awareness
- **Volume based on distance**: closer = louder (quadratic curve)
- **Stereo panning** for left/right walls (-1.0 to +1.0)
- **Smooth transitions** to avoid clicks/pops

##### Collision Sound (8-bit Style)
When player moves into a wall:
- **Square wave** at 100 Hz descending to 50 Hz
- **60ms duration** - short and punchy
- **Exponential decay** - "thump" feel like SMB3
- **Cooldown**: 0.3 seconds between collision sounds
- **Trigger distance**: 1.5 units from wall while moving toward it

```csharp
// CollisionSoundGenerator configuration
startFrequency = 100;  // Very low, SMB3-style bump
totalSamples = sampleRate * 0.06;  // 60ms
volume = 0.35f;
// Pitch descends 50% during playback
// Exponential (squared) envelope for punch
```

##### Detection
- Uses `Physics.Raycast` from player position
- Layer mask: all layers (-1)
- Max detection distance: 12 units
- Collision detection: raycast in movement direction
- Updates every frame for responsiveness

##### Menu Detection
Uses same `IsMenuOpen()` logic as DirectionalAudioManager:
- TimeScale check (pause menu)
- Pause menu objects
- ChestAnimationTracker
- MenuStateTracker
- EncounterMenuTracker
- DeathCamera check
- Death buttons

##### Scene Handling
- 4-second delay after scene load (skip intro cinematic)
- Silences during non-gameplay scenes (MainMenu, LoadingScreen, etc.)

##### Configuration (constants in code)
```csharp
private const double FREQ_FORWARD = 500;   // Hz (lowered from 900)
private const double FREQ_BACK = 180;      // Hz (lowered from 250)
private const double FREQ_SIDES = 300;     // Hz (lowered from 450)
private float maxWallDistance = 12f;       // units
private float baseVolume = 0.15f;          // Very low
private float collisionDistance = 1.5f;    // Collision trigger distance
private float collisionCooldown = 0.3f;    // Seconds between collision sounds
```

---

#### Enemy Announcement System

**Status:** Functional (needs polish)

##### Overview
Automatic announcement system that tells the player about nearby enemies via screen reader. Uses Harmony patches to track enemies when they spawn/die.

##### Enemy Tracking (Harmony Patches)
```csharp
// EnemyPatch.cs - Tracks enemies via Harmony
[HarmonyPatch(typeof(Enemy), nameof(Enemy.InitEnemy))]  // Register on spawn
[HarmonyPatch(typeof(Enemy), nameof(Enemy.Kill))]       // Unregister on death

public static class EnemyTracker
{
    private static HashSet<Enemy> activeEnemies;
    public static IEnumerable<Enemy> GetActiveEnemies();
    public static void CleanupDeadEnemies();  // Remove null/inactive
}
```

##### Automatic Triggers

| Trigger | Condition | Cooldown | What it announces |
|---------|-----------|----------|-------------------|
| **Direction change** | Camera rotates >45° | 3 seconds | Enemies in forward direction (60° cone) |
| **Close threat** | Enemy enters <20 units | 2 seconds | New enemies grouped by direction + type |
| **Boss/Elite spawn** | Boss or Elite appears | 2 seconds | Enemy type + direction |

##### Compact Output Format
Groups enemies by direction AND type to reduce verbosity:
```
"3 Esqueletos adelante, 2 Goblins atrás"
"Jefe Faraón adelante, Élite Momia derecha, +5 más"
```
- Max 4 groups per announcement
- Shows "+X más" if more enemies not mentioned
- Bosses/Elites always mentioned first

##### Direction Detection
- **Adelante/Ahead:** -45° to +45° from camera forward
- **Derecha/Right:** +45° to +135°
- **Izquierda/Left:** -45° to -135°
- **Atrás/Behind:** +135° to +180° and -135° to -180°

##### Enemy Information
| Property | Source | Notes |
|----------|--------|-------|
| Name | `enemyData.GetName()` | Localized name from EnemyData |
| Fallback | `enemyData.name` | ScriptableObject name |
| Boss | `enemy.IsBoss()`, `IsStageBoss()`, `IsFinalBoss()` | Prefixed with "Jefe" |
| Elite | `enemy.IsElite()` | Prefixed with "Élite" |
| Alive | `enemy.IsDead()` | Only living enemies |
| Position | `enemy.GetCenterPosition()` | For direction calculation |

##### IL2CPP Workaround
Direct access to `enemyData.enemyName` (EEnemy enum) causes IL2CPP errors. Solution:
- Use `enemyData.GetName()` method instead (returns localized string)
- Fallback to `enemyData.name` (ScriptableObject name)
- Final fallback to cleaned `gameObject.name`

##### Threat Tracking
- **knownCloseEnemies:** Set of enemy IDs within danger distance
- **knownBossesElites:** Set of Boss/Elite enemy IDs
- New threats = enemies not in these sets
- Sets cleared on scene change

##### Configuration (constants in code)
```csharp
private float dangerDistance = 20f;           // Close threat distance
private float maxTrackingDistance = 50f;      // Max tracking range
private float directionChangeCooldown = 3f;   // After direction announce
private float threatAnnounceCooldown = 2f;    // After threat announce (reduced from 4s)
private float directionChangeThreshold = 45f; // Degrees to trigger
```

##### Menu Detection
Silences during:
- TimeScale < 0.1 (pause)
- Pause menu, chest window, upgrade buttons
- ChestAnimationTracker, MenuStateTracker, EncounterMenuTracker

##### TODO
- [ ] Make cooldowns/distances configurable
- [ ] Add health percentage for bosses
- [ ] Consider proximity-based urgency (faster speech when very close)
- [ ] Fine-tune grouping and announcement frequency

---

#### Enemy Audio System (Synthetic Directional Audio)

**Status:** Functional

##### Overview
Real-time synthetic audio feedback for enemy positions. Generates distinct sounds for different enemy types (Normal, Elite, Boss) with 3D panning. Uses 8 directions for precise positioning.

##### Directional Grouping (8 directions)
Enemies are grouped into 8 directions (45° each):
- **Forward (0):** -22.5° to +22.5°
- **Forward-Right (1):** +22.5° to +67.5°
- **Right (2):** +67.5° to +112.5°
- **Back-Right (3):** +112.5° to +157.5°
- **Back (4):** +157.5° to +180° / -157.5° to -180°
- **Back-Left (5):** -112.5° to -157.5°
- **Left (6):** -67.5° to -112.5°
- **Forward-Left (7):** -22.5° to -67.5°

##### Sound by Enemy Type

| Type | Frequency | Duration | Waveform | Characteristics |
|------|-----------|----------|----------|-----------------|
| **Boss** | 60-120 Hz (grave) | 250ms | Square + sub-octava | Descending pitch, very loud |
| **Elite** | 150-300 Hz (medio) | 120ms | Triangle + square | 12 Hz vibrato |
| **Normal** | 500-1000 Hz (agudo) | 60ms | Triangle + square | Short beep |

##### Intervals by Type
| Type | Far | Close |
|------|-----|-------|
| **Boss** | 1.2s | 0.4s |
| **Elite** | 0.8s | 0.2s |
| **Normal** | 0.5s | 0.1s |

##### Volume by Type
| Type | Range |
|------|-------|
| **Boss** | 0.6 - 0.9 |
| **Elite** | 0.5 - 0.75 |
| **Normal** | 0.4 - 0.75 |

##### Pan Calculation
Uses the **closest enemy** of each type for precise panning (not average):
```csharp
// Pan del enemigo más cercano
float pan = Vector3.Dot(toEnemy, right);
pan = Mathf.Clamp(pan, -1f, 1f);
```

##### Audio Channels
Uses 24 NAudio channels (8 directions × 3 types):
- Allows Boss, Elite, and Normal sounds simultaneously
- Each channel has independent pan and volume
- Sounds can overlap from different directions

##### Menu Detection
Same detection as DirectionalAudioManager:
- TimeScale < 0.1 (pause)
- Pause menu objects
- Chest window/animation
- Upgrade buttons, reward windows
- Encounter/shrine menus
- Death camera and death buttons

---

#### Portal Distance Announcer

**Status:** Functional

##### Overview
On-demand portal distance announcement via keyboard shortcut. Press **P** to hear the distance to the next level portal.

##### Usage
- Press **P** key during gameplay
- Screen reader announces: "Portal a X unidades" (Portal at X units)
- If no portal exists: "No hay portal en este nivel"

##### Implementation
```csharp
// PortalDistanceAnnouncer.cs
void Update()
{
    if (Input.GetKeyDown(KeyCode.P))
    {
        AnnouncePortalDistance();
    }
}

private void AnnouncePortalDistance()
{
    // Search for Portal and BossSpawner objects
    // Calculate distance from player
    // Announce via TolkUtil.Speak()
}
```

##### Portal Detection
Searches for these object names:
- `Portal`, `Portal(Clone)`, `Portal (Clone)`
- `BossSpawner`, `BossSpawner(Clone)`, `BossSpawner (Clone)`
- Also searches in common containers: `Interactables`, `Objects`, `World`, `Level`, `Spawned`

##### Configuration
```csharp
private float announceCooldown = 0.5f;  // Prevents spam
```

---

#### Game Alert Messages

**Status:** In Progress

##### Overview
Patches AlertUi class to read game messages via screen reader (wave alerts, boss alerts, time warnings).

##### Patched Methods
| Method | Trigger | Example Message |
|--------|---------|-----------------|
| `SetAlert(EWaveType)` | Wave timer alert | "Wave in 30 seconds" |
| `SetAlertBoss` | Boss approaching | "Boss approaching" |
| `SetAlertTimesUp` | Time limit reached | "Time's up" |
| `OnSwarmStarted` | Swarm begins | "Swarm!" |
| `OnFinalSwarmStarted` | Final swarm | "Final swarm!" |

##### Implementation
```csharp
[HarmonyPatch(typeof(AlertUi))]
public static class AlertUiPatch
{
    private static string lastAlertText = "";
    private static float lastAlertTime = 0f;
    private const float DEBOUNCE_TIME = 1.0f;

    private static void ReadAlertText(AlertUi instance, string source)
    {
        // Debounce to avoid repetitions
        if (Time.time - lastAlertTime < DEBOUNCE_TIME) return;

        // Read alert text from t_alert TextMeshProUGUI
        string text = instance.t_alert.text;
        if (text == lastAlertText) return;

        lastAlertText = text;
        lastAlertTime = Time.time;
        TolkUtil.Speak(text);
    }
}
```

##### Known Issues
- [ ] Some alerts may not trigger (needs more testing)
- [ ] May need to patch additional methods (AnimateAlert, etc.)

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
- `EnemyPatch.cs` - Enemy tracking via InitEnemy/Kill patches + EnemyTracker static class

### Components
- `DirectionalAudioManager.cs` - Beacon tracking, scanning, and scheduling (boss portal volume: 1.2)
- `NAudioBeaconPlayer.cs` - NAudio-based 3D audio with pan/volume/pitch, LoopStream, Pause/Resume
- `WallNavigationAudio.cs` - Wall detection with soft triangle waves + 8-bit collision sound
- `EnemyAnnouncementSystem.cs` - Auto-announce enemies on direction change and new threats (2s cooldown)
- `EnemyAudioSystem.cs` - Synthetic directional beeps for enemy positions (4-direction grouping)
- `PortalDistanceAnnouncer.cs` - Press P to announce distance to next level portal
- `NavigationAudioSystem.cs` - Wind-based objective guidance (currently disabled, experimental)

### New Patches
- `AlertUiPatch.cs` - Game alert messages (waves, boss, time) via screen reader

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
