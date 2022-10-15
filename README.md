# AzerothWarsCSharp
Warcraft: Legacies was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Warcraft: Legacies in C#.

## Code Documentation
Can be found [here](https://azerothwarslr.github.io/AzerothWarsCSharp/). This documentation is still a work-in-progress.

## Projects

### AzerothWarsCSharp.Launcher
Compiles Warcraft: Legacies from a series of base files and code instructions. 

### AzerothWarsCSharp.MacroTools
A library intended to be useable by any map in the Warcraft 3 Macro-Map genre. Currently only used by Warcraft: Legacies.

### AzerothWarsCSharp.Source
Code specific to Warcraft: Legacies, which gets compiled into Lua before being executed during the map's runtime.

### AzerothWarsCSharp.TestSource
Code to be inserted into a simple test map which demonstrates features from AzerothWarsCSharp.MacroTools.
