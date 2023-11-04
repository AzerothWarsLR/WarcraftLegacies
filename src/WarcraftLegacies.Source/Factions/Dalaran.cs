using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionChoices;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Dalaran;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Dalaran : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly ArtifactSetup _artifactSetup;
    private readonly AllLegendSetup _allLegendSetup;
    
    /// <inheritdoc />
    public Dalaran(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
      : base("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0", @"ReplaceableTextures\CommandButtons\BTNJaina.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _artifactSetup = artifactSetup;
      _allLegendSetup = allLegendSetup;
      UndefeatedResearch = Constants.UPGRADE_R05N_DALARAN_EXISTS;
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "SadMystery";
      ControlPointDefenderUnitTypeId = Constants.UNIT_N00N_CONTROL_POINT_DEFENDER_DALARAN;
      StartingCameraPosition = Regions.DalaStartPos.Center;
      StartingUnits = Regions.DalaStartPos.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      LearningDifficulty = FactionLearningDifficulty.Basic;
      IntroText = @"You are playing the wise |cffff8080Council of Dalaran|r.

You begin in the Hillsbrad Foothills, separated from the main forces of Dalaran. To unlock Dalaran you must capture Shadowfang Keep, which have been encircled by monsters.

Once your territory is secured, you will need to prepare for the Plague of Undeath and the invasion of the Burning Legion. Lordaeron will surely need your help.

Your mages are the finest in Azeroth, be sure to utilize them alongside your heroes to turn the tide of battle.";
    }

    /// <inheritdoc />
    public override void OnRegister()
    {
      RegisterObjectLimits();
      RegisterGoldMines();
      RegisterQuests();
    }

    private void RegisterObjectLimits()
    {
      //Structures
      ModObjectLimit(FourCC("h065"), UNLIMITED); //Refuge
      ModObjectLimit(FourCC("h066"), UNLIMITED); //Conclave
      ModObjectLimit(FourCC("h068"), UNLIMITED); //Observatory
      ModObjectLimit(FourCC("h063"), UNLIMITED); //Granary
      ModObjectLimit(FourCC("h044"), UNLIMITED); //Altar of Knowledge
      ModObjectLimit(FourCC("h069"), UNLIMITED); //Barracks
      ModObjectLimit(FourCC("h02N"), UNLIMITED); //Trade Quarters
      ModObjectLimit(FourCC("h036"), UNLIMITED); //Arcane Sanctuary
      ModObjectLimit(FourCC("h078"), UNLIMITED); //Scout Tower
      ModObjectLimit(FourCC("h079"), UNLIMITED); //Arcane Tower
      ModObjectLimit(FourCC("h07A"), UNLIMITED); //Arcane Tower (Improved)
      ModObjectLimit(FourCC("hvlt"), UNLIMITED); //Arcane Vault
      ModObjectLimit(FourCC("h076"), UNLIMITED); //Alliance Shipyard
      ModObjectLimit(FourCC("ndgt"), UNLIMITED); //Dalaran Tower
      ModObjectLimit(FourCC("n004"), UNLIMITED); //Dalaran Tower (Improved)
      ModObjectLimit(FourCC("h067"), UNLIMITED); //Laboratory
      ModObjectLimit(FourCC("n0AO"), 2); //Way Gate

      //Units
      ModObjectLimit(FourCC("h022"), UNLIMITED); //Shaper
      ModObjectLimit(FourCC("nhym"), UNLIMITED); //Hydromancer
      ModObjectLimit(FourCC("h032"), UNLIMITED); //Battlemage
      ModObjectLimit(FourCC("h02D"), UNLIMITED); //Geomancer
      ModObjectLimit(FourCC("h01I"), UNLIMITED); //Arcanist
      ModObjectLimit(FourCC("n007"), 6); //Kirin Tor
      ModObjectLimit(FourCC("n096"), 6); //Earth Golem
      ModObjectLimit(FourCC("n03E"), UNLIMITED); //Pyromancer
      ModObjectLimit(FourCC("n0AK"), UNLIMITED); //Sludge Flinger
      ModObjectLimit(FourCC("o02U"), 6); //Crystal Artillery
      ModObjectLimit(Constants.UNIT_N0AC_BLUE_DRAGON_DALARAN, 6);

      //Ships
      ModObjectLimit(FourCC("hbot"), UNLIMITED); //Alliance Transport Ship
      ModObjectLimit(FourCC("h0AR"), UNLIMITED); //Alliance Scout
      ModObjectLimit(FourCC("h0AX"), UNLIMITED); //Alliance Frigate
      ModObjectLimit(FourCC("h0B3"), UNLIMITED); //Alliance Fireship
      ModObjectLimit(FourCC("h0B0"), UNLIMITED); //Alliance Galley
      ModObjectLimit(FourCC("h0B6"), UNLIMITED); //Alliance Boarding
      ModObjectLimit(FourCC("h0AN"), UNLIMITED); //Alliance Juggernaut
      ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard
      
      //Demi-heroes
      ModObjectLimit(Constants.UNIT_NJKS_JAILOR_KASSAN_DALARAN_DEMI, 1);
      ModObjectLimit(Constants.UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN, 1);
      ModObjectLimit(Constants.UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN, 1);
      ModObjectLimit(Constants.UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN, 1);
      ModObjectLimit(Constants.UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN, 1);
      
      //Upgrades
      ModObjectLimit(FourCC("R01I"), UNLIMITED); //Arcanist Adept Training
      ModObjectLimit(FourCC("R01V"), UNLIMITED); //Geomancer Adept Training
      ModObjectLimit(FourCC("R00E"), UNLIMITED); //Hydromancer Adept Training
      ModObjectLimit(FourCC("R00D"), UNLIMITED); //Pyromancer Adept Training
      ModObjectLimit(FourCC("Rhac"), UNLIMITED); //Improved Masonry
      ModObjectLimit(FourCC("R06J"), UNLIMITED); //Improved Ooze
      ModObjectLimit(FourCC("R061"), UNLIMITED); //Improved Forked Lightning
      ModObjectLimit(FourCC("R06O"), UNLIMITED); //Improved Phase Blade
      ModObjectLimit(FourCC("R00J"), UNLIMITED); //Combat Tomes

      ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, 1);
      ModAbilityAvailability(Constants.ABILITY_A0GG_SPELL_SHIELD_SPELL_BOOK_ORANGE_KIRIN_TOR, -1); //Todo: should be global
      ModAbilityAvailability(Constants.ABILITY_A0WG_SPELL_SHIELD_SPELL_BOOK_ORANGE_ANTONIDAS_RED_LICH_KING, -1);
      ModAbilityAvailability(Constants.ABILITY_A0UG_PHASE_BLADE_AUTO_CAST_ORANGE_BARRACKS_OFF, -1); //Todo: should have a system for this
      ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
    }

    private void RegisterGoldMines()
    {
      AddGoldMine(_preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(9204, 2471)));

      AddGoldMine(_preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(7386, 6999)));
      AddGoldMine(_preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(7716, 11657)));
      AddGoldMine(_preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(17198, 8222)));
    }
    
    private void RegisterQuests()
    {
      QuestNewGuardian newGuardian = new(_artifactSetup.BookOfMedivh, _allLegendSetup.Dalaran.Jaina,
        _allLegendSetup.Dalaran.Dalaran);
      QuestAegwynn aegwynn = new(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Dalaran.Antonidas);
      QuestTheNexus theNexus = new(_allLegendSetup.Dalaran, _allLegendSetup.Scourge.TheFrozenThrone, _allLegendSetup.Neutral.TheNexus);
      QuestCrystalGolem crystalGolem = new(_allLegendSetup.Neutral.DraktharonKeep);
      QuestFallenGuardian fallenGuardian = new(_allLegendSetup.Neutral.Karazhan);

      newGuardian.AddObjective(new ObjectiveQuestNotComplete(theNexus));
      crystalGolem.AddObjective(new ObjectiveQuestNotComplete(theNexus));
      aegwynn.AddObjective(new ObjectiveQuestNotComplete(theNexus));

      theNexus.AddObjective(new ObjectiveQuestNotComplete(newGuardian));

      var questSouthshore = AddQuest(new QuestSouthshore(Regions.SouthshoreUnlock,
        _preplacedUnitSystem.GetUnit(FourCC("nmrm"), Regions.SouthshoreUnlock.Center)));
      StartingQuest = questSouthshore;
      var questShadowfang = AddQuest(new QuestShadowfang(Regions.ShadowfangUnlock,
        _preplacedUnitSystem.GetUnit(Constants.UNIT_NWLD_DIRE_WOLF_CREEP, new Point(7668.5f, 4352.2f))));
      AddQuest(new QuestDalaran(new[]
      {
        Regions.Dalaran
      }, new QuestData[]
      {
        questSouthshore,
        questShadowfang
      }));
      AddQuest(new QuestJainaSoulGem(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Neutral.Caerdarrow));
      AddQuest(new QuestBlueDragons(_allLegendSetup.Neutral.TheNexus));
      AddQuest(new QuestKarazhan(_allLegendSetup.Neutral.Karazhan));

      AddQuest(new QuestTheramore(_allLegendSetup.Dalaran.Jaina, _allLegendSetup.Dalaran.Dalaran,  Regions.Theramore));

      AddQuest(crystalGolem);
      AddQuest(fallenGuardian);
      AddQuest(aegwynn);
      AddQuest(newGuardian);
      AddQuest(theNexus);
    }
  }
}