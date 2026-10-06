using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Paths;
using WarcraftLegacies.CLI.Settings;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.CLI.Contexts;

internal abstract class MapCommandContext(string mapName, IncludeFromMap include, bool deleteDestination)
{
  public string MapName { get; } = mapName;
  public SharedPathOptions Paths { get; } = DefaultOptionsFactory.CreateSharedPathOptions(mapName);

  /// <summary>
  /// The locale to build for, such as <c>zhCN</c>, or <see langword="null"/> to build from the base map data.
  /// </summary>
  public string Locale { get; set; }

  public abstract void Execute();

  /// <summary>
  /// Loads the build-time text for the requested locale. Call this before anything that writes user-visible text
  /// into map data.
  /// </summary>
  protected void ApplyLocale() =>
    BuildText.Load(Paths.MapDataPathOptions.RootPath, Locale);
}
