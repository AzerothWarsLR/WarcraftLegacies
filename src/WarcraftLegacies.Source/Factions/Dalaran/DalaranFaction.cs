using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Factions.Choices;
using MacroTools.Localization;
using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Dalaran.Mechanics;
using WarcraftLegacies.Source.Factions.Dalaran.Paths;
using WarcraftLegacies.Source.Factions.Dalaran.Quests;
using WarcraftLegacies.Source.Factions.Legion;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Quests;

namespace WarcraftLegacies.Source.Factions.Dalaran;

public sealed class DalaranFaction : Faction, IHasRoleplayPaths, IHasRoleplayIntro
{
  private readonly List<unit> _dalaranProtectors;

  /// <inheritdoc />
  public DalaranFaction()
    : base("Dalaran", playercolor.Pink, @"ReplaceableTextures\CommandButtons\BTNJaina.blp")
  {
    TraditionalTeam = TeamSetup.NorthAlliance;
    _dalaranProtectors = new List<unit>
    {
      AllPreplacedWidgets.Units.GetClosest(UNIT_N03G_VIOLET_TOWER_DALARAN, 9084, 4979),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N03G_VIOLET_TOWER_DALARAN, 9008, 4092),
      AllPreplacedWidgets.Units.GetClosest(UNIT_N03G_VIOLET_TOWER_DALARAN, 9864, 4086)
    };
    UndefeatedResearch = UPGRADE_R05N_DALARAN_EXISTS;
    StartingGold = new StartingGold
    {
      Instant = 200,
      Income = 110,
      Turns = 10
    };
    CinematicMusic = "SadMystery";
    ControlPointDefenderUnitTypeId = UNIT_N00N_CONTROL_POINT_DEFENDER_DALARAN;
    IntroText = () => Loc.Format(
      "You are playing the wise {faction}.\n\nYou begin in the Hillsbrad Foothills, separated from the main forces of Dalaran. To unlock Dalaran, you must capture Shadowfang Keep, which has been encircled by monsters.\n\nOnce your territory is secured, you will need to prepare for the Plague of Undeath and the invasion of the Burning Legion. Lordaeron will surely need your help.\n\nYour mages are the finest in Azeroth. Be sure to utilize them alongside your heroes to turn the tide of battle.",
      ("{faction}", $"{PrefixCol}{Loc.Get("Council of Dalaran")}|r"));

    Nicknames = new List<string>
    {
      "dala"
    };

    RegisterFactionDependentInitializer<LegionFaction>(RegisterBookOfMedivhQuest);
    ProcessObjectInfo(DalaranObjectInfo.GetAllObjectLimits());
  }

  /// <summary>The quest that moves Dalaran to Theramore, which Roleplay mode replaces with a path.</summary>
  public QuestTheramore? TheramoreQuest { get; private set; }

  /// <inheritdoc />
  public void AddRoleplayPaths()
  {
    if (!GetAllPaths().Any(x => x is PathTheramore))
    {
      AddPath(new PathTheramore(new TheramoreTransformation(), AllLegends.Dalaran.Dalaran));
    }

    if (!GetAllPaths().Any(x => x is PathGilneas))
    {
      var gilneasTransformation = new GilneasTransformation();
      AddPath(new PathGilneasNightElves(gilneasTransformation));
      AddPath(new PathGilneasGreymaneWall(gilneasTransformation));
    }
  }

  /// <inheritdoc />
  public string RoleplayIntroText => Loc.Format(
    "You are playing as the wise {faction}.\n\nThe magi of the Violet Citadel have long watched over the north, and of late their divinations have grown dark. A plague stirs in Lordaeron, and something far older stirs behind it.\n\nThe Plague of Undeath and the invasion of the Burning Legion are coming. Stand with Lordaeron and Quel'Thalas, your allies of the North Alliance, and guard the Book of Medivh, for the Legion will come for it. In time, Stormwind, Ironforge and Kul Tiras of the South Alliance may march north to aid you.\n\nShould the north be lost, Jaina may lead your people west across the sea, and Gilneas waits behind its great wall.\n\nYour mages are the finest in Azeroth. Be sure to utilize them alongside your heroes to turn the tide of battle.",
    ("{faction}", $"{PrefixCol}{Loc.Get("Council of Dalaran")}|r"));

  /// <inheritdoc />
  public override void OnRegistered()
  {
    AllLegends.Dalaran.Dalaran.ChangedOwner += _ => OnVioletCitadelChangedOwner();
    RegisterObjectLevels();
    ReplaceWithFactionUnits(this);
    RegisterQuests();
    RegisterDialogue();
    RegisterProtectors();
    DalaranSpells.Setup();
    WaygateManager.Setup(UNIT_N0AO_WAY_GATE_DALARAN_SIEGE, ABILITY_CK02_WAY_GATE_TRAVEL_DALARAN);
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
  private static void ReplaceWithFactionUnits(Faction pickedFaction)
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
    ModAbilityAvailability(ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
    ModAbilityAvailability(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
  }

  private void RegisterQuests()
  {
    StartingQuest = AddQuest(new QuestShadowfang(Regions.ShadowfangUnlock));
    AddQuest(new QuestSouthshore(Regions.SouthshoreUnlock));
    AddQuest(new QuestDalaran(Regions.Dalaran));
    AddQuest(new QuestGilneas(Regions.Gilneas));

    QuestNewGuardian newGuardian = new(Artifacts.BookOfMedivh, AllLegends.Dalaran.Jaina,
      AllLegends.Dalaran.Dalaran);
    QuestAegwynn aegwynn = new(AllLegends.Dalaran.Jaina, AllLegends.Dalaran.Antonidas);
    QuestCrystalGolem crystalGolem = new(AllLegends.Neutral.DraktharonKeep);
    QuestFallenGuardian fallenGuardian = new(AllLegends.Neutral.Karazhan);

    AddQuest(new QuestJainaSoulGem(AllLegends.Dalaran.Jaina, AllLegends.Neutral.Caerdarrow));
    AddQuest(new QuestBlueDragons(AllLegends.Neutral.TheNexus));
    AddQuest(new QuestKarazhan(AllLegends.Neutral.Karazhan));
    TheramoreQuest = new QuestTheramore(AllLegends.Dalaran.Jaina, AllLegends.Dalaran.Dalaran, Regions.Theramore);
    if (!RoleplaySetting.IsActive)
    {
      AddQuest(TheramoreQuest);
    }

    AddQuest(crystalGolem);
    AddQuest(fallenGuardian);
    AddQuest(aegwynn);
    AddQuest(newGuardian);
  }

  /// <summary>Whoever takes over the Violet Citadel becomes the keeper of the Book of Medivh.</summary>
  private void OnVioletCitadelChangedOwner()
  {
    var citadel = AllLegends.Dalaran.Dalaran.Unit;
    if (citadel == null || !citadel.Alive || citadel.Owner.GetPlayerData().Faction == this)
    {
      return;
    }

    DalaranHomeland.MakeBookKeeper(citadel.Owner);
  }

  private void RegisterBookOfMedivhQuest(LegionFaction legion)
  {
    SharedQuestRepository.RegisterQuestFactory(faction => new QuestBookOfMedivh(AllLegends.Dalaran.Dalaran,
      new NamedRectangle("Dalaran", Regions.BookOfMedivhDalaran), Artifacts.BookOfMedivh,
      faction != this, faction == this, faction == legion));
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
          new ObjectiveControlLegend(AllLegends.Dalaran.Medivh, false)
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
        new ObjectiveLegendInRect(AllLegends.Dalaran.Jaina, Regions.Hearthglen, "Hearthglen")
      }));
  }

  private void RegisterProtectors()
  {
    foreach (var unit in _dalaranProtectors)
    {
      AllLegends.Dalaran.Dalaran.AddProtector(unit);
    }
  }
}
