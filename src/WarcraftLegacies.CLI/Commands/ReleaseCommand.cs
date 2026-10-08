using System;
using System.IO;
using Warcraft.Cartographer.Deserialization;
using WarcraftLegacies.CLI.Contexts;

namespace WarcraftLegacies.CLI.Commands;

internal static class ReleaseCommand
{
  private const string ChineseLocale = "zhCN";
  private const string ChineseLocaleFolders = "zhcn.w3mod,zhtw.w3mod";
  private const string Script = "war3map.lua";

  public static int Run(string mapName)
  {
    var english = PublishBuild(mapName, null, "en");
    var chinese = PublishBuild(mapName, ChineseLocale, ChineseLocale);

    var releasePath = new MapBuildContext(mapName, IncludeFromMap.AllExceptScript, true)
      .AdvancedMapBuilderOptions.PublishedMapPath;

    var result = LocaleMergeCommand.Run(english, chinese, releasePath, ChineseLocaleFolders,
      useLocaleFolder: true, unlocalized: [Script], useStringTable: true);

    if (result == 0)
    {
      Console.WriteLine($"Release map: {Path.GetFullPath(releasePath)}");
      Console.WriteLine($"English-only fallback: {Path.GetFullPath(english)}");
    }

    return result;
  }

  private static string PublishBuild(string mapName, string locale, string suffix)
  {
    var ctx = new MapBuildContext(mapName, IncludeFromMap.AllExceptScript, true);
    MapCommandFactory.ConfigurePublish(ctx);
    ctx.Locale = locale;

    var options = ctx.AdvancedMapBuilderOptions;
    var publishedPath = options.PublishedMapPath;
    options.PublishedMapPath = Path.Combine(Path.GetDirectoryName(publishedPath)!,
      $"{Path.GetFileNameWithoutExtension(publishedPath)}-{suffix}{Path.GetExtension(publishedPath)}");

    ctx.Execute();
    return options.PublishedMapPath;
  }
}
