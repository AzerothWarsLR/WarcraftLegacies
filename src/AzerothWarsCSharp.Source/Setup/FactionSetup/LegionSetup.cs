using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class LegionSetup
  {
    public static Faction? Legion { get; private set; }
    
    public static void Setup()
    {
      Legion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F",
        "ReplaceableTextures\\CommandButtons\\BTNKiljaedin.blp")
      {
        UndefeatedResearch = FourCC("R04T"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "DarkAgents",
        IntroText = @"You are playing as the destructive |cffa2722dBurning Legion|r.

You begin isolated on Argus. Use Astral Walk and Diamonds of Summoning to move your units to Azeroth.

Hurry to Outland to help your Fel ally defeat the Draenei as soon as possible.

Your primary objective is to summon the Burning Legion. Invade the city of Dalaran, where the book of Medivh is kept, and use it to open a Demon-gate to Argus."
      };
      
      //Structures
      Legion.ModObjectLimit(FourCC("u00H"), Faction.UNLIMITED); //Legion Defensive Pylon
      Legion.ModObjectLimit(FourCC("u00I"), Faction.UNLIMITED); //Improved Defensive Pylon
      Legion.ModObjectLimit(FourCC("u00F"), Faction.UNLIMITED); //Dormant Spire
      Legion.ModObjectLimit(FourCC("u00C"), Faction.UNLIMITED); //Legion Bastion
      Legion.ModObjectLimit(FourCC("u00N"), Faction.UNLIMITED); //Burning Citadel
      Legion.ModObjectLimit(FourCC("n040"), Faction.UNLIMITED); //Armory
      Legion.ModObjectLimit(FourCC("u009"), Faction.UNLIMITED); //Undead Shipyard
      Legion.ModObjectLimit(FourCC("u00E"), Faction.UNLIMITED); //Generator
      Legion.ModObjectLimit(FourCC("u01N"), Faction.UNLIMITED); //Burning Altar
      Legion.ModObjectLimit(FourCC("u015"), Faction.UNLIMITED); //Unholy Reliquary
      Legion.ModObjectLimit(FourCC("u006"), Faction.UNLIMITED); //Void Summoning Spire
      Legion.ModObjectLimit(FourCC("ndmg"), Faction.UNLIMITED); //Demon Gate
      Legion.ModObjectLimit(FourCC("n04N"), Faction.UNLIMITED); //Infernal Machine Factory
      Legion.ModObjectLimit(FourCC("n04Q"), Faction.UNLIMITED); //Nether Pit
      Legion.ModObjectLimit(FourCC("e01F"), 1); //Monolith
      Legion.ModObjectLimit(FourCC("e01G"), 1); //Satue
      Legion.ModObjectLimit(FourCC("e01H"), 1); //Fortress

      //Units
      Legion.ModObjectLimit(FourCC("u00D"), Faction.UNLIMITED); //Legion Herald
      Legion.ModObjectLimit(FourCC("u007"), 6); //Dreadlord
      Legion.ModObjectLimit(FourCC("n04P"), Faction.UNLIMITED); //Warlock
      Legion.ModObjectLimit(FourCC("ninc"), Faction.UNLIMITED); //Burning archer
      Legion.ModObjectLimit(FourCC("n04K"), Faction.UNLIMITED); //Succubus
      Legion.ModObjectLimit(FourCC("n04J"), Faction.UNLIMITED); //Felstalker
      Legion.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport SHip
      Legion.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      Legion.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship
      Legion.ModObjectLimit(FourCC("n04O"), 6); //Doomguard
      Legion.ModObjectLimit(FourCC("n04L"), 6); //Infernal Juggernaut
      Legion.ModObjectLimit(FourCC("ninf"), 12); //Infernal
      Legion.ModObjectLimit(FourCC("n04H"), Faction.UNLIMITED); //Fel Guard
      Legion.ModObjectLimit(FourCC("n04U"), 4); //Dragon
      Legion.ModObjectLimit(FourCC("n03L"), 4); //Barge

      Legion.ModObjectLimit(FourCC("n05R"), 1); //Felguard
      Legion.ModObjectLimit(FourCC("n06H"), 1); //Pit Fiend
      Legion.ModObjectLimit(FourCC("n07B"), 1); //Queen
      Legion.ModObjectLimit(FourCC("n07D"), 1); //Maiden
      Legion.ModObjectLimit(FourCC("n07o"), 1); //Terror
      Legion.ModObjectLimit(FourCC("n07N"), 1); //Lord

      //Researches
      Legion.ModObjectLimit(FourCC("R02C"), Faction.UNLIMITED); //Acute Sensors
      Legion.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion
      Legion.ModObjectLimit(FourCC("R028"), Faction.UNLIMITED); //Shadow Priest Adept Training
      Legion.ModObjectLimit(FourCC("R027"), Faction.UNLIMITED); //Warlock Adept Training
      Legion.ModObjectLimit(FourCC("R01Y"), Faction.UNLIMITED); //Astral Walk
      Legion.ModObjectLimit(FourCC("R04G"), Faction.UNLIMITED); //Improved Carrion Swarm
      Legion.ModObjectLimit(FourCC("R03Z"), Faction.UNLIMITED); //War Plating
      Legion.ModObjectLimit(FourCC("R040"), Faction.UNLIMITED); //Flying horrors
      Legion.SetObjectLevel(Constants.UPGRADE_R04R_TIER_4_UNIVERSAL_UPGRADE, 1);

      //Heroes
      Legion.ModObjectLimit(FourCC("U00L"), 1); //Anetheron
      Legion.ModObjectLimit(Constants.UNIT_UMAL_THE_CUNNING_LEGION, 1); //Mal)ganis
      Legion.ModObjectLimit(Constants.UNIT_UTIC_THE_DARKENER_LEGION, 1); //Tichondrius

      Legion.AddGoldMine(PreplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-23179, 6865)));
      
      FactionManager.Register(Legion);
    }
  }
}