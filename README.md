# AzerothWarsCSharp
Warcraft: Legacies was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Warcraft: Legacies in C#.

## Getting started
1. Clone the `main` branch of the repository to your local machine.
2. Run the AzerothWarsCSharp.Launcher project from your chosen IDE. I recommend Visual Studio or Jetbrains Rider. If you're using Visual Studio Code, open the solution as a folder and press CTRL+Shift+B instead.
3. A console should appear and prompt you with a list of available actions.
4. Enter the options to compile and run the test map. If this works, you're done.
5. If step 4 fails, it may be because you need to set up appsettings.json. Navigate to `src\AzerothWarsCSharp.Launcher\` and open `appsettings.json`. Change the Warcraft3ExecutablePath setting to wherever your Warcraft 3 executable is, then repeat step 4.

## Code Documentation
* Documentation specific to this project can be found [here](https://azerothwarslr.github.io/WarcraftLegacies/). It is still a work-in-progress.
* You will also need to understand the Warcraft 3 API. Unfortunately documentation is scarce, but method signatures can be found [here](https://github.com/Drake53/War3Api/blob/master/src/War3Api.Common/Common/Common.cs). I recommend using [Hive Workshop](https://www.hiveworkshop.com/) Discord or forum if you need more information.

## Projects

### AzerothWarsCSharp.Launcher
Compiles Warcraft: Legacies from a series of base files and code instructions into a playable .w3x file.

### AzerothWarsCSharp.MacroTools
A library intended to be useable by any map in the Warcraft 3 Macro-Map genre. Currently only used by Warcraft: Legacies.

### AzerothWarsCSharp.Source
Code specific to Warcraft: Legacies, which gets compiled into Lua before being executed during the map's runtime.

### AzerothWarsCSharp.TestSource
Code to be inserted into a simple test map which demonstrates features from AzerothWarsCSharp.MacroTools.
