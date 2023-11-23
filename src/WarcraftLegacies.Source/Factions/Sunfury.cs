using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Sunfury : Faction
  {
    /// <inheritdoc />
    public Sunfury(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Sunfury", PLAYER_COLOR_MAROON, "|cffff0000",
      @"ReplaceableTextures\CommandButtons\BTNBloodMage2.blp")
    {
    }
  }
}