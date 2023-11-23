using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Warsong : Faction
  {
    /// <inheritdoc />
    public Warsong(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000",
      @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
    {
    }
  }
}