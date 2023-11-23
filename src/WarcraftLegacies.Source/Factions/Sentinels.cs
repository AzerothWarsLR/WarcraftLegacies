using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Sentinels : Faction
  {
    /// <inheritdoc />
    public Sentinels() : base("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80",
      @"ReplaceableTextures\CommandButtons\BTNPriestessOfTheMoon.blp")
    {
    }
  }
}