using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class LegionSetup
  {
    public static Faction FactionLegion { get; private set; }
    
    public static void Setup()
    {
      FactionLegion = new Faction("Legion", PLAYER_COLOR_PEANUT, "|CFFBF8F4F",
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
      FactionLegion.ModObjectLimit(FourCC("u00H"), Faction.UNLIMITED); //Legion Defensive Pylon
      FactionLegion.ModObjectLimit(FourCC("u00I"), Faction.UNLIMITED); //Improved Defensive Pylon
      FactionLegion.ModObjectLimit(FourCC("u00F"), Faction.UNLIMITED); //Dormant Spire
      FactionLegion.ModObjectLimit(FourCC("u00C"), Faction.UNLIMITED); //Legion Bastion
      FactionLegion.ModObjectLimit(FourCC("u00N"), Faction.UNLIMITED); //Burning Citadel
      FactionLegion.ModObjectLimit(FourCC("n040"), Faction.UNLIMITED); //Armory
      FactionLegion.ModObjectLimit(FourCC("u009"), Faction.UNLIMITED); //Undead Shipyard
      FactionLegion.ModObjectLimit(FourCC("u00E"), Faction.UNLIMITED); //Generator
      FactionLegion.ModObjectLimit(FourCC("u01N"), Faction.UNLIMITED); //Burning Altar
      FactionLegion.ModObjectLimit(FourCC("u015"), Faction.UNLIMITED); //Unholy Reliquary
      FactionLegion.ModObjectLimit(FourCC("u006"), Faction.UNLIMITED); //Void Summoning Spire
      FactionLegion.ModObjectLimit(FourCC("ndmg"), Faction.UNLIMITED); //Demon Gate
      FactionLegion.ModObjectLimit(FourCC("n04N"), Faction.UNLIMITED); //Infernal Machine Factory
      FactionLegion.ModObjectLimit(FourCC("n04Q"), Faction.UNLIMITED); //Nether Pit
      FactionLegion.ModObjectLimit(FourCC("e01F"), 1); //Monolith
      FactionLegion.ModObjectLimit(FourCC("e01G"), 1); //Satue
      FactionLegion.ModObjectLimit(FourCC("e01H"), 1); //Fortress

      //Units
      FactionLegion.ModObjectLimit(FourCC("u00D"), Faction.UNLIMITED); //Legion Herald
      FactionLegion.ModObjectLimit(FourCC("u007"), 6); //Dreadlord
      FactionLegion.ModObjectLimit(FourCC("n04P"), Faction.UNLIMITED); //Warlock
      FactionLegion.ModObjectLimit(FourCC("ninc"), Faction.UNLIMITED); //Burning archer
      FactionLegion.ModObjectLimit(FourCC("n04K"), Faction.UNLIMITED); //Succubus
      FactionLegion.ModObjectLimit(FourCC("n04J"), Faction.UNLIMITED); //Felstalker
      FactionLegion.ModObjectLimit(FourCC("ubot"), 12); //Undead Transport SHip
      FactionLegion.ModObjectLimit(FourCC("udes"), 12); //Undead Frigate
      FactionLegion.ModObjectLimit(FourCC("uubs"), 6); //Undead Battleship
      FactionLegion.ModObjectLimit(FourCC("n04O"), 6); //Doomguard
      FactionLegion.ModObjectLimit(FourCC("n04L"), 6); //Infernal Juggernaut
      FactionLegion.ModObjectLimit(FourCC("ninf"), 12); //Infernal
      FactionLegion.ModObjectLimit(FourCC("n04H"), Faction.UNLIMITED); //Fel Guard
      FactionLegion.ModObjectLimit(FourCC("n04U"), 4); //Dragon
      FactionLegion.ModObjectLimit(FourCC("n03L"), 4); //Barge

      FactionLegion.ModObjectLimit(FourCC("n05R"), 1); //Felguard
      FactionLegion.ModObjectLimit(FourCC("n06H"), 1); //Pit Fiend
      FactionLegion.ModObjectLimit(FourCC("n07B"), 1); //Queen
      FactionLegion.ModObjectLimit(FourCC("n07D"), 1); //Maiden
      FactionLegion.ModObjectLimit(FourCC("n07o"), 1); //Terror
      FactionLegion.ModObjectLimit(FourCC("n07N"), 1); //Lord

      //Researches
      FactionLegion.ModObjectLimit(FourCC("R02C"), Faction.UNLIMITED); //Acute Sensors
      FactionLegion.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED); //Chaos Infusion
      FactionLegion.ModObjectLimit(FourCC("R028"), Faction.UNLIMITED); //Shadow Priest Adept Training
      FactionLegion.ModObjectLimit(FourCC("R027"), Faction.UNLIMITED); //Warlock Adept Training
      FactionLegion.ModObjectLimit(FourCC("R01Y"), Faction.UNLIMITED); //Astral Walk
      FactionLegion.ModObjectLimit(FourCC("R04G"), Faction.UNLIMITED); //Improved Carrion Swarm
      FactionLegion.ModObjectLimit(FourCC("R03Z"), Faction.UNLIMITED); //War Plating
      FactionLegion.ModObjectLimit(FourCC("R040"), Faction.UNLIMITED); //Flying horrors
      FactionLegion.SetObjectLevel(Constants.UPGRADE_R04R_TIER_4_UNIVERSAL_UPGRADE, 1);

      //Heroes
      FactionLegion.ModObjectLimit(FourCC("U00L"), 1); //Anetheron
      FactionLegion.ModObjectLimit(FourCC("Umal"), 1); //Mal)ganis
      FactionLegion.ModObjectLimit(FourCC("Utic"), 1); //Tichondrius

      FactionManager.Register(FactionLegion);
    }
  }
}