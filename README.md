# WarcraftLegacies
Warcraft: Legacies was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Warcraft: Legacies in C#.

## Getting started
1. Clone the `main` branch of the repository to your local machine.
2. Run the `WarcraftLegacies.Launcher` project from your chosen IDE. I recommend Visual Studio or Jetbrains Rider. If you're using Visual Studio Code, open the solution as a folder and press CTRL+Shift+B instead.
3. A console should appear and prompt you with a list of available actions.
4. Enter the options to compile and run the test map. If this works, you're done.
5. If step 4 fails, it may be because you need to set up appsettings.json. Navigate to `src\WarcraftLegacies.Launcher\` and open `appsettings.json`. Change the Warcraft3ExecutablePath setting to wherever your Warcraft 3 executable is, then repeat step 4.

## Code Documentation
* Documentation specific to this project can be found [here](https://azerothwarslr.github.io/WarcraftLegacies/). It is still a work-in-progress.
* You will also need to understand the Warcraft 3 API. Unfortunately documentation is scarce, but method signatures can be found [here](https://github.com/Drake53/War3Api/blob/master/src/War3Api.Common/Common/Common.cs). I recommend using [Hive Workshop](https://www.hiveworkshop.com/) Discord or forum if you need more information.

## Contributing
We accept public contributions to the code-base in the form of Pull Requests. Feel free to work on any Issue in the Issues tab, or fix any bug that you're aware of.

Please note that we cannot accept public Pull Requests that involve changes to the Warcraft 3 map itself (that is, anything in the .w3x folder). This is because the map is a binary and it may conflict with changes we're making. If you want to work on the .w3x file, please message me about joining the team officially.

## Projects

### Launcher
Compiles source code and source .w3x files into playable .w3x maps.

### MacroTools
A library intended to be usable by any map in the Warcraft 3 Macro-Map genre. Currently only used by Warcraft: Legacies and the test map.

### WarcraftLegacies.Source
Code specific to Warcraft: Legacies, which gets compiled into Lua before being executed during the map's runtime.

### TestMap.Source
Code to be inserted into a simple test map which demonstrates features from the MacroTools project.
