using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.FelHorde.Mechanics;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.FelHorde;

public sealed class FelHordeFaction : Faction
{
  /// <inheritdoc />
  public FelHordeFaction()
    : base("Fel Horde", playercolor.Green, @"ReplaceableTextures\CommandButtons\BTNPitLord.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    UndefeatedResearch = UPGRADE_R05L_FEL_HORDE_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 200,
      Turns = 10
    };
    CinematicMusic = "Doom";
    ControlPointDefenderUnitTypeId = UNIT_N0AA_CONTROL_POINT_DEFENDER_FEL;
    IntroText = IntroText = $"You are playing as the bloodthirsty {PrefixCol}Fel Horde|r.\n\n" +
                            "You begin in Nagrand, cut off from your forces in Hellfire Citadel. You must raise an army and quickly conquer Outland.\n\n" +
                            "Once Outland is under your control, gather your hordes and prepare to invade Azeroth through the Dark Portal.\n\n" +
                            "The Alliance is gathering outside the Dark Portal to stop you, so prepare for a very hard breakout.";

    FoodMaximum = 250;
    Nicknames = new List<string>
    {
      "fh",
      "fel"
    };
    ProcessObjectInfo(FelHordeObjectInfo.GetAllObjectInfos());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    JuggernautDeath.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, -1);
  }

  private void RegisterQuests()
  {
    var questHellfireCitadel = AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
    AddQuest(new QuestRuinsofShadowmoon(Regions.ShadowmoonBaseUnlock));
    AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, Regions.DarkPortalUnlock, new[] { questHellfireCitadel }));
    AddQuest(new QuestFelHordeKillIronforge(AllLegends.Ironforge.GreatForge));
    AddQuest(new QuestFelHordeKillStormwind(AllLegends.Stormwind.StormwindKeep));
    AddQuest(new QuestGuldansLegacy());
    AddQuest(new QuestDarkPortal(
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center)));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }
}
