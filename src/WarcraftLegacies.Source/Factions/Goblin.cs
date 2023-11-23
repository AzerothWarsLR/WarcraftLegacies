using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Goblin : Faction
  {
    /// <inheritdoc />
    public Goblin(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080",
      @"ReplaceableTextures\CommandButtons\BTNHeroTinker.blp")
    {
    }
  }
}