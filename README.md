# WarcraftLegacies
Warcraft: Legacies was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Warcraft: Legacies in C#.

## Contributions
We accept public contributions to the code-base in the form of Pull Requests. Feel free to work on any Issue in the Issues tab, or fix any bug that you're aware of. Please refer to the [Wiki](https://github.com/AzerothWarsLR/WarcraftLegacies/wiki) for a deeper understanding of how to contribute.

## Projects

### MacroTools
Library containing tools intended for consumption by Warcraft 3 maps in the Macro Strategy genre.

### MacroTools.Shared
Library code intended to be consumed by both Warcraft.Cartographer-based CLIs and Warcraft 3 Macro maps, to support data accessible at both map generation time and runtime.

### War3Api.Object
"Fork" of [War3Api.Object](https://github.com/Drake53/War3Api) modified for internal consumption.

### Warcraft.Cartographer
Library built on [War3Net](https://github.com/Drake53/War3Net) providing advanced tools for serializing, deserializing, compiling, and postprocessing Warcraft 3 maps.

### WarcraftLegacies.CLI
Command line executable that leverages Warcraft.Cartographer to support the editing, testing, and publishing of Warcraft Legacies.

### WarcraftLegacies.Shared
Game code shared between WarcraftLegacies.CLI and WarcraftLegacies.Source, to support data accessible at both map generation time and runtime.

### WarcraftLegacies.Source
Code specific to Warcraft: Legacies, which gets compiled into Lua before being executed during the map's runtime.

### WarcraftLegacies.Map.Tests
Tests that ensure the Warcraft Legacies map contains valid data, and that it is in accordance with our game principles.
