using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class FelHorde : Faction
  {
    /// <inheritdoc />
    public FelHorde(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000",
      @"ReplaceableTextures\CommandButtons\BTNPitLord.blp")
    {
    }
  }
}