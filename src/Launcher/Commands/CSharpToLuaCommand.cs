#nullable enable
using System.CommandLine;
using Launcher.Services;
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
    var sharedPathOptions = SharedPathOptions.Create(mapName);
    var advancedMapBuilderOptions = AdvancedMapBuilderOptions.Create(sharedPathOptions);
    advancedMapBuilderOptions.ScriptArtifactPath = advancedMapBuilderOptions.OutputPath;
    var advancedMapBuilder = new AdvancedMapBuilder(advancedMapBuilderOptions);
    advancedMapBuilder.AddCSharpCode(Map.Open(sharedPathOptions.OutputPath));
  }
}
