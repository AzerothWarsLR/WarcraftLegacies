using Launcher.Services;

namespace Launcher.CLI.Contexts;

internal abstract class MapCommandContext(string mapName)
{
  public string MapName { get; } = mapName;
  public SharedPathOptions Paths { get; } = SharedPathOptions.Create(mapName);
  public abstract void Execute();
}
