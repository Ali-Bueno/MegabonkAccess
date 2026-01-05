Perfecto. Aquí tienes un \*\*README.md con un enfoque más técnico\*\*, conciso pero lo bastante preciso para que \*\*Gemini o Claude entiendan bien el contexto, la estructura del proyecto y las decisiones técnicas\*\*.



Puedes copiarlo y pegarlo tal cual 👇



---



```md

\# Megabonk Accessibility Project (Technical Overview)



\## Project Goal

This project aims to \*\*add full accessibility support to the Unity game \*Megabonk\*\*\* by working directly with its \*\*decompiled source code\*\*.



The main objective is to make the game \*\*fully playable by blind and visually impaired players\*\*, using:

\- Audio feedback

\- Text-to-speech (TTS)

\- Directional and contextual sound cues



Accessibility is implemented as an \*\*additional layer\*\*, without altering the core gameplay design.



---



\## Project Structure



\### Source Code

\- The decompiled game code is located in:

```



/megabonk code/



```



This folder contains all reconstructed C# scripts from the original Unity build, including:

\- Menu logic

\- UI controllers

\- Gameplay systems

\- Input handling



\### References

\- All required external assemblies and dependencies are located in:

```



/references/



```



This folder includes Unity assemblies and any third-party libraries needed to compile or analyze the project.



\### Text-to-Speech

\- The project uses \*\*Tolk\*\* for screen reader support.

\- Tolk is accessed through the .NET wrapper:

```



TolkDotNet.dll



```



This allows communication with installed screen readers (NVDA, JAWS, SAPI, etc.) without hard dependencies on a specific TTS engine.



---











## Development Phases







### Phase 1 – Menu Accessibility (In Progress)







**Priority:** High







#### Objectives & Status



- [x] **Project Setup**: BepInEx + Tolk (Screen Reader) integration.



- [x] **Main Menu**: Fully announced (Title, "Accessibility Loaded").



- [x] **Button Navigation**: Reads button text (Play, Settings, etc.).



- [x] **Settings Menu - Value Changes**: Reads new values when changing options (Left/Right arrows) using diffing logic.



- [ ] **Settings Menu - State Reading**: Announcing current value when simply focusing the option (Up/Down) is currently **pending/problematic** due to IL2CPP structure.



- [x] Character selection (uses component search due to IL2CPP field obfuscation)



- [x] Level-up item selection (UpgradeButton) - reads item name, description, rarity



- [ ] Meta-progression / upgrades



- [ ] Pause menu







#### Target Systems



- Main menu



- Character selection



- Meta-progression / upgrades



- Pause menu



- Settings menu







---







### Phase 2 – Gameplay Accessibility











\*\*Priority:\*\* After menu completion



\#### Design Constraints

\- No visual dependency

\- No precision platforming

\- Preserve original gameplay flow and difficulty



\#### Planned Systems

\- Directional audio cues for:

\- Enemies (distance + direction)

\- Bosses / elite enemies

\- Important pickups and events

\- Optional \*\*directional assistance system\*\*:

\- Audio-based guidance toward safer areas

\- Alerts when the player is surrounded

\- Fully configurable verbosity and intensity



---



\## Technical Approach



\- Unity-based architecture

\- Direct modification of decompiled C# code

\- Accessibility systems implemented as \*\*modular, reusable components\*\*

\- \*\*Modular Menu Patching:\*\* Separate patch logic for distinctly different menus (Main Menu, Character Selection, Settings) to prevent logic conflicts and audio interruptions.

\- Minimal coupling with gameplay logic

\- Preference for event-driven hooks over polling

\- Audio spatialization compatible with HRTF setups where possible



---



\## Accessibility Philosophy



Accessibility is treated as a \*\*first-class system\*\*, not as optional helpers.



A blind player should be able to:

\- Navigate all menus independently

\- Understand game state through sound and speech

\- Make informed strategic decisions without visual feedback



---



\## Notes

This project is exploratory and iterative.

Code clarity and modularity are prioritized to allow future expansion and maintenance.

```





