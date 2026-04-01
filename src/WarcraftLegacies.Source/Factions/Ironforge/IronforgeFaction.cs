using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Ironforge.Researches;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Ironforge;

public sealed class IronforgeFaction : Faction
{
  /// <inheritdoc />
  public IronforgeFaction()
    : base("Ironforge", playercolor.Yellow, @"ReplaceableTextures\CommandButtons\BTNHeroMountainKing.blp")
  {
    TraditionalTeam = TeamSetup.SouthAlliance;
    UndefeatedResearch = UPGRADE_R05T_IRONFORGE_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 140,
      Turns = 10
    };
    CinematicMusic = "PursuitTheme";
    ControlPointDefenderUnitTypeId = UNIT_H0AL_CONTROL_POINT_DEFENDER_IRONFORGE;
    IntroText = $"You are playing as the long-enduring {PrefixCol}Kingdom of Ironforge |r.\n\n" +
                "You begin in the Wetlands, separated from the rest of your forces. Conquer Loch Modan and Dun Morogh to regain access to your territories.\n\n" +
                "Stormwind is preparing for an invasion through the Dark Portal in the South. Muster your forces and aid them, or risk losing your strongest ally.";
    Nicknames = new List<string>
    {
      "if",
      "dwarf",
      "dwarfs",
      "dwarves"
    };
    RegisterFactionDependentInitializer<StormwindFaction>(RegisterStormwindResearches);
    ProcessObjectInfo(IronforgeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    IronforgeSpells.Setup();
    IronforgeTraits.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
    ModAbilityAvailability(ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
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

    questWildhammer.AddObjective(new ObjectiveControlLegend(AllLegends.Ironforge.Magni, false)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });

    AddQuest(questWildhammer);


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

    questExpedition.AddObjective(new ObjectiveTurn(15)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questExpedition);

    AddQuest(new QuestExtractSunwellVial(
      AllLegends.Quel.Sunwell,
      Artifacts.SunwellVial));
  }


  private void RegisterStormwindResearches(StormwindFaction stormwind)
  {
    ResearchManager.Register(new DeeprunTram(this, stormwind, UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 70));
  }
}
