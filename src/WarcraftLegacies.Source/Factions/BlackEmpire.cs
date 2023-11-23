using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {
    /// <inheritdoc />
    public BlackEmpire(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("BlackEmpire", PLAYER_COLOR_TURQUOISE, "|C0000FFFF",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
    }
  }
}