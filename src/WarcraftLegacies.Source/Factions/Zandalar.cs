using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Zandalar : Faction
  {
    /// <inheritdoc />
    public Zandalar(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Zandalar", PLAYER_COLOR_PEACH, "|cffff8c6c",
      @"ReplaceableTextures\CommandButtons\BTNHeadHunterBerserker.blp")
    {
    }
  }
}