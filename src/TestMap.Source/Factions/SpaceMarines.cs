using MacroTools.FactionSystem;
using MacroTools.Powers;
using TestMap.Source.Setup;

namespace TestMap.Source.Factions;

public sealed class SpaceMarines : Faction
{
  /// <inheritdoc />
  public SpaceMarines() : base("Space Marines", PLAYER_COLOR_LIGHT_BLUE, @"ReplaceableTextures\CommandButtons\BTNMarine.blp")
  {
    TraditionalTeam = TeamSetup.TeamAlliance;
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    AddPower(new DummyPower("Warp Travel", "You can travel via the Warp.", "Feedback"));
    AddPower(new DummyPower("For the Emperor", "Your dudes fight harder.", "Garithos"));
    AddPower(new DummyPower("Holy", "Very good, very holy.", "HolyBolt"));
    AddPower(new DummyPower("Death", "Your units die constantly.", "DeathCoil"));
    base.OnRegistered();
  }
}
