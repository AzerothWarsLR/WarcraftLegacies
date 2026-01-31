using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Researches;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests.Quelthalas;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Quelthalas : Faction
{
  /// <inheritdoc />
  public Quelthalas() : base("Quel'thalas",
    playercolor.Cyan, @"ReplaceableTextures\CommandButtons\BTNSylvanusWindrunner.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    UndefeatedResearch = UPGRADE_R05U_QUEL_THALAS_EXISTS;
    StartingGold = 200;
    CinematicMusic = "BloodElfTheme";
    ControlPointDefenderUnitTypeId = UNIT_N0BC_CONTROL_POINT_DEFENDER_QUELTHALAS;
    IntroText = $"You are playing as the proud {PrefixCol}Kingdom of Quel'Thalas|r.\n\n" +
                "You begin in Tranquillien, separated from Silvermoon. The Trolls of Zul'Aman have laid siege to the city and are preparing attacks on your base.\n\n" +
                "Train soldiers to repel the attacks, then gather enough strength to besiege Zul'Aman and take the head of Zul'jin.\n\n" +
                "The Plague of Undeath is imminent, and Lordaeron will soon need your help against the Scourge. Be ready to join them once you have secured Silvermoon and dealt with the Amani invasion.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), 17716, 13000)
    };
    Nicknames = new List<string>
    {
      "qt",
      "quel",
      "quelthalas"
    };

    RegisterFactionDependentInitializer<Scourge>(RegisterScourgeDialogue);
    ProcessObjectInfo(QuelthalasObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    RegisterResearches();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    RegisterPowers();
  }
  private void RegisterPowers()
  {
    var fontsOfPower = new List<Capital>
    {
      AllLegends.Quelthalas.Sunwell,
      AllLegends.FelHorde.BlackTemple,
      AllLegends.Druids.Nordrassil,
      AllLegends.Sunfury.WellOfEternity,
    };

    AddPower(new FontOfPower(fontsOfPower)
    {
      IconName = "FountainOfLife",
      Name = "Font of Power",
      ResearchId = UPGRADE_ZBFO_FONT_OF_POWER_IS_ACTIVE_POWER,
      ManaRefundPercentage = 0.15f,
      BonusDamagePercentage = 0.1f
    });
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
    ModAbilityAvailability(ABILITY_A0OC_EXTRACT_VIAL_ALL, -1);
  }

  private void RegisterQuests()
  {
    var newQuest = AddQuest(new QuestSilvermoon(Regions.SunwellAmbient,
      PreplacedWidgets.Units.GetClosest(UNIT_H00D_ELVEN_RUNESTONE_QUELTHALAS_OTHER, 20477, 17447), AllLegends.Quelthalas.Silvermoon, AllLegends.Quelthalas.Sunwell));
    StartingQuest = newQuest;
    AddQuest(new QuestUnlockSpire(Regions.WindrunnerSpireUnlock, AllLegends.Quelthalas.Sylvanas));
    AddQuest(new QuestTheBloodElves(AllLegends.Neutral.DraktharonKeep));
    AddQuest(new QuestQueldanil(Regions.QuelDanil_Lodge));
    AddQuest(new QuestQueensArchive(AllLegends.Quelthalas.Rommath));
    AddQuest(new QuestForgottenKnowledge());
  }

  private static void RegisterResearches()
  {
    ResearchManager.Register(new SunfuryWarrior(UPGRADE_R004_SUNFURY_TRAINING_QUEL_THALAS, 300));
  }

  private void RegisterScourgeDialogue(Scourge scourge)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
          @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas30",
          "Are you still upset that I stole Jaina from you, Kael?",
          "Illidan Stormrage"), new Dialogue(
          @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Kael31",
          "You've taken everything I ever cared for, Arthas. Vengeance is all I have left.",
          "Kael'thas Sunstrider"))
        , new Faction[]
        {
          this,
          scourge
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Scourge.Arthas, AllLegends.Sunfury.Kael)
        }));
  }
}
