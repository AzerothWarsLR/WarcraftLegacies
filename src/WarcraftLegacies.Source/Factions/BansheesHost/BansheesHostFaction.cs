using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.BansheesHost;

/// <summary>
/// Sylvanas risen as a banshee, leading the fallen of Quel'thalas for the Scourge. Only reached through the Banshee's
/// Host path in Roleplay mode.
/// </summary>
public sealed class BansheesHostFaction : Faction
{
  /// <inheritdoc />
  public BansheesHostFaction() : base("Banshee's Host", playercolor.Cyan,
    @"ReplaceableTextures\CommandButtons\BTNBanshee.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    NameTakesArticle = true;
    ControlPointDefenderUnitTypeId = UNIT_U028_CONTROL_POINT_DEFENDER_SCOURGE;
    StartingGold = new StartingGold
    {
      Instant = 1000,
      Income = 0,
      Turns = 0
    };
    Nicknames = new List<string>
    {
      "bh",
      "banshee",
      "bansheeshost"
    };
    ProcessObjectInfo(BansheesHostObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered() => SharedFactionConfigSetup.AddSharedFactionConfig(this);
}
