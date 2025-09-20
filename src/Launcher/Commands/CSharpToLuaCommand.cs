#nullable enable
using System.CommandLine;
using System.IO;
using Launcher.Services;
using Launcher.Settings;
using War3Net.Build;

namespace Launcher.Commands;

internal static class CSharpToLuaCommand
{
  public static void RegisterCSharpToLuaCommand(this RootCommand rootCommand)
  {
    var command = new Command("csharp-to-lua", "Transpiles C# source code into Lua and writes it into an existing Warcraft 3 map folder.");
    rootCommand.Add(command);

    var mapNameArgument = new Argument<string>(
      name: "mapname",
      description: "The name of the map folder inside the output directory (without extension). Transpiled code will be written into this folder.");
    command.AddArgument(mapNameArgument);

    var outputDirectoryArgument = new Argument<string>(
      name: "outputDirectory",
      description: "The directory containing map folders. The specified map folder will be resolved as a subdirectory of this path.");
    command.AddArgument(outputDirectoryArgument);

    var sourceCodeFolderArgument = new Argument<string>(
      name: "sourcecodepath",
      description: "The directory in which the C# source code is stored. This code will be transpiled into Lua and written into the map folder.");
    command.AddArgument(sourceCodeFolderArgument);

    command.SetHandler(Run, mapNameArgument, outputDirectoryArgument, sourceCodeFolderArgument);
  }

  private static void Run(string mapName, string outputDirectory, string sourceCodeFolderPath)
  {
    var compilerSettings = new CompilerSettings
    {
      ArtifactsPath = $"{Path.Combine(outputDirectory, mapName)}.w3x"
    };

    AdvancedMapBuilder.AddCSharpCode(Map.Open(compilerSettings.ArtifactsPath), sourceCodeFolderPath, compilerSettings);
  }
}
