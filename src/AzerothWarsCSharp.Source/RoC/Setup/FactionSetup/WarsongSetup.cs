using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class WarsongSetup{
  
    Faction FACTION_WARSONG
  

    public static void OnInit( ){
      Faction f;

      FACTION_WARSONG = Faction.create("Warsong", PLAYER_COLOR_ORANGE, "|c00ff8000","ReplaceableTextures\\CommandButtons\\BTNHellScream.blp");
      f = FACTION_WARSONG;
      f.Team = TEAM_HORDE;
      f.UndefeatedResearch = FourCC(R05W);
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC(o00C), UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC(o02R), UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC(o02S), UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC(o020), UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC(o01S), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(o009), UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC(o006), UNLIMITED)   ;//Ogre Barrack
      f.ModObjectLimit(FourCC(o05G), UNLIMITED)   ;//Siege Workshop
      f.ModObjectLimit(FourCC(o02Q), UNLIMITED)   ;//Bestiary
      f.ModObjectLimit(FourCC(o028), UNLIMITED)   ;//Orc Burrow
      f.ModObjectLimit(FourCC(n03E), UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC(o01H), UNLIMITED)   ;//Troll Shrine
      f.ModObjectLimit(FourCC(n0AL), UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC(o02T), UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC(o01T), UNLIMITED)   ;//Goblin Hardware Shop

      f.ModObjectLimit(FourCC(o04L), UNLIMITED)   ;//Peon
      f.ModObjectLimit(FourCC(o02M), UNLIMITED)   ;//Grunt
      f.ModObjectLimit(FourCC(orai), UNLIMITED)   ;//Raider
      f.ModObjectLimit(FourCC(n08E), UNLIMITED)   ;//Hexbinder
      f.ModObjectLimit(FourCC(otbk), UNLIMITED)   ;//Troll Berseker
      f.ModObjectLimit(FourCC(nogn), UNLIMITED)   ;//Stonemaul Ogre Magi
      f.ModObjectLimit(FourCC(o00I), 6)           ;//Horde War Machine
      f.ModObjectLimit(FourCC(e01L), 2)           ;//War Station
      f.ModObjectLimit(FourCC(e01M), 4)           ;//Azerite Siege Engine
      f.ModObjectLimit(FourCC(okod), 4)           ;//Kodo Beast
      f.ModObjectLimit(FourCC(obot), 12)   	    ;//Transport Ship
      f.ModObjectLimit(FourCC(odes), 12)  	     ;//Orc Frigate
      f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught
      f.ModObjectLimit(FourCC(o00G), 6)           ;//Blademaster
      f.ModObjectLimit(FourCC(n03F), 6)           ;//Korkron elite
      f.ModObjectLimit(FourCC(owyv), 8)           ;//Wind Rider

      f.ModObjectLimit(FourCC(Ogrh), 1)           ;//Grom
      f.ModObjectLimit(FourCC(Obla), 1)           ;//Varok

      f.ModObjectLimit(FourCC(Robs), UNLIMITED)   ;//Berserker Strength
      f.ModObjectLimit(FourCC(Rotr), UNLIMITED)   ;//Troll Regeneration
      f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC(R01J), UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC(R02I), UNLIMITED)   ;//Ogre Magi Adept Training
      f.ModObjectLimit(FourCC(R03Q), UNLIMITED)   ;//Warlock Adept Training
      f.ModObjectLimit(FourCC(Rorb), UNLIMITED)   ;//Reinforced Defenses
      f.ModObjectLimit(FourCC(Rosp), UNLIMITED)   ;//Spiked Barricades
      f.ModObjectLimit(FourCC(R016), UNLIMITED)   ;//Warlords
      f.ModObjectLimit(FourCC(R019), UNLIMITED)   ;//Improved Shockwave
      f.ModObjectLimit(FourCC(R01Z), UNLIMITED)   ;//Battle Stations
      f.SetObjectLevel(FourCC(R01Z), 1)                ;//Battle Stations
      f.ModObjectLimit(FourCC(R00D), UNLIMITED)   ;//For the Horde!
      f.ModObjectLimit(FourCC(Rovs), UNLIMITED)   ;//Envenomed Spears
      f.ModObjectLimit(FourCC(R017), UNLIMITED)   ;//Improved Ignore Pain
    }

  }
}
