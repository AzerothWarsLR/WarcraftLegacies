using System.CommandLine;
using System.IO;
using WarcraftLegacies.CLI.Contexts;
using WarcraftLegacies.CLI.Settings;
using MapBuildCommand = WarcraftLegacies.CLI.Commands.MapCommand<WarcraftLegacies.CLI.Contexts.MapBuildContext>;
using MapGenerateCommand = WarcraftLegacies.CLI.Commands.MapCommand<WarcraftLegacies.CLI.Contexts.MapGenerateContext>;
using MapSerializeCommand = WarcraftLegacies.CLI.Commands.MapCommand<WarcraftLegacies.CLI.Contexts.MapSerializationContext>;

namespace WarcraftLegacies.CLI.Commands;

internal static class MapCommandFactory
{
  public static Command Build()
  {
    return new MapBuildCommand("build", "Converts raw map data into a Warcraft 3 map folder, for editing in the World Editor.")
    {
      Configure = ctx =>
      {
        ctx.OutputKind = MapOutputKind.Directory;
        ctx.AdvancedMapBuilderOptions.ShouldBackup = true;
      }
    };
  }

  public static Command Test()
  {
    return new MapBuildCommand("test", "Compiles a .w3x folder into the artifacts folder, then launches it for testing purposes.")
    {
      Configure = ctx =>
      {
        ctx.OutputKind = MapOutputKind.Directory;
        ctx.AdvancedMapBuilderOptions.ShouldLaunch = true;
        ctx.AdvancedMapBuilderOptions.ShouldTranspile = true;
        ctx.AdvancedMapBuilderOptions.ShouldMigrate = true;
        ctx.AdvancedMapBuilderOptions.W3XFolderPath = Path.Combine(ctx.Paths.ScriptArtifactPath, $"{ctx.MapName}.w3x");
        ctx.AdvancedMapBuilderOptions.TestingPlayerSlot = AppSettings.Current.CompilerSettings.TestingPlayerSlot;
      }
    };
  }

  public static Command Publish()
  {
    return new MapBuildCommand("publish", "Publishes a release-ready w3x file.")
    {
      Configure = ctx =>
      {
        ctx.OutputKind = MapOutputKind.File;
        ctx.AdvancedMapBuilderOptions.ShouldMigrate = true;
        ctx.AdvancedMapBuilderOptions.ShouldSetVersion = true;
        ctx.AdvancedMapBuilderOptions.ShouldTranspile = true;
      }
    };
  }

  public static Command Serialize()
  {
    return new MapSerializeCommand("serialize", "Converts a Warcraft 3 map file into raw map data.");
  }

  public static Command Generate()
  {
    return new MapGenerateCommand("constants", "Produces Constants and Regions C# files for Object Editor objects and Regions in map data.");
  }
}
