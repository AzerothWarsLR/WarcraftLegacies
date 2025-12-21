using System;
using System.CommandLine;
using System.IO;
using AutoMapper;
using Launcher.Services;

using MapBuildCommand = Launcher.MapCommand<Launcher.MapBuildContext>;
using MapSerializeCommand = Launcher.MapCommand<Launcher.MapSerializationContext>;

namespace Launcher;

internal static class Program
{
  private static int Main(string[] args)
  {
    return Create().Parse(args).Invoke();
  }

  private static RootCommand Create()
  {
    return new RootCommand
    {
      new Command("json-to-w3x")
      {
        Commands.Build(),
        Commands.Test(),
        Commands.Publish()
      },
      new Command("w3x-to-json")
      {
        Commands.Serialize()
      }
    };
  }
}

internal static class Commands
{
  public static Command Build()
  {
    return new MapBuildCommand("build")
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
    return new MapBuildCommand("test")
    {
      Configure = ctx =>
      {
        ctx.OutputKind = MapOutputKind.Directory;
        ctx.Builder.ShouldLaunch = true;
        ctx.Builder.ShouldTranspile = true;
        ctx.Builder.ShouldMigrate = true;
        ctx.Builder.OutputPath = Path.Combine(ctx.Paths.ScriptArtifactPath, $"{ctx.MapName}.w3x");
      }
    };
  }

  public static Command Publish()
  {
    return new MapBuildCommand("publish")
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
    return new MapSerializeCommand("serialize");
  }
}

internal class MapCommand<T> : Command where T : MapCommandContext
{
  public Action<T> Configure { get; init; }

  public MapCommand(string name, string description = null) : base(name, description)
  {
    Argument<string> mapNameArg = new("map-name")
    {
      Description = "The directory containing the map."
    };

    Arguments.Add(mapNameArg);

    SetAction(result =>
    {
      var ctx = CreateContext(result.GetValue(mapNameArg));
      Configure?.Invoke(ctx);
      ctx.Execute();
    });
  }

  private static T CreateContext(string mapName) => (T)Activator.CreateInstance(typeof(T), mapName);
}

internal abstract class MapCommandContext(string mapName)
{
  public string MapName { get; } = mapName;
  public SharedPathOptions Paths { get; } = SharedPathOptions.Create(mapName);
  public abstract void Execute();
}

internal enum MapOutputKind
{
  Directory,
  File
}

internal sealed class MapBuildContext : MapCommandContext
{
  public AdvancedMapBuilderOptions Builder { get; }
  public MapOutputKind OutputKind { get; set; }

  public MapBuildContext(string mapName) : base(mapName)
  {
    Builder = AdvancedMapBuilderOptions.Create(Paths);
  }

  public override void Execute()
  {
    var converter = new MapDataToMapConverter(new Mapper(AutoMapperConfigurationProvider.GetConfiguration()));
    var builder = new AdvancedMapBuilder(Builder);

    switch (OutputKind)
    {
      case MapOutputKind.Directory:
        {
          var (map, directories) = converter.ConvertToMapAndAdditionalFiles(Paths.MapDataPath);
          builder.SaveMapDirectory(map, directories);
          break;
        }

      case MapOutputKind.File:
        {
          var (map, directories) = converter.ConvertToMapAndAdditionalFileDirectories(Paths.MapDataPath);
          builder.SaveMapFile(map, directories);
          break;
        }

      default:
        throw new ArgumentOutOfRangeException($"Unsupported output kind: {OutputKind}");
    }
  }
}

internal sealed class MapSerializationContext(string mapName) : MapCommandContext(mapName)
{
  public override void Execute()
  {
    var converter = new W3XToMapDataConverter(new Mapper(AutoMapperConfigurationProvider.GetConfiguration()));
    converter.Convert(Paths.OutputPath, Paths.MapDataPath);
  }
}
