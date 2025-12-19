using System.CommandLine;
using System.IO;
using MapBuildCommand = Launcher.Commands.MapCommand<Launcher.Commands.MapBuildContext>;
using MapGenerateCommand = Launcher.Commands.MapCommand<Launcher.Commands.MapGenerateContext>;
using MapSerializeCommand = Launcher.Commands.MapCommand<Launcher.Commands.MapSerializationContext>;

namespace Launcher.Commands;

internal static class MapCommandBuilder
{
  public static Command Build()
  {
    return new MapBuildCommand("build", "Converts raw map data into a Warcraft 3 map folder, for editing in the World Editor.")
    {
      Configure = ctx =>
      {
        ctx.OutputKind = MapOutputKind.Directory;
        ctx.Builder.ShouldBackup = true;
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
        ctx.Builder.ShouldLaunch = true;
        ctx.Builder.ShouldTranspile = true;
        ctx.Builder.ShouldMigrate = true;
        ctx.Builder.W3XFolderPath = Path.Combine(ctx.Paths.ScriptArtifactPath, $"{ctx.MapName}.w3x");
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
        ctx.Builder.ShouldMigrate = true;
        ctx.Builder.ShouldSetVersion = true;
        ctx.Builder.ShouldTranspile = true;
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
