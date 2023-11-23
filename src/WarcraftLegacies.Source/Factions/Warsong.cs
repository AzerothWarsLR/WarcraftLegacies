using System.Collections.Generic;
using MacroTools;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Warsong : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Warsong(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000",
      @"ReplaceableTextures\CommandButtons\BTNHellScream.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = FourCC("R05W");
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "DarkAgents";
      ControlPointDefenderUnitTypeId = Constants.UNIT_N0D6_CONTROL_POINT_DEFENDER_WARSONG;
      IntroText = @"You are playing as the brutal |cffd45e19Warsong clan|r.

You begin in the eaves of Ashenvale, isolated from your ally, the Frostwolf Clan in the South. 

The Warchief expects a large amount of lumber from you. Begin by harvesting with your Peons, and expanding into the Barrens and Durotar.

The Night Elves are aware of your presence and are gathering a mighty host against you. Unlock Orgrimmar as soon as possible to defend against the Night Elf assault.";
      GoldMines = new List<unit>
      {
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-8455, -2777))
      };
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(FourCC("o00C"), Faction.UNLIMITED); //Great Hall
      ModObjectLimit(FourCC("o02R"), Faction.UNLIMITED); //Stronghold
      ModObjectLimit(FourCC("o02S"), Faction.UNLIMITED); //Fortress
      ModObjectLimit(FourCC("o020"), Faction.UNLIMITED); //Altar of Storms
      ModObjectLimit(FourCC("o01S"), Faction.UNLIMITED); //Barracks
      ModObjectLimit(FourCC("o009"), Faction.UNLIMITED); //War Mill
      ModObjectLimit(FourCC("o006"), Faction.UNLIMITED); //Ogre Barrack
      ModObjectLimit(FourCC("o05G"), Faction.UNLIMITED); //Siege Workshop
      ModObjectLimit(FourCC("o02Q"), Faction.UNLIMITED); //Bestiary
      ModObjectLimit(FourCC("o028"), Faction.UNLIMITED); //Orc Burrow
      ModObjectLimit(FourCC("n03E"), Faction.UNLIMITED); //Watch Tower
      ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED); //Troll Shrine
      ModObjectLimit(FourCC("n0AL"), Faction.UNLIMITED); //Improved Watch Tower
      ModObjectLimit(FourCC("o02T"), Faction.UNLIMITED); //Shipyard
      ModObjectLimit(FourCC("o01T"), Faction.UNLIMITED); //Goblin Hardware Shop

      ModObjectLimit(FourCC("o04L"), Faction.UNLIMITED); //Peon
      ModObjectLimit(FourCC("o02M"), Faction.UNLIMITED); //Grunt
      ModObjectLimit(FourCC("orai"), Faction.UNLIMITED); //Raider
      ModObjectLimit(FourCC("n08E"), Faction.UNLIMITED); //Hexbinder
      ModObjectLimit(FourCC("otbk"), Faction.UNLIMITED); //Troll Berseker
      ModObjectLimit(FourCC("nogn"), Faction.UNLIMITED); //Stonemaul Ogre Magi
      ModObjectLimit(FourCC("o00I"), 6); //Horde War Machine
      ModObjectLimit(FourCC("e01M"), 4); //Azerite Siege Engine
      ModObjectLimit(FourCC("okod"), 4); //Kodo Beast
      ModObjectLimit(FourCC("o00G"), 6); //Blademaster
      ModObjectLimit(FourCC("n03F"), 6); //Korkron elite
      ModObjectLimit(FourCC("owyv"), 8); //Wind Rider

      //Ship
      ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship
      ModObjectLimit(FourCC("h0AS"), Faction.UNLIMITED); //Scout
      ModObjectLimit(FourCC("h0AP"), Faction.UNLIMITED); //Frigate
      ModObjectLimit(FourCC("h0B2"), Faction.UNLIMITED); //Fireship
      ModObjectLimit(FourCC("h0AY"), Faction.UNLIMITED); //Galley
      ModObjectLimit(FourCC("h0B5"), Faction.UNLIMITED); //Boarding
      ModObjectLimit(FourCC("h0BC"), Faction.UNLIMITED); //Juggernaut
      ModObjectLimit(FourCC("h0AO"), 6); //Bombard

      ModObjectLimit(FourCC("Ogrh"), 1); //Grom
      ModObjectLimit(FourCC("Obla"), 1); //Varok
      ModObjectLimit(FourCC("O06L"), 1); //Garrosh
      ModObjectLimit(Constants.UNIT_NSJS_BREWMASTER_WARSONG, 1);
      ModObjectLimit(FourCC("n0CN"), 1); //Gibbs
      ModObjectLimit(Constants.UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT, 1); //Blood Pact Grom   Fixes Perma Death Grom Blood Pact bug

      ModObjectLimit(FourCC("Robs"), Faction.UNLIMITED); //Berserker Strength
      ModObjectLimit(FourCC("Rotr"), Faction.UNLIMITED); //Troll Regeneration
      ModObjectLimit(FourCC("R01J"), Faction.UNLIMITED); //Ensnare
      ModObjectLimit(FourCC("R02I"), Faction.UNLIMITED); //Ogre Magi Adept Training
      ModObjectLimit(FourCC("R03Q"), Faction.UNLIMITED); //Warlock Adept Training
      ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      ModObjectLimit(FourCC("R016"), Faction.UNLIMITED); //Warlords
      ModObjectLimit(FourCC("R019"), Faction.UNLIMITED); //Improved Shockwave
      ModObjectLimit(Constants.UPGRADE_R01Z_BATTLE_STATIONS_ORC, Faction.UNLIMITED);
      SetObjectLevel(Constants.UPGRADE_R01Z_BATTLE_STATIONS_ORC, 1);
      ModObjectLimit(Constants.UPGRADE_R00D_MASS_BLOODLUST_FROSTWOLF, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_ROVS_ENVENOMED_SPEARS_WARSONG, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R017_IMPROVED_IGNORE_PAIN_WARSONG, Faction.UNLIMITED);


      ModObjectLimit(Constants.UPGRADE_R09N_FLIGHT_PATH_WARSONG, 1);

      ModAbilityAvailability(Constants.ABILITY_A0PF_FEL_ENERGY_TEAL_FORTRESSES, -1);
      ModAbilityAvailability(Constants.ABILITY_ANTR_TROLL_REGENERATION_PINK_WITCH_DOCTOR_TROLL_HEADHUNTER_TROLL_BATRIDER_DARKSPEAR_WARLORD_TROLL_BERSERKER_ICON, -1);
      ModAbilityAvailability(Constants.ABILITY_ABTL_BATTLE_STATIONS_FROSTWOLF_WARSONG_BURROW, 1);
      ModAbilityAvailability(Constants.ABILITY_A0M4_BATTLE_STATIONS_PINK_GREY_ORC_BURROW_BLOODPACT, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, 1);

      ModObjectLimit(Constants.UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, 1);
      ModObjectLimit(Constants.UPGRADE_R09P_REVERT_BLOODPACT, 1);
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterDialogue()
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          "Grom Hellscream"), new[]
        {
          this
        }, new List<Objective>
        {
          new ObjectiveControlLegend(legendSetup.Warsong.GromHellscream, false)
          {
            EligibleFactions = new List<Faction>
            {
              this
            }
          },
          new ObjectiveControlCapital(legendSetup.Neutral.FountainOfBlood, false)
          {
            EligibleFactions = new List<Faction>
            {
              this
            }
          }
        }
      ));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\RandomOrcQuest02x\DR02Chen01",
            "Ah, greetings, my friend. I am Chen Stormstout, humble brewmaster of Pandaria. I have traveled the wide world searching for rare, exotic ingredients to use in my special brew! After all, good ale can solve all the problems of this world, don't you agree?",
            "Chen Stormstout")
          , new[]
          {
            this
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Warsong.ChenStormstout, false)
            {
              EligibleFactions = new List<Faction>{ this }
            }
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\OrcCampaign\Orc04\O04Grom01",
              "Damn Thrall for sending us away! He chooses to use his greatest warriors for manual labor? He'll be lost without me.",
              "Grom Hellscream"))
          , new[]
          {
            this
          }, new[]
          {
            new ObjectiveControlLegend(legendSetup.Warsong.GromHellscream, false)
            {
              EligibleFactions = new List<Faction>{this}
            }
          }));
    }
  }
}