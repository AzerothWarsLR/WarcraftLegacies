using System;
using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Factions.Choices;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Lordaeron.Researches;
using WarcraftLegacies.Source.Factions.Warsong.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Warsong;

public sealed class WarsongFaction : Faction
{
  /// <inheritdoc />
  public WarsongFaction() : base("Warsong", playercolor.Red,
    @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
  {
    TraditionalTeam = TeamSetup.Horde;
    UndefeatedResearch = UPGRADE_R05W_WARSONG_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 130,
      Turns = 10
    };
    CinematicMusic = "DarkAgents";
    ControlPointDefenderUnitTypeId = UNIT_N0D6_CONTROL_POINT_DEFENDER_WARSONG;
    IntroText = () => Loc.Format(
      "You are playing as the fierce and relentless {faction}.\n\nBegin swiftly by rescuing your Chieftain, Grom Hellscream, who is trapped in battle and consumed by demonic fury. His survival is paramount.\n\nWith Grom secured, expand your dominance by subduing or pillaging nearby races to bolster your clan's strength.\n\nWork closely with your new elven allies—only together can you overcome the looming threat of the Old Gods.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Warsong Clan")}|r"));
    Nicknames = new List<string>
    {
      "ws",
      "war"
    };
    ProcessObjectInfo(WarsongObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    ReplaceWithFactionUnits(this);
    RegisterQuests();
    RegisterDialogue();
    RegisterFlightPath();
    WarsongSpells.Setup();
    WarsongTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    Regions.BarrenAmbient2.CleanupHostileUnits();
    Regions.AshenvaleCreeps.CleanupHostileUnits();
    var thunderBluffUnit = AllPreplacedWidgets.Units.Get(UNIT_N03M_THUNDERBLUFF);
    var whichPlayer = player.NeutralAggressive;
    thunderBluffUnit.SetOwner(whichPlayer);
    var echoIslesUnit = AllPreplacedWidgets.Units.Get(UNIT_N02V_ECHO_ISLES);
    var whichPlayer1 = player.NeutralAggressive;
    echoIslesUnit.SetOwner(whichPlayer1);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
    ModAbilityAvailability(ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, 1);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestOrgrimmar(Regions.Orgrimmar));
    AddQuest(new QuestCrossroads(Regions.Crossroads));
    AddQuest(new QuestRokhan(AllPreplacedWidgets.Units.Get(UNIT_MD25_DARKSPEAR_CHAMPION_WARSONG)));
    AddQuest(new QuestWarsongHold());
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quel.Sunwell, Artifacts.SunwellVial));
    // AddQuest(new QuestSubdueOgres(Regions.StonemaulKeep, AllLegends.Warsong, AllLegends.Warsong.GromHellscream)); // Disabled: overlaps Tauren Tribes' Long March rescue at Stonemaul Keep, Warsong is being removed
    AddQuest(new QuestSubdueTrolls(Regions.EchoUnlock, AllLegends.Warsong, AllLegends.Warsong.GromHellscream));
    // AddQuest(new QuestSubdueTauren(Regions.ThunderBluff, AllLegends.Warsong, AllLegends.Warsong.GromHellscream)); // Disabled: overlaps Tauren Tribes' Long March rescue at Thunder Bluff, Warsong is being removed
  }

  private static void ReplaceWithFactionUnits(Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.ThunderBluff, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.EchoUnlock, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Orgrimmar, pickedFaction);
    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Crossroads, pickedFaction);
  }


  public override void OnNotPicked()
  {
    Regions.StonemaulKeep.CleanupNeutralPassiveUnits();
    base.OnNotPicked();
  }
  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
        "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
        "Grom Hellscream"), new[]
      {
        this
      }, new List<Objective>
      {
        new ObjectiveControlLegend(AllLegends.Warsong.GromHellscream, false)
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        },
        new ObjectiveControlCapital(AllLegends.Neutral.FountainOfBlood, false)
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        }
      }
    ));
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\OrcCampaign\Orc08\O08Grom33",
            "Thrall... I see clearly now.  I'm... sorry.  I am so sorry..",
            "Grom Hellscream"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveControlLegend(AllLegends.Warsong.GromHellscream, false)
          {
            EligibleFactions = new List<Faction>{this}
          }
        }));
  }

  private void RegisterFlightPath()
  {

    ResearchManager.Register(new FlightPath(
      this,
      UPGRADE_R09N_FLIGHT_PATH_WARSONG,
      70));
  }
}
