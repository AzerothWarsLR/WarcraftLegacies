using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.Theramore;

/// <summary>Jaina and the survivors of the north, reached through the Theramore path.</summary>
public sealed class TheramoreFaction : Faction
{
  /// <inheritdoc />
  public TheramoreFaction() : base("Theramore", playercolor.LightBlue, @"ReplaceableTextures\CommandButtons\BTNJaina.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    ControlPointDefenderUnitTypeId = UNIT_N00N_CONTROL_POINT_DEFENDER_DALARAN;
    StartingGold = new StartingGold
    {
      Instant = 1000,
      Income = 0,
      Turns = 0
    };
    Nicknames = new List<string>
    {
      "thera",
      "theramore"
    };
    ProcessObjectInfo(TheramoreObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    TheramoreSpells.Setup();
  }
}
