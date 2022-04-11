using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class WarsongSetup{
    public static Faction FACTION_WARSONG { get; private set; }
  

    public static void Setup( ){
      Faction f;

      FACTION_WARSONG = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000","ReplaceableTextures\\CommandButtons\\BTNHellScream.blp");
      f = FACTION_WARSONG;
      f.Team = TeamSetup.TeamHorde;
      f.UndefeatedResearch = FourCC("R05W");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("o00C"), Faction.UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC("o02R"), Faction.UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC("o02S"), Faction.UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC("o020"), Faction.UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC("o01S"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("o009"), Faction.UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC("o006"), Faction.UNLIMITED)   ;//Ogre Barrack
      f.ModObjectLimit(FourCC("o05G"), Faction.UNLIMITED)   ;//Siege Workshop
      f.ModObjectLimit(FourCC("o02Q"), Faction.UNLIMITED)   ;//Bestiary
      f.ModObjectLimit(FourCC("o028"), Faction.UNLIMITED)   ;//Orc Burrow
      f.ModObjectLimit(FourCC("n03E"), Faction.UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED)   ;//Troll Shrine
      f.ModObjectLimit(FourCC("n0AL"), Faction.UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC("o02T"), Faction.UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC("o01T"), Faction.UNLIMITED)   ;//Goblin Hardware Shop

      f.ModObjectLimit(FourCC("o04L"), Faction.UNLIMITED)   ;//Peon
      f.ModObjectLimit(FourCC("o02M"), Faction.UNLIMITED)   ;//Grunt
      f.ModObjectLimit(FourCC("orai"), Faction.UNLIMITED)   ;//Raider
      f.ModObjectLimit(FourCC("n08E"), Faction.UNLIMITED)   ;//Hexbinder
      f.ModObjectLimit(FourCC("otbk"), Faction.UNLIMITED)   ;//Troll Berseker
      f.ModObjectLimit(FourCC("nogn"), Faction.UNLIMITED)   ;//Stonemaul Ogre Magi
      f.ModObjectLimit(FourCC("o00I"), 6)           ;//Horde War Machine
      f.ModObjectLimit(FourCC("e01L"), 2)           ;//War Station
      f.ModObjectLimit(FourCC("e01M"), 4)           ;//Azerite Siege Engine
      f.ModObjectLimit(FourCC("okod"), 4)           ;//Kodo Beast
      f.ModObjectLimit(FourCC("obot"), 12)   	    ;//Transport Ship
      f.ModObjectLimit(FourCC("odes"), 12)  	     ;//Orc Frigate
      f.ModObjectLimit(FourCC("ojgn"), 6)          ;//Juggernaught
      f.ModObjectLimit(FourCC("o00G"), 6)           ;//Blademaster
      f.ModObjectLimit(FourCC("n03F"), 6)           ;//Korkron elite
      f.ModObjectLimit(FourCC("owyv"), 8)           ;//Wind Rider

      f.ModObjectLimit(FourCC("Ogrh"), 1)           ;//Grom
      f.ModObjectLimit(FourCC("Obla"), 1)           ;//Varok

      f.ModObjectLimit(FourCC("Robs"), Faction.UNLIMITED)   ;//Berserker Strength
      f.ModObjectLimit(FourCC("Rotr"), Faction.UNLIMITED)   ;//Troll Regeneration
      f.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC("R01J"), Faction.UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC("R02I"), Faction.UNLIMITED)   ;//Ogre Magi Adept Training
      f.ModObjectLimit(FourCC("R03Q"), Faction.UNLIMITED)   ;//Warlock Adept Training
      f.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED)   ;//Reinforced Defenses
      f.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED)   ;//Spiked Barricades
      f.ModObjectLimit(FourCC("R016"), Faction.UNLIMITED)   ;//Warlords
      f.ModObjectLimit(FourCC("R019"), Faction.UNLIMITED)   ;//Improved Shockwave
      f.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED)   ;//Battle Stations
      f.SetObjectLevel(FourCC("R01Z"), 1)                ;//Battle Stations
      f.ModObjectLimit(FourCC("R00D"), Faction.UNLIMITED)   ;//For the Horde!
      f.ModObjectLimit(FourCC("Rovs"), Faction.UNLIMITED)   ;//Envenomed Spears
      f.ModObjectLimit(FourCC("R017"), Faction.UNLIMITED)   ;//Improved Ignore Pain
    }

  }
}
