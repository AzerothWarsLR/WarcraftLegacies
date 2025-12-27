using Launcher.Paths;
using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal abstract class MapCommandContext(string mapName, IncludeFromMap include, bool deleteDestination)
{
  public string MapName { get; } = mapName;
  public SharedPathOptions Paths { get; } = SharedPathOptions.Create(mapName);
  public abstract void Execute();
}
