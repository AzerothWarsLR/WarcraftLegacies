using System;
using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionChoices;
using MacroTools.Factions;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.FactionMechanics.Warsong;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Warsong;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;


namespace WarcraftLegacies.Source.Factions;

public sealed class Warsong : Faction
{
  /// <inheritdoc />
  public Warsong() : base("Warsong", playercolor.Red,
    @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    UndefeatedResearch = UPGRADE_R05W_WARSONG_EXISTS;
    StartingGold = 200;
    CinematicMusic = "DarkAgents";
    ControlPointDefenderUnitTypeId = UNIT_N0D6_CONTROL_POINT_DEFENDER_WARSONG;
    IntroText = $"You are playing as the fierce and relentless {PrefixCol}Warsong Clan|r.\n\n" +
                "Begin swiftly by rescuing your Chieftain, Grom Hellscream, who is trapped in battle and consumed by demonic fury. His survival is paramount.\n\n" +
                "With Grom secured, expand your dominance by subduing or pillaging nearby races to bolster your clan's strength.\n\n" +
                "Work closely with your new elven allies—only together can you overcome the looming threat of the Old Gods.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -9729, 2426),
    };
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
    BloodPactBattleSimulation.StartSimulation();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    Regions.BarrenAmbient2.CleanupHostileUnits();
    Regions.AshenvaleCreeps.CleanupHostileUnits();
    var thunderBluffUnit = PreplacedWidgets.Units.Get(UNIT_N03M_THUNDERBLUFF);
    var whichPlayer = player.NeutralAggressive;
    thunderBluffUnit.SetOwner(whichPlayer);
    var echoIslesUnit = PreplacedWidgets.Units.Get(UNIT_N02V_ECHO_ISLES);
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
    StartingQuest = AddQuest(new QuestGrom(AllLegends.Warsong.GromHellscream, AllLegends.Warsong.Gargok));
    AddQuest(new QuestOrgrimmar(Regions.Orgrimmar));
    AddQuest(new QuestCrossroads(Regions.Crossroads));
    AddQuest(new QuestRokhan(PreplacedWidgets.Units.Get(UNIT_MD25_DARKSPEAR_CHAMPION_WARSONG)));
    // AddQuest(new QuestFountainOfBlood(AllLegendSetup.Neutral.FountainOfBlood, AllLegendSetup.Warsong.GromHellscream));
    // AddQuest(new QuestBloodpact(AllLegendSetup.Warsong.Mannoroth, AllLegendSetup.Warsong.GromHellscream));
    AddQuest(new QuestGarrosh(AllLegends.BlackEmpire.Nzoth));
    AddQuest(new QuestWarsongKillCthun(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestKillOldGods(AllLegends.Ahnqiraj.Cthun, AllLegends.BlackEmpire.Nzoth));
    AddQuest(new QuestWarsongHold());
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
    AddQuest(new QuestSubdueOgres(Regions.StonemaulKeep, AllLegends.Warsong, AllLegends.Warsong.GromHellscream));
    AddQuest(new QuestSubdueTrolls(Regions.EchoUnlock, AllLegends.Warsong, AllLegends.Warsong.GromHellscream));
    AddQuest(new QuestSubdueTauren(Regions.ThunderBluff, AllLegends.Warsong, AllLegends.Warsong.GromHellscream));


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
