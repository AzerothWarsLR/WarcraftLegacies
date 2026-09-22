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

  /// <summary>
  /// Merges a second language into a published map, so one map file serves several languages.
  /// </summary>
  public static Command MergeLocales()
  {
    Argument<string> baseMapArg = new("base-map")
    {
      Description = "Path to the published map, which supplies the neutral (English) text."
    };

    Argument<string> localizedMapArg = new("localized-map")
    {
      Description = "Path to a map built with --locale, which supplies the translated files."
    };

    Argument<string> outputArg = new("output")
    {
      Description = "Path of the merged map to write."
    };

    Argument<string> localeArg = new("locale")
    {
      Description =
        "The locale to store the translated files for, such as zh-CN, or a comma-separated list of them, such as " +
        "zhcn.w3mod,zhtw.w3mod. Each name gets its own _Locales folder holding the same files, which is how one " +
        "release serves both regions of a language without a second translation."
    };

    Option<bool> localeFolderOption = new("--locale-folder")
    {
      Description =
        "Store the translated files under _Locales/<locale>/, the layout Blizzard's World Editor produces when " +
        "a map is saved as a scenario folder, instead of under their plain names. This is the layout Warcraft III " +
        "honours: a locale tag on a map's own entry is ignored, and the map then reads half in each language."
    };

    Option<string> untaggedOption = new("--untagged")
    {
      Description =
        "Comma-separated files to take from the localized map but store at the map root with no locale tag. " +
        "Warcraft III reads its script from the root, so 'war3map.lua' belongs here; the localization table falls " +
        "through to the English source strings it is keyed by for every other language. The interface skin and the " +
        "misc file do not need this: tagging those is what makes the menus follow the client's own language, while " +
        "an untagged copy shows one language's labels to every client."
    };

    var command = new Command("merge-locales",
      "Merges a map built for another locale into the published map, so one .w3x serves every language.")
    {
      baseMapArg,
      localizedMapArg,
      outputArg,
      localeArg,
      localeFolderOption,
      untaggedOption
    };

    command.SetAction(parseResult =>
    {
      var untagged = parseResult.GetValue(untaggedOption);
      var plain = string.IsNullOrWhiteSpace(untagged)
        ? System.Array.Empty<string>()
        : untagged.Split(',', System.StringSplitOptions.RemoveEmptyEntries
          | System.StringSplitOptions.TrimEntries);

      return LocaleMergeCommand.Run(
        parseResult.GetValue(baseMapArg),
        parseResult.GetValue(localizedMapArg),
        parseResult.GetValue(outputArg),
        parseResult.GetValue(localeArg),
        parseResult.GetValue(localeFolderOption),
        plain);
    });

    return command;
  }

  /// <summary>
  /// Reports which language each file of a built map is stored for.
  /// </summary>
  public static Command Locales()
  {
    Argument<string> mapArg = new("map")
    {
      Description = "Path to a built map to inspect."
    };

    Argument<string[]> filesArg = new("files")
    {
      Description = "Optional file names whose content should be shown per language.",
      Arity = ArgumentArity.ZeroOrMore
    };

    var command = new Command("locales", "Reports which language each file of a built map is stored for.")
    {
      mapArg,
      filesArg
    };

    command.SetAction(parseResult => LocaleAuditCommand.Run(
      parseResult.GetValue(mapArg),
      parseResult.GetValue(filesArg) ?? []));

    return command;
  }

  public static Command Generate()
  {
    return new MapGenerateCommand("constants", "Produces Constants and Regions C# files for Object Editor objects and Regions in map data.");
  }
}
