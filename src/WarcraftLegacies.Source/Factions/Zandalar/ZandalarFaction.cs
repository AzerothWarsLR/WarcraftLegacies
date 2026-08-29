using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
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
    : base("Zandalar", playercolor.Orange, @"ReplaceableTextures\CommandButtons\BTNZuljin.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    //UndefeatedResearch = UPGRADE_R05N_ZANDALAR_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 110,
      Turns = 10
    };


    CinematicMusic = "SadMystery";
    FoodMaximum = 200;
    //ControlPointDefenderUnitTypeId = UNIT_N00N_CONTROL_POINT_DEFENDER_ZANDALAR;

    IntroText = () => Loc.Format(
      "You are playing the mighty {faction}.\n\nYou begin in the Hinterlands, separated from the main forces of Zandalar. To unlock Zandalar, you must capture Zul'Gurub, which has been encircled by monsters.\n\nOnce your territory is secured, you will need to prepare for the Plague of Undeath and the invasion of the Burning Legion. Lordaeron will surely need your help.\n\nYour trolls are fierce warriors. Be sure to utilize them alongside your heroes to turn the tide of battle.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Zandalar")}|r"));

    Nicknames = new List<string>
    {
      "zand"
    };
    //ProcessObjectInfo(ZandalarObjectInfo.GetAllObjectLimits());
  }
  public override void OnRegistered()
  {
    RegisterQuests();
    //ZandalarSpells.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    //var newQuest =
      //StartingQuest = AddQuest(new QuestZulfarrak(AllLegends.Zandalar.Zul ,Regions.Zulfarrak));
      //add the quests here
  }


}
