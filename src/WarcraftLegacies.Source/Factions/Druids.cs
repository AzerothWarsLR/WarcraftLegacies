using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Druids : Faction
  {
    /// <inheritdoc />
    public Druids(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Druids", PLAYER_COLOR_BROWN, "|c004e2a04",
      @"ReplaceableTextures\CommandButtons\BTNFurion.blp")
    {
    }
  }
}