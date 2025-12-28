using Warcraft.Cartographer.Deserialization;
using Warcraft.Cartographer.Paths;
using WarcraftLegacies.CLI.Settings;

namespace WarcraftLegacies.CLI.Contexts;

internal abstract class MapCommandContext(string mapName, IncludeFromMap include, bool deleteDestination)
{
  public string MapName { get; } = mapName;
  public SharedPathOptions Paths { get; } = DefaultOptionsFactory.CreateSharedPathOptions(mapName);
  public abstract void Execute();
}
