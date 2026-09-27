using MacroTools.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Shared.Powers;

public sealed class WorldTreeProtection
{
  public required Capital WorldTree { get; init; }

  public required string WorldTreeName { get; init; }

  public required string RegionName { get; init; }

  public required Rectangle[] Regions { get; init; }
}
