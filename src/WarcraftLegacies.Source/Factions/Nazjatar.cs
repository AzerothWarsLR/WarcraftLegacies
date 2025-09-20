using MacroTools.FactionSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Nazjatar : Faction
{
  /// <inheritdoc />
  public Nazjatar() : base("Nazjatar", PLAYER_COLOR_PURPLE,
    @"ReplaceableTextures\CommandButtons\BTNNagaSummoner.blp")
  {
    ControlPointDefenderUnitTypeId = UNIT_U02T_CONTROL_POINT_DEFENDER_NAZJATAR;
    ProcessObjectInfo(NazjatarObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
}
