using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Cthun : Faction
  {
    /// <inheritdoc />
    public Cthun(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Ahn'qiraj", PLAYER_COLOR_WHEAT, "|cffaaa050",
      @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
    {
    }
  }
}