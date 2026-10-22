using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.BansheesHost.Paths;
using WarcraftLegacies.Source.Factions.BansheesHost.Quests;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.Factions.Legion.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.BansheesHost;

/// <summary>Sylvanas and the fallen of Quel'thalas, reached through the Banshee's Host path.</summary>
public sealed class BansheesHostFaction : Faction, IHasRoleplayPaths
{
  private readonly QuestBansheesVengeance _bansheesVengeance = new(AllLegends.Quel.Spire, AllLegends.Quel.Sylvanas);
  private readonly QuestRangerLord _rangerLord = new(AllLegends.Quel.Sylvanas);

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
  public override void OnRegistered()
  {
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    AddQuest(_bansheesVengeance);
    AddQuest(_rangerLord);
    AddHeraldOfArchimonde();
    BansheesHostSpells.Setup();
  }

  /// <inheritdoc />
  public void AddRoleplayPaths()
  {
    AddPath(new PathRiseOfTheForsakenHorde(_bansheesVengeance, _rangerLord));
    AddPath(new PathRiseOfTheForsakenScourge(_bansheesVengeance, _rangerLord));
  }

  private void AddHeraldOfArchimonde()
  {
    if (!FactionManager.TryGetFactionByType<LegionFaction>(out var legion))
    {
      return;
    }

    var summonLegion = legion.GetAllQuests().OfType<QuestSummonLegion>().FirstOrDefault();
    if (summonLegion != null && summonLegion.Progress != QuestProgress.Complete)
    {
      AddQuest(new QuestHeraldOfArchimonde(summonLegion, legion));
    }
  }
}
