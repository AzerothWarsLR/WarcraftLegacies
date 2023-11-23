using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Ironforge : Faction
  {
    /// <inheritdoc />
    public Ironforge(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01",
      @"ReplaceableTextures\CommandButtons\BTNHeroMountainKing.blp")
    {
    }
  }
}