using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.ResearchSystems;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.FactionMechanics.Scourge.Blight;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions;

public sealed class Scourge : Faction
{
  /// <inheritdoc />
  public Scourge()
    : base("Scourge", playercolor.Purple, @"ReplaceableTextures\CommandButtons\BTNRevenant.blp")
  {
    TraditionalTeam = TeamSetup.Legion;
    UndefeatedResearch = UPGRADE_R05K_SCOURGE_EXISTS;
    StartingGold = 200;
    FoodMaximum = 250;
    CinematicMusic = "ArthasTheme";
    ControlPointDefenderUnitTypeId = UNIT_U028_CONTROL_POINT_DEFENDER_SCOURGE;
    IntroText = $"You are playing as the horrific {PrefixCol}Undead Scourge|r.\n\n" +
                "You begin in Northrend, a vast and isolated land—perfect for raising an army of undying warriors to annihilate the living.\n\n" +
                "The local Nerubians have declared war on you. Destroy their decrepit holdings and slay their Queen to secure the continent.\n\n" +
                "Coordinate with the Burning Legion and unleash the Plague of Undeath to sweep Lordaeron away.\n\n" +
                "When the Plague strikes Lordaeron, you will have a choice of where to instantly transport all your military units.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -4939, 18803)
    };
    Nicknames = new List<string>
    {
      "ud",
      "undead"
    };
    RegisterFactionDependentInitializer<Quelthalas>(RegisterQuelthalasRelatedQuests);
    RegisterFactionDependentInitializer<Lordaeron>(RegisterLordaeronRelatedQuests);
    RegisterFactionDependentInitializer<Lordaeron, Legion>(RegisterLordaeronLegionRelatedQuests);
    RegisterFactionDependentInitializer<Dalaran>(RegisterDalaranDialogue);
    RegisterFactionDependentInitializer<Quelthalas>(RegisterQuelthalasDialogue);
    RegisterFactionDependentInitializer<Lordaeron>(RegisterLordaeronDialogue);
    RegisterFactionDependentInitializer<Legion>(RegisterLegionDialogue);

    ProcessObjectInfo(ScourgeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterObjectLevels();
    RegisterQuests();
    RegisterPowers();
    RegisterDialogue();
    RegisterResearches();
    BlightSystem.Setup(this);
    BlightSetup.Setup();
    SacrificeAcolyte.Setup();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    TheFrozenThrone.Setup(this, AllLegends.Scourge.TheFrozenThrone, AllLegends.Scourge.Arthas);
  }

  private void RegisterResearches()
  {
    ResearchManager.RegisterIncompatibleSet(
      new CustomResearch(UPGRADE_ZB74_LICHES_SCOURGE, 0)
      {
        ResearchFunc = researchingPlayer =>
        {
          var faction = researchingPlayer.GetPlayerData().Faction;
          faction?.ModObjectLimit(UNIT_H00H_DEATH_KNIGHT_SCOURGE_ELITE, -Unlimited);
          faction?.ModObjectLimit(UPGRADE_R00Q_CHILLING_AURA_SCOURGE, -Unlimited);
        }
      },
      new ChangeObjectLimitResearch(UPGRADE_ZB24_DEATH_KNIGHTS_SCOURGE, 0)
      {
        ObjectId = UNIT_ZBLI_LICH_SCOURGE_ELITE,
        LimitChange = -Unlimited
      });
  }

  private void RegisterObjectLevels()
  {
    ModAbilityAvailability(ABILITY_A0WG_SPELL_SHIELD_SPELL_BOOK_ORANGE_ANTONIDAS_RED_LICH_KING, -1);
    ModAbilityAvailability(ABILITY_A0K2_RAISE_DEAD_AUTO_CAST_RED_TEMPLE_OF_THE_DAMNED_OFF, -1);
    ModAbilityAvailability(ABILITY_A09N_PERMANENT_IMMOLATION_SCOURGE_ICECROWN_OBELISK, -1);
  }

  private void RegisterQuests()
  {
    QuestSpiderWar questSpiderWar = new(Regions.Ice_Crown);
    QuestEnKilahUnlock questEnKilahUnlock = new(Regions.EnKilahUnlock);
    QuestDrakUnlock questDrakUnlock = new(Regions.DrakUnlock, AllLegends.Scourge.Kelthuzad);

    QuestSapphiron questSapphiron = new(PreplacedWidgets.Units.Get(UNIT_UBDR_SAPPHIRON_CREEP),
      AllLegends.Scourge.Kelthuzad);

    QuestLichKingArthas questLichKingArthas =
      new(PreplacedWidgets.Units.Get(UNIT_H00O_UTGARDE_KEEP_SCOURGE_OTHER),
        Artifacts.HelmOfDomination,
        AllLegends.Scourge.Arthas,
        AllLegends.Scourge.TheFrozenThrone);
    QuestSlumberingKing questSlumberingKing = new();

    AddQuest(questSpiderWar);
    StartingQuest = questSpiderWar;
    AddQuest(questDrakUnlock);
    AddQuest(questEnKilahUnlock);
    AddQuest(questSapphiron);
    //Misc
    AddQuest(questLichKingArthas);
    AddQuest(questSlumberingKing);
  }

  private void RegisterPowers()
  {
    var allSeeing = new RegionVisionPower("All-Seeing",
      "Grants permanent vision over Northrend.",
      "Charm", new[]
      {
        Regions.Storm_Peaks,
        Regions.Central_Northrend,
        Regions.The_Basin,
        Regions.Ice_Crown,
        Regions.Fjord,
        Regions.Eastern_Northrend,
        Regions.Far_Eastern_Northrend,
        Regions.Coldarra,
        Regions.Borean_Tundra,
        Regions.IcecrownShipyard
      });
    AddPower(allSeeing);

    var domination = new Domination
    {
      ResearchId = UPGRADE_R008_DOMINATION_POWER,
      MindlessUndeadUnitTypes = new List<int>
      {
        UNIT_UGHO_GHOUL_SCOURGE,
        UNIT_U012_HALF_GHOUL_SCOURGE,
        UNIT_UABO_ABOMINATION_SCOURGE,
        UNIT_UFRO_FROST_WYRM_SCOURGE,
        UNIT_UCRM_BURROWED_CRYPT_FIEND_SCOURGE,
        UNIT_UCRY_CRYPT_FIEND_SCOURGE
      },
      IconName = "Revenant"
    };

    AddPower(domination);
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
          soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
          caption: "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
          speaker: "Kel'thuzad"),
        null,
        new[]
        {
          new ObjectiveStartSpell(ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false,
            AllLegends.Scourge.Kelthuzad)
        }));
  }

  private void RegisterDalaranDialogue(Dalaran dalaran)
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new DialogueSequence(
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas01.flac",
          "Wizards of the Kirin Tor! I am Arthas, first of the Lich King's death knights! I demand that you open your gates and surrender to the might of the Scourge!",
          "Arthas Menethil"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas02.flac",
          "Greetings, Prince Arthas. How fares your noble father?",
          "Antonidas"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas03.flac",
          "Lord Antonidas. There's no need to be snide.",
          "Arthas Menethil"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas04.flac",
          "We've prepared for your coming, Arthas. My brethren and I have erected auras that will destroy any undead that pass through them.",
          "Antonidas"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Arthas05.flac",
          "Your petty magics will not stop me, Antonidas.",
          "Arthas Menethil"),
        new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead07\U07Antonidas06.flac",
          "Pull your troops back, or we will be forced to unleash our full powers against you! Make your choice, death knight.",
          "Antonidas")
      ), new Faction[]
      {
        this,
        dalaran
      }, new List<Objective>
      {
        new ObjectiveLegendInRect(AllLegends.Dalaran.Antonidas, Regions.Dalaran, "Dalaran"),
        new ObjectiveLegendInRect(AllLegends.Scourge.Arthas, Regions.Dalaran, "Dalaran")
      }
    ));
  }

  private void RegisterLordaeronDialogue(Lordaeron lordaeron)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
        soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
        caption:
        "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
        speaker: "Kel'thuzad"), new Faction[]
      {
        this,
        lordaeron,
      }, new[]
      {
        new ObjectiveLegendDead(AllLegends.Scourge.Kelthuzad)
      }));
  }

  private void RegisterQuelthalasDialogue(Quelthalas quelthalas)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas01.flac",
            caption: "Ah, wondrous, eternal Quel'Thalas. I haven't been here since I was a boy.",
            speaker: "Arthas Menethil"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AKelThuzad02.flac",
            caption: "Be wary. The elves likely wait in ambush.",
            speaker: "Kel'thuzad"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas03.flac",
            caption:
            "The frail elves do not concern me, necromancer. Our forces are strengthened with every foe we slay.",
            speaker: "Arthas Menethil"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AKelthuzad04.flac",
            caption: "Don't be too overconfident, death knight. The elves must not be taken lightly.",
            speaker: "Kel'thuzad")),
        new Faction[]
        {
          this,
          quelthalas
        },
        new Objective[]
        {
          new ObjectiveLegendInRect(AllLegends.Scourge.Arthas, Regions.QuelthalasAmbient, "Quel'thalas"),
          new ObjectiveLegendInRect(AllLegends.Scourge.Kelthuzad, Regions.QuelthalasAmbient, "Quel'thalas"),
          new ObjectiveQuestComplete(GetQuestByType<QuestKelthuzadDies>())
          {
            EligibleFactions = new List<Faction> { this }
          },
          new ObjectiveQuestNotComplete(GetQuestByType<QuestKelthuzadLich>())
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03ASylvanas12.flac",
            caption:
            "You are not welcome here. I am Sylvanas Windrunner, Ranger-General of Silvermoon. I advise you to turn back now.",
            speaker: "Sylvanas Windrunner"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead03A\U03AArthas13.flac",
            caption: "It is you who should turn back, Sylvanas. Death itself has come for your land.",
            speaker: "Arthas Menethil")),
        new Faction[]
        {
          this,
          quelthalas
        },
        new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Scourge.Arthas, AllLegends.Quelthalas.Sylvanas)
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas30.flac",
            caption: "Now, arise, Kel'Thuzad, and serve the Lich King once again!",
            speaker: "Arthas Menethil"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AKelThuzad31.flac",
            caption: "I am reborn, as promised! The Lich King has granted me eternal life!",
            speaker: "Kel'thuzad")),
        new Faction[]
        {
          this,
          quelthalas
        },
        new[]
        {
          new ObjectiveQuestComplete(GetQuestByType<QuestKelthuzadLich>())
          {
            EligibleFactions = new List<Faction> { this }
          }
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02KelThuzad27.flac",
            caption: "Told you my death would mean little.",
            speaker: "Kel'thuzad"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02Arthas28.flac",
            caption: "What the... Am I hearing ghosts now?",
            speaker: "Arthas Menethil"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead02\U02KelThuzad29.flac",
            caption: "It is I, Kel'Thuzad. I was right about you, Prince Arthas.",
            speaker: "Kel'thuzad")),
        new[] { this },
        new Objective[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Scourge.Arthas, AllLegends.Scourge.Kelthuzad),
          new ObjectiveQuestComplete(GetQuestByType<QuestKelthuzadDies>())
          {
            EligibleFactions = new List<Faction> { this }
          },
          new ObjectiveQuestNotComplete(GetQuestByType<QuestKelthuzadLich>())
          {
            EligibleFactions = new List<Faction> { this }
          }
        }));
  }

  private void RegisterLegionDialogue(Legion legion)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05AArthas02.flac",
            caption: "I was wondering when you'd show up.",
            speaker: "Arthas Menethil"),
          new Dialogue(
            soundFile: @"Sound\Dialogue\UndeadCampaign\Undead05A\U05ATichondrius03.flac",
            caption: "I am here to ensure that you do your job, little human. Not do it for you.",
            speaker: "Tichondrius")),
        new Faction[]
        {
          this,
          legion
        },
        new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Scourge.Arthas, AllLegends.Legion.Tichondrius)
        }));
  }

  private void RegisterQuelthalasRelatedQuests(Quelthalas quelthalas)
  {
    var questKelthuzadLich = AddQuest(new QuestKelthuzadLich(AllLegends.Quelthalas.Sunwell,
      AllLegends.Scourge.Kelthuzad, quelthalas, Artifacts.SunwellVial));
    AddQuest(new QuestKelthuzadDies(questKelthuzadLich, AllLegends.Scourge.Kelthuzad));
  }

  private void RegisterLordaeronRelatedQuests(Faction lordaeron)
  {
    var stratholme = AllLegends.Lordaeron.Stratholme;
    var arthas = AllLegends.Lordaeron.Arthas;

    QuestDestroyStratholme questDestroyStratholme = new(lordaeron, stratholme, arthas);
    AddQuest(questDestroyStratholme);

    AddQuest(new QuestCultoftheDamned(lordaeron, AllLegends.Scourge.Rivendare));
  }

  private void RegisterLordaeronLegionRelatedQuests(Lordaeron lordaeron, Legion legion)
  {
    var plagueParameters = new PlagueParameters();
    plagueParameters.PlagueRects = new List<Rectangle>
    {
      Regions.Plague_1,
      Regions.Plague_2,
      Regions.Plague_3,
      Regions.Plague_4,
      Regions.Plague_5,
      Regions.Plague_6,
      Regions.Plague_7
    };
    plagueParameters.PlagueArmySummonParameters = new List<PlagueArmySummonParameter>
    {
      new(1, UNIT_UACO_ACOLYTE_SCOURGE_WORKER),
      new(2, UNIT_UGHO_GHOUL_SCOURGE),
      new(2, UNIT_UCRY_CRYPT_FIEND_SCOURGE),
      new(2, UNIT_UABO_ABOMINATION_SCOURGE),
    };
    plagueParameters.AttackTargets = new List<Point>
    {
      new Point(9041, 8036),
      new Point(13825, 12471),
      new Point(9418, 5396)
    };

    AddQuest(new QuestPlague(plagueParameters, lordaeron, legion, Regions.DeathknellUnlock,
      Regions.StratholmeScourgeBase, Regions.CaerDarrow));
  }
}
