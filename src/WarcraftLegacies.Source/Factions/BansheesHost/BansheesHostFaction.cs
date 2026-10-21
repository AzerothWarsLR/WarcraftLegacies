using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.BansheesHost.Paths;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions.BansheesHost;

/// <summary>Sylvanas and the fallen of Quel'thalas, reached through the Banshee's Host path.</summary>
public sealed class BansheesHostFaction : Faction, IHasRoleplayPaths
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

  /// <inheritdoc />
  public void AddRoleplayPaths()
  {
    AddPath(new PathRiseOfTheForsakenHorde());
    AddPath(new PathRiseOfTheForsakenScourge());
  }
}
