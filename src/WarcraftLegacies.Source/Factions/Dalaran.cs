using System;
using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionChoices;
using MacroTools.FactionSystem;
using MacroTools.Libraries;
using MacroTools.Mechanics;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.Systems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Dalaran;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions;

public sealed class Dalaran : Faction
{
  private readonly ArtifactSetup _artifactSetup;
  private readonly AllLegendSetup _allLegendSetup;
  private readonly List<unit> _dalaranProtectors;

  /// <inheritdoc />
  public Dalaran(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    : base("Dalaran", playercolor.Pink, @"ReplaceableTextures\CommandButtons\BTNJaina.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    _artifactSetup = artifactSetup;
    _allLegendSetup = allLegendSetup;
    _dalaranProtectors = new List<unit>
    {
      preplacedUnitSystem.GetUnit(UNIT_N03G_VIOLET_TOWER_DALARAN, new Point(9084, 4979)),
      preplacedUnitSystem.GetUnit(UNIT_N03G_VIOLET_TOWER_DALARAN, new Point(9008, 4092)),
      preplacedUnitSystem.GetUnit(UNIT_N03G_VIOLET_TOWER_DALARAN, new Point(9864, 4086))
    };
    UndefeatedResearch = UPGRADE_R05N_DALARAN_EXISTS;
    StartingGold = 200;
    CinematicMusic = "SadMystery";
    ControlPointDefenderUnitTypeId = UNIT_N00N_CONTROL_POINT_DEFENDER_DALARAN;
    IntroText = $"You are playing the wise {PrefixCol}Council of Dalaran|r.\n\n" +
                "You begin in the Hillsbrad Foothills, separated from the main forces of Dalaran. To unlock Dalaran, you must capture Shadowfang Keep, which has been encircled by monsters.\n\n" +
                "Once your territory is secured, you will need to prepare for the Plague of Undeath and the invasion of the Burning Legion. Lordaeron will surely need your help.\n\n" +
                "Your mages are the finest in Azeroth. Be sure to utilize them alongside your heroes to turn the tide of battle.";

    GoldMines = new List<unit>
    {
      preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(5466, 3210)),
    };
    Nicknames = new List<string>
    {
      "dala"
    };

    RegisterFactionDependentInitializer<Scourge>(RegisterScourgeDialogue);
    RegisterFactionDependentInitializer<Legion>(RegisterBookOfMedivhQuest);
    ProcessObjectInfo(DalaranObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    ReplaceWithFactionUnits(this);
    RegisterQuests();
    RegisterDialogue();
    RegisterProtectors();
    WaygateManager.Setup(UNIT_N0AO_WAY_GATE_DALARAN_SIEGE);
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
  private void ReplaceWithFactionUnits(Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    FactionChoiceDialogPresenter.ReplaceRegionUnitsWithFactionEquivalents(Regions.Gilneas, pickedFaction);
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, 1);
    ModAbilityAvailability(ABILITY_A0GG_SPELL_SHIELD_SPELL_BOOK_ORANGE_KIRIN_TOR, -1); //Todo: should be global
    ModAbilityAvailability(ABILITY_A0WG_SPELL_SHIELD_SPELL_BOOK_ORANGE_ANTONIDAS_RED_LICH_KING, -1);
    ModAbilityAvailability(ABILITY_A0UG_PHASE_BLADE_AUTO_CAST_ORANGE_BARRACKS_OFF, -1); //Todo: should have a system for this
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
    ModAbilityAvailability(ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestShadowfang(Regions.ShadowfangUnlock));
    AddQuest(new QuestSouthshore(Regions.SouthshoreUnlock));
    AddQuest(new QuestDalaran(Regions.Dalaran));
    AddQuest(new QuestGilneas(Regions.Gilneas));

    QuestNewGuardian newGuardian = new(_artifactSetup.BookOfMedivh, _allLegendSetup.Dalaran.Jaina,
      _allLegendSetup.Dalaran.Dalaran);
    QuestAegwynn aegwynn = new(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Dalaran.Antonidas);
    QuestTheNexus theNexus = new(_allLegendSetup.Scourge.TheFrozenThrone, _allLegendSetup.Dalaran, _allLegendSetup.Neutral.TheNexus);
    QuestCrystalGolem crystalGolem = new(_allLegendSetup.Neutral.DraktharonKeep);
    QuestFallenGuardian fallenGuardian = new(_allLegendSetup.Neutral.Karazhan);

    newGuardian.AddObjective(new ObjectiveQuestNotComplete(theNexus));
    crystalGolem.AddObjective(new ObjectiveQuestNotComplete(theNexus));
    aegwynn.AddObjective(new ObjectiveQuestNotComplete(theNexus));

    theNexus.AddObjective(new ObjectiveQuestNotComplete(newGuardian));

    AddQuest(new QuestJainaSoulGem(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Neutral.Caerdarrow));
    AddQuest(new QuestBlueDragons(_allLegendSetup.Neutral.TheNexus));
    AddQuest(new QuestKarazhan(_allLegendSetup.Neutral.Karazhan));
    AddQuest(new QuestTheramore(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Dalaran.Dalaran, Regions.Theramore));

    AddQuest(crystalGolem);
    AddQuest(fallenGuardian);
    AddQuest(aegwynn);
    AddQuest(newGuardian);
    AddQuest(theNexus);
  }

  private void RegisterBookOfMedivhQuest(Legion legion)
  {
    SharedQuestRepository.RegisterQuestFactory(faction => new QuestBookOfMedivh(_allLegendSetup.Dalaran.Dalaran,
      new NamedRectangle("Dalaran", Regions.BookOfMedivhDalaran), _artifactSetup.BookOfMedivh,
      faction == legion, faction == this));
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf06Interlude\N06Medivh42",
          "Now, at long last, I have returned to set things right. I... am Medivh, the Last Guardian. I tell you now, the only chance for this world is for you to unite in arms against the enemies of all who live!",
          "Medivh"))
        , new[]
        {
          this
        }, new[]
        {
          new ObjectiveControlLegend(_allLegendSetup.Dalaran.Medivh, false)
          {
            EligibleFactions = new List<Faction>
            {
              this
            }
          }
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
        soundFile: @"Sound\Dialogue\HumanCampaign\Human05\H05Jaina01.flac",
        caption:
        "Hearthglen, finally! I could use some rest!",
        speaker: "Jaina Proudmoore"), new[]
      {
        this
      }, new[]
      {
        new ObjectiveLegendInRect(_allLegendSetup.Dalaran.Jaina, Regions.Hearthglen, "Hearthglen")
      }));
  }

  private void RegisterScourgeDialogue(Scourge scourge)
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas13.flac",
          "It pains me to even look at you, Arthas.",
          "Arthas Menethil"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas14.flac",
          "I'll be happy to end your torment, old man. I told you that your magics could not stop me.",
          "Antonidas")
      ), new Faction[]
      {
        scourge,
        this
      }, new List<Objective>
      {
        new ObjectiveLegendDead(_allLegendSetup.Dalaran.Antonidas)
        {
          DeathFilter = dyingLegend => MathEx.GetDistanceBetweenPoints(_allLegendSetup.Scourge.Arthas.Unit.GetPosition(),
            dyingLegend.Unit.GetPosition()) < 500
        }
      }
    ));
  }

  private void RegisterProtectors()
  {
    foreach (var unit in _dalaranProtectors)
    {
      _allLegendSetup.Dalaran.Dalaran.AddProtector(unit);
    }
  }
}
