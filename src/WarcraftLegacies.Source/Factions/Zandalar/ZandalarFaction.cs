using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Warsong;
using WarcraftLegacies.Source.Factions.Zandalar;
using WarcraftLegacies.Source.Factions.Zandalar.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;
namespace WarcraftLegacies.Source.Factions.Zandalar;

public sealed class ZandalarFaction : Faction
{
  /// <inheritdoc />
  public ZandalarFaction()
    : base("Zandalar", playercolor.Peach, @"ReplaceableTextures\CommandButtons\BTNForestTrollTrapper.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    UndefeatedResearch = UPGRADE_MD31_ZANDALAR_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 110,
      Turns = 10
    };
    ControlPointDefenderUnitTypeId = UNIT_MD32_CONTROL_POINT_DEFENDER_ZANDALAR;

    IntroText = () => Loc.Format(
      "You are playing the mighty {faction}.\n\nYou begin in Tanaris, separated from the main forces of Zandalar. To unlock Zandalar, you must capture Zul'farak and Tol'vir, which has been encircled by hostile forces.\n\nOnce your territory is secured, you will need to prepare to march north and fight the Elven Alliance.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Zandalar")}|r"));

    Nicknames = new List<string>
    {
      "zand"
    };
    ProcessObjectInfo(ZandalarObjectInfo.GetAllObjectLimits());
  }


  public override void OnRegistered()
  {
    RegisterQuests();
    ZandalarTraits.Setup();
    //ZandalarSpells.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var newQuest =
      StartingQuest = AddQuest(new QuestZulfarrak(Regions.Zulfarrak, AllLegends.Zandalar.Zul));
      AddQuest(new QuestZandalar(Regions.ZandalarUnlock));
      AddQuest(new QuestZandalarOutpost());
      AddQuest(new QuestGundrak(AllLegends.Neutral.Gundrak));
      AddQuest(new QuestJinthaAlor(AllLegends.Neutral.Jinthaalor));
      AddQuest(new QuestZulgurub(AllLegends.Neutral.Zulgurub));

    //add the quests here
  }


}
