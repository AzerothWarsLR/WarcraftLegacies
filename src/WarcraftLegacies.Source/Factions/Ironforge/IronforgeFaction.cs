using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Ironforge.Paths;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;
using WarcraftLegacies.Source.Factions.Ironforge.Researches;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;
namespace WarcraftLegacies.Source.Factions.Ironforge;

public sealed class IronforgeFaction : Faction, IHasRoleplayPaths, IHasRoleplayIntro
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
    IntroText = () => Loc.Format(
      "You are playing as the long-enduring {faction}.\n\nYou begin in the Wetlands, separated from the rest of your forces. Conquer Loch Modan and Dun Morogh to regain access to your territories.\n\nStormwind is preparing for an invasion through the Dark Portal in the South. Muster your forces and aid them, or risk losing your strongest ally.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Kingdom of Ironforge")}|r"));
    Nicknames = new List<string>
    {
      "if",
      "iron",
      "dwarf",
      "dwarfs",
      "dwarves"
    };
    RegisterFactionDependentInitializer<StormwindFaction>(RegisterStormwindResearches);
    ProcessObjectInfo(IronforgeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public void AddRoleplayPaths()
  {
    if (GetAllPaths().Any(x => x is PathDarkIron))
    {
      return;
    }

    var transformation = new DarkIronTransformation();
    AddPath(new PathDarkIronLegion(transformation));
    AddPath(new PathDarkIronAlone(transformation));
    AddPath(new PathWildhammer(new WildhammerTransformation()));
    LinkMagniToTheGreatForge();
  }

  /// <summary>Magni dies with the Great Forge, and can no longer be trained.</summary>
  private void LinkMagniToTheGreatForge()
  {
    var deathTrigger = trigger.Create();
    deathTrigger.RegisterUnitEvent(AllLegends.Ironforge.GreatForge.Unit, unitevent.Death);
    deathTrigger.AddAction(() =>
    {
      var magni = AllLegends.Ironforge.Magni;
      ModObjectLimit(magni.UnitType, -GetObjectLimit(magni.UnitType));
      if (magni.Unit != null)
      {
        magni.PermanentlyKill();
      }
    });
  }

  /// <inheritdoc />
  public string RoleplayIntroText => Loc.Format(
    "You are playing as the long-enduring {faction}.\n\nDeep within Khaz Modan, the forges of Ironforge burn brighter than ever, and the Bronzebeards are as stubborn as the mountain itself.\n\nThe Fel Horde is gathering beyond the Dark Portal. Muster your forces and aid Stormwind and Kul Tiras, your allies of the South Alliance, or risk losing them.\n\nYet the dwarves are a fractured people. The Dark Iron stir beneath Blackrock Mountain, and the Wildhammer keep their own counsel at Aerie Peak. Should the Great Forge ever go cold, one of them may claim what is left of the dwarves.",
    ("{faction}", $"{PrefixCol}{Loc.Get("Kingdom of Ironforge")}|r"));

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
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

    var questBlackTemple = new QuestBlackTemple(AllLegends.FelHorde.BlackTemple);
    questBlackTemple.AddObjective(new ObjectiveQuestComplete(questDominion)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questBlackTemple);

    var questWildhammer = new QuestWildhammer()
    {
      Progress = QuestProgress.Undiscovered
    };

    questWildhammer.AddObjective(new ObjectiveQuestComplete(questDominion)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questWildhammer);

    var questDarkIron = new QuestDarkIron(
      Regions.Shadowforge_City,
      Regions.Shadowforge_City_Base,
      AllLegends.FelHorde.BlackrockSpire);

    questDarkIron.AddObjective(new ObjectiveQuestComplete(questDominion)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddQuest(questDarkIron);

    var explorersLeagueOne = new QuestExplorersLeagueFoundation();
    explorersLeagueOne.AddObjective(new ObjectiveQuestComplete(questDominion)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });

    AddQuest(explorersLeagueOne);

    var explorersLeagueTwo = new QuestExplorersLeagueKalimdorExpedition();
    explorersLeagueTwo.AddObjective(new ObjectiveQuestComplete(explorersLeagueOne)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });

    AddQuest(explorersLeagueTwo);

    var missingArtifacts = new int[]
    {
      ITEM_I01A_DEMON_SOUL,
      ITEM_I00F_GLOVES_OF_AHN_QIRAJ,
      ITEM_I00Z_THUNDERFURY,
      ITEM_I01T_FANDRAL_S_FLAMESCYTHE
    };

    var questExpedition = new QuestExpedition(
      missingArtifacts[GetRandomInt(0, missingArtifacts.Length - 1)]);

    questExpedition.AddObjective(new ObjectiveQuestComplete(explorersLeagueOne)
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

  private static void RegisterResearches()
  {
    var flamethrower = new Flamethrower(UPGRADE_TP28_FLAMETHROWER_IRONFORGE, 0, 5);
    var artillery = new Artillery(UPGRADE_TP29_ARTILLERY_IRONFORGE, 0, 5);

    ResearchManager.RegisterIncompatibleSet(flamethrower, artillery);
  }
}


