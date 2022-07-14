using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class WarsongSetup
  {
    public static Faction FACTION_WARSONG { get; private set; }
    
    public static void Setup()
    {
      FACTION_WARSONG = new Faction("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000",
        "ReplaceableTextures\\CommandButtons\\BTNHellScream.blp")
      {
        UndefeatedResearch = FourCC("R05W"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "DarkAgents",
        IntroText = @"You are playing as the proud |cffd45e19Warsong clan|r.

        You start isolated in the woods of Ashenvale. The Warchief expects a large amount of lumber from you, begin harvesting with your Peons.

        Travel South into the Barren to creep and colonise.

        The Night Elves are aware of your presence and are gathering against you. Unlock Orgrimmar as soon as possible to defend against the Night Elf attacks."
      };

      FACTION_WARSONG.ModObjectLimit(FourCC("o00C"), Faction.UNLIMITED); //Great Hall
      FACTION_WARSONG.ModObjectLimit(FourCC("o02R"), Faction.UNLIMITED); //Stronghold
      FACTION_WARSONG.ModObjectLimit(FourCC("o02S"), Faction.UNLIMITED); //Fortress
      FACTION_WARSONG.ModObjectLimit(FourCC("o020"), Faction.UNLIMITED); //Altar of Storms
      FACTION_WARSONG.ModObjectLimit(FourCC("o01S"), Faction.UNLIMITED); //Barracks
      FACTION_WARSONG.ModObjectLimit(FourCC("o009"), Faction.UNLIMITED); //War Mill
      FACTION_WARSONG.ModObjectLimit(FourCC("o006"), Faction.UNLIMITED); //Ogre Barrack
      FACTION_WARSONG.ModObjectLimit(FourCC("o05G"), Faction.UNLIMITED); //Siege Workshop
      FACTION_WARSONG.ModObjectLimit(FourCC("o02Q"), Faction.UNLIMITED); //Bestiary
      FACTION_WARSONG.ModObjectLimit(FourCC("o028"), Faction.UNLIMITED); //Orc Burrow
      FACTION_WARSONG.ModObjectLimit(FourCC("n03E"), Faction.UNLIMITED); //Watch Tower
      FACTION_WARSONG.ModObjectLimit(FourCC("o01H"), Faction.UNLIMITED); //Troll Shrine
      FACTION_WARSONG.ModObjectLimit(FourCC("n0AL"), Faction.UNLIMITED); //Improved Watch Tower
      FACTION_WARSONG.ModObjectLimit(FourCC("o02T"), Faction.UNLIMITED); //Shipyard
      FACTION_WARSONG.ModObjectLimit(FourCC("o01T"), Faction.UNLIMITED); //Goblin Hardware Shop

      FACTION_WARSONG.ModObjectLimit(FourCC("o04L"), Faction.UNLIMITED); //Peon
      FACTION_WARSONG.ModObjectLimit(FourCC("o02M"), Faction.UNLIMITED); //Grunt
      FACTION_WARSONG.ModObjectLimit(FourCC("orai"), Faction.UNLIMITED); //Raider
      FACTION_WARSONG.ModObjectLimit(FourCC("n08E"), Faction.UNLIMITED); //Hexbinder
      FACTION_WARSONG.ModObjectLimit(FourCC("otbk"), Faction.UNLIMITED); //Troll Berseker
      FACTION_WARSONG.ModObjectLimit(FourCC("nogn"), Faction.UNLIMITED); //Stonemaul Ogre Magi
      FACTION_WARSONG.ModObjectLimit(FourCC("o00I"), 6); //Horde War Machine
      FACTION_WARSONG.ModObjectLimit(FourCC("e01L"), 2); //War Station
      FACTION_WARSONG.ModObjectLimit(FourCC("e01M"), 4); //Azerite Siege Engine
      FACTION_WARSONG.ModObjectLimit(FourCC("okod"), 4); //Kodo Beast
      FACTION_WARSONG.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      FACTION_WARSONG.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      FACTION_WARSONG.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      FACTION_WARSONG.ModObjectLimit(FourCC("o00G"), 6); //Blademaster
      FACTION_WARSONG.ModObjectLimit(FourCC("n03F"), 6); //Korkron elite
      FACTION_WARSONG.ModObjectLimit(FourCC("owyv"), 8); //Wind Rider

      FACTION_WARSONG.ModObjectLimit(FourCC("Ogrh"), 1); //Grom
      FACTION_WARSONG.ModObjectLimit(FourCC("Obla"), 1); //Varok

      FACTION_WARSONG.ModObjectLimit(FourCC("Robs"), Faction.UNLIMITED); //Berserker Strength
      FACTION_WARSONG.ModObjectLimit(FourCC("Rotr"), Faction.UNLIMITED); //Troll Regeneration
      FACTION_WARSONG.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      FACTION_WARSONG.ModObjectLimit(FourCC("R01J"), Faction.UNLIMITED); //Ensnare
      FACTION_WARSONG.ModObjectLimit(FourCC("R02I"), Faction.UNLIMITED); //Ogre Magi Adept Training
      FACTION_WARSONG.ModObjectLimit(FourCC("R03Q"), Faction.UNLIMITED); //Warlock Adept Training
      FACTION_WARSONG.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      FACTION_WARSONG.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      FACTION_WARSONG.ModObjectLimit(FourCC("R016"), Faction.UNLIMITED); //Warlords
      FACTION_WARSONG.ModObjectLimit(FourCC("R019"), Faction.UNLIMITED); //Improved Shockwave
      FACTION_WARSONG.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      FACTION_WARSONG.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations
      FACTION_WARSONG.ModObjectLimit(FourCC("R00D"), Faction.UNLIMITED); //For the Horde!
      FACTION_WARSONG.ModObjectLimit(FourCC("Rovs"), Faction.UNLIMITED); //Envenomed Spears
      FACTION_WARSONG.ModObjectLimit(FourCC("R017"), Faction.UNLIMITED); //Improved Ignore Pain

      FactionManager.Register(FACTION_WARSONG);
    }
  }
}