Hollow Abyss Engine
===================

Status: Work in Progress / Systems Prototype

Hollow Abyss Engine is a text-based RPG combat systems prototype written in C#.

The current focus of the project is not final game content, but the underlying combat systems: entity stats, derived combat values, turn-based actions, magic, mana, blocking, enemy behavior, and preset-based testing.


Current Features
----------------
- Player and NPC entity system
- Base attributes and derived combat stats
- Player class presets
- NPC/enemy presets
- Turn-based battle loop
- Player action selection
- Simple enemy action selection
- Physical attacks
- Magic casting with mana costs
- Basic spells: Soulrend and Heal
- Blocking as a turn action
- HP and mana display
- Console UI helper layer
- Typed text effects for battle presentation


Current Combat Actions
----------------------
- Physical Attack
- Cast Magic
- Block

The following actions are planned but not implemented yet:
- Parry
- Use Item
- Escape


Design Goal
-----------
This project is intended as a combat systems design showcase.

The goal is to demonstrate how RPG stats, derived values, turn actions, spell access, mana costs, enemy choices, and defensive mechanics can interact inside a turn-based text RPG framework.


How to Run
----------
Open the project in Visual Studio and run the solution.

The current test matchup is selected manually in Program.cs by choosing one player preset and one NPC preset.

Example:
Player player = P_Knight;
NPC enemy = E_Bandit;


Project Structure
-----------------
Program.cs
- Starts the program and selects the current test battle.

Entity.cs
- Base class for all combatants.
- Handles stats, derived values, HP, mana, spell access, and block state.

Player.cs
- Player-side entity type.

NPC.cs
- Enemy/non-player entity type.

Battle.cs
- Handles the turn-based battle loop, player choices, enemy choices, spell selection, blocking, and win/loss flow.

Combat.cs
- Handles physical and magical damage resolution.

Magic.cs
- Stores basic spells and routes spell casting behavior.

Spell.cs
- Stores spell data such as name and mana cost.

GameUI.cs
- Handles console input and output helpers.

TextEffects.cs
- Handles typed text display effects.

Presets/
- Contains player and NPC preset factory classes for quick combat testing.

docs/
- Contains supporting documentation and class overviews.


Current Basic Spells
--------------------
Soulrend
- Basic offensive spell.
- Uses mana.
- Calls the shared magic damage system.

Heal
- Basic recovery spell.
- Uses mana.
- Restores HP based on a flat value and caster magic-related stats.


Planned Features
----------------
- More combat actions
- Parry system
- Item usage
- Escape mechanics
- More spells with different effects
- Class-dependent and unlockable spells
- Better enemy behavior
- Expanded combat balancing tools
- Progression systems
- Loot and rewards
- Story and encounter structure
- Custom game window / GUI
- Audio support for music and effects


Build Output
------------
Compiled executables and build folders are not intended to be committed to the repository.

The repository should contain source code, project files, presets, and documentation.

Generated folders such as bin/, obj/, and .vs/ should be ignored by Git.


Additional Documentation
------------------------
See docs/ClassOverview.txt for a short explanation of the current classes and functions.
