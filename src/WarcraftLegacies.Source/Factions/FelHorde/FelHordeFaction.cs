using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.FelHorde.Mechanics;
using WarcraftLegacies.Source.Factions.FelHorde.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.FelHorde;

public sealed class FelHordeFaction : Faction, IHasRoleplayIntro
{
  /// <inheritdoc />
  public FelHordeFaction()
    : base("Fel Horde", playercolor.Green, @"ReplaceableTextures\CommandButtons\BTNPitLord.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    NameTakesArticle = true;
    UndefeatedResearch = UPGRADE_R05L_FEL_HORDE_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 210,
      Turns = 10
    };
    CinematicMusic = "Doom";
    ControlPointDefenderUnitTypeId = UNIT_N0AA_CONTROL_POINT_DEFENDER_FEL;
    IntroText = () => Loc.Format(
      "You are playing as the bloodthirsty {faction}.\n\nYou begin in Nagrand, cut off from your forces in Hellfire Citadel. You must raise an army and quickly conquer Outland.\n\nOnce Outland is under your control, gather your hordes and prepare to invade Azeroth through the Dark Portal.\n\nThe Alliance is gathering outside the Dark Portal to stop you, so prepare for a very hard breakout.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Fel Horde")}|r"));

    FoodMaximum = 250;
    Nicknames = new List<string>
    {
      "fh",
      "fel"
    };
    ProcessObjectInfo(FelHordeObjectInfo.GetAllObjectInfos());
  }

  /// <inheritdoc />
  public string RoleplayIntroText => Loc.Format(
    "You are playing as the bloodthirsty {faction}.\n\nThe orcs of Outland have drunk deep of demon blood, and they thirst for the war they lost on Azeroth. Magtheridon rules them from Hellfire Citadel, and his clans are eager for slaughter.\n\nThe Dark Portal will open soon. Gather your hordes and pour into Azeroth, where Stormwind, Ironforge and Kul Tiras of the South Alliance are waiting to stop you, so prepare for a very hard breakout.\n\nIllidan and his followers covet Outland. Should Magtheridon fall to them, the clans may be forced to bow to a new master.",
    ("{faction}", $"{PrefixCol}{Loc.Get("Fel Horde")}|r"));

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    FelHordeSpells.Setup();
    FelHordeTraits.Setup();
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
    var questBlackrock = new QuestBlackrock(Regions.BlackrockUnlock, Regions.DarkPortalUnlock, new[] { questHellfireCitadel });
    AddQuest(questBlackrock);
    AddQuest(new QuestFelHordeKillIronforge(AllLegends.Ironforge.GreatForge));
    AddQuest(new QuestFelHordeKillStormwind(AllLegends.Stormwind.StormwindKeep));
    AddQuest(new QuestGuldansLegacy());
    AddQuest(new QuestDarkPortal(
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center))
    {
      HandsOverOutpostOf = questBlackrock
    });
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
  }
}
