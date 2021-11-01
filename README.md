# AzerothWarsCSharp
Azeroth Wars: Legacy Reborn was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Azeroth Wars: Legacy Reborn in C#.

### AzerothWarsCSharp.DataExtractor
Transforms an object data file (.w3o) into a C# class file which gets placed into AzerothWarsCSharp.Launcher.

### AzerothWarsCSharp.Generated
Variables extracted from the base Warcraft 3 map file (.w3x).

### AzerothWarsCSharp.Launcher
Compiles the map from a series of base files and code instructions. 

### AzerothWarsCSharp.Source
The map's code, which gets compiled into Lua before being executed during the map's runtime.
