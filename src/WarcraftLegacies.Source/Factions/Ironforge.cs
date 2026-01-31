using System.Collections.Generic;
using MacroTools.FactionSystem;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Ironforge;
using WarcraftLegacies.Source.Researches.Ironforge;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Ironforge : Faction
{
  /// <inheritdoc />
  public Ironforge()
    : base("Ironforge", playercolor.Yellow, @"ReplaceableTextures\CommandButtons\BTNHeroMountainKing.blp")
  {
    TraditionalTeam = TeamSetup.SouthAlliance;
    UndefeatedResearch = UPGRADE_R05T_IRONFORGE_EXISTS;
    StartingGold = 200;
    CinematicMusic = "PursuitTheme";
    ControlPointDefenderUnitTypeId = UNIT_H0AL_CONTROL_POINT_DEFENDER_IRONFORGE;
    IntroText = $"You are playing as the long-enduring {PrefixCol}Kingdom of Ironforge |r.\n\n" +
                "You begin in the Wetlands, separated from the rest of your forces. Conquer Loch Modan and Dun Morogh to regain access to your territories.\n\n" +
                "Stormwind is preparing for an invasion through the Dark Portal in the South. Muster your forces and aid them, or risk losing your strongest ally.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), 12079, -2768)
    };
    Nicknames = new List<string>
    {
      "if",
      "dwarf",
      "dwarfs",
      "dwarves"
    };
    RegisterFactionDependentInitializer<Stormwind>(RegisterStormwindResearches);
    ProcessObjectInfo(IronforgeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
    ModAbilityAvailability(ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
    ModAbilityAvailability(ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
  }

  private void RegisterQuests()
  {
    var questThelsamar = new QuestThelsamar(Regions.ThelUnlock);
    StartingQuest = questThelsamar;
    AddQuest(questThelsamar);

    var questDunMorogh = new QuestDunMorogh();
    questDunMorogh.AddObjective(new ObjectiveQuestComplete(questThelsamar)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questDunMorogh);

    var questDominion = new QuestDominion(Regions.IronforgeAmbient, questThelsamar, questDunMorogh);
    questDominion.AddObjective(new ObjectiveQuestComplete(questThelsamar)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questDominion);

    var questGnomeregan = new QuestGnomeregan(Regions.Gnomergan);
    questGnomeregan.AddObjective(new ObjectiveQuestComplete(questDunMorogh)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questGnomeregan);

    var questWildhammer = new QuestWildhammer(AllLegends.Ironforge.Magni)
    {
      Progress = QuestProgress.Undiscovered
    };
    AddQuest(questWildhammer);

    questWildhammer.AddObjective(new ObjectiveControlLegend(AllLegends.Ironforge.Magni, false)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });

    var questDarkIron = new QuestDarkIron(
      Regions.Shadowforge_City,
      AllLegends.FelHorde.BlackTemple,
      AllLegends.Ironforge.Magni);

    questDarkIron.AddObjective(new ObjectiveQuestComplete(questDominion)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questDarkIron);

    var missingArtifacts = new int[]
    {
      ITEM_I01A_DEMON_SOUL,
      ITEM_I00F_GLOVES_OF_AHN_QIRAJ,
      ITEM_I00Z_THUNDERFURY,
      ITEM_I01T_FANDRAL_S_FLAMESCYTHE
    };

    var questExpedition = new QuestExpedition(
      missingArtifacts[GetRandomInt(0, missingArtifacts.Length - 1)]);

    questExpedition.AddObjective(new ObjectiveTime(15 * 60)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questExpedition);

    AddQuest(new QuestExtractSunwellVial(
      AllLegends.Quelthalas.Sunwell,
      Artifacts.SunwellVial));
  }


  private void RegisterStormwindResearches(Stormwind stormwind)
  {
    ResearchManager.Register(new DeeprunTram(this, stormwind, UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 70));
  }
}
