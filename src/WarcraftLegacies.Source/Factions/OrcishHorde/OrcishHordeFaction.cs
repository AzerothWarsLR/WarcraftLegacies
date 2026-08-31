using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

public sealed class OrcishHordeFaction : Faction
{
  /// <inheritdoc />
  public OrcishHordeFaction() : base("Orcish Horde", playercolor.Red, @"ReplaceableTextures\CommandButtons\BTNThrall.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    ControlPointDefenderUnitTypeId = UNIT_N0B6_CONTROL_POINT_DEFENDER_FROSTWOLF;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 130,
      Turns = 10
    };
    CinematicMusic = "SadMystery";
    IntroText = () => Loc.Format(
      "You are playing as the {faction}.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Orcish Horde")}|r"));
    Nicknames = new List<string>
    {
      "horde",
      "oh",
      "orc",
      "orcs"
    };
    ProcessObjectInfo(OrcishHordeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    OrcishHordeSpells.Setup();
    OrcishHordeTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
}
