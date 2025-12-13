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

    command.SetHandler(Run, mapNameArgument);
  }

  private static void Run(string mapName)
  {
    var appSettings = AppSettings.Load();

    var artifactPath = Path.Combine(appSettings.CompilerSettings.RootPath, PathConventions.Artifacts, $"{mapName}.w3x");
    var advancedMapBuilder = new AdvancedMapBuilder(new AdvancedMapBuilderOptions
    {
      MapName = mapName,
      OutputType = MapOutputType.None,
      RootPath = appSettings.CompilerSettings.RootPath,
      Version = appSettings.MapSettings.Version
    });
    advancedMapBuilder.AddCSharpCode(Map.Open(artifactPath), mapName);
  }
}
