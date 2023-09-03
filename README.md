# WarcraftLegacies
Warcraft: Legacies was a Warcraft 3 macro-strategy map representing the events of the Warcraft story from Reign of Chaos through to World of Warcraft: Cataclysm.

This project is a complete rewrite of Warcraft: Legacies in C#.

## Getting started
1. Clone the `main` branch of the repository to your local machine.
2. Run the `WarcraftLegacies.Launcher` project from Visual Studio or Jetbrains Rider using the `WarcraftLegacies: Test` launch setting.
4. You should get an error saying it can't find your Warcraft 3 path. Navigate to `src\WarcraftLegacies.Launcher\` and open `appsettings.{YOURUSERNAME}.json`. Change the Warcraft3ExecutablePath setting to wherever your Warcraft 3 executable is, then repeat step 2. It should now launch.

## Editing object data
Warcraft Legacies uses a custom build system; map files are stored as .json instead of binaries, which makes editing object data and committing it a little complicated. Here's how you can do it:
1. Clone the repository to your local machine.
2. Run the `WarcraftLegacies.Launcher` project from Visual Studio using the `WarcraftLegacies: MapData to W3X` launch etting.
3. Check the `maps` folder; you should have a new folder called `WarcraftLegacies.w3x`.
4. Open `WarcraftLegacies.w3x` using the Warcraft 3 World Editor.
5. Make any changes you want to make in the Editor, then save the map.
6. Using Visual Studio, run `WarcraftLegacies: W3X to MapData`.
7. Your changes should now be reflected in the `mapdata\WarcraftLegacies` folder. These changes can be committed back to version control.

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
