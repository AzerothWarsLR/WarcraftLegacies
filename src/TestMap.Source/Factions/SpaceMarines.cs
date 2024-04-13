using MacroTools.FactionSystem;
using MacroTools.Powers;
using TestMap.Source.Setup;

namespace TestMap.Source.Factions
{
  public sealed class SpaceMarines : Faction
  {
    /// <inheritdoc />
    public SpaceMarines() : base("Space Marines", PLAYER_COLOR_EMERALD, "|cff00781e",
      @"ReplaceableTextures\CommandButtons\BTNMarine.blp")
    {
      TraditionalTeam = TeamSetup.TeamAlliance;
    }

    /// <inheritdoc />
    public override void OnRegistered()
    {
      AddPower(new DummyPower("Warp Travel", "You can travel via the Warp.", "Feedback"));
      base.OnRegistered();
    }
  }
}