using AzerothWarsCSharp.MacroTools.FactionSystem;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class GoblinSetup
  {
    public static Faction factionGoblin;
    
    public static void Setup( ){
      Faction f;
      factionGoblin = new Faction("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080","ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp");
      f = factionGoblin;
      f.Team = TeamSetup.TeamHorde;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      f.ModObjectLimit(FourCC("o03L"), Faction.UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC("o03M"), Faction.UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC("o03N"), Faction.UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC("o03O"), Faction.UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC("o03P"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("o03Q"), Faction.UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC("o03S"), Faction.UNLIMITED)   ;//Tauren Totem
      f.ModObjectLimit(FourCC("o01M"), Faction.UNLIMITED)   ;//Spirit Lodge
      f.ModObjectLimit(FourCC("o03T"), Faction.UNLIMITED)   ;//Orc Burrow
      f.ModObjectLimit(FourCC("o03U"), Faction.UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC("o03W"), Faction.UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC("o03X"), Faction.UNLIMITED)   ;//Voodoo Lounge
      f.ModObjectLimit(FourCC("o03V"), Faction.UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC("n0AQ"), 6)           ;//Oil Platform
      f.ModObjectLimit(FourCC("h011"), 1)           ;//Artillery

      f.ModObjectLimit(FourCC("o02I"), Faction.UNLIMITED)   ;//Peon
      f.ModObjectLimit(FourCC("n099"), Faction.UNLIMITED)   ;//Ogre
      f.ModObjectLimit(FourCC("h08X"), 8)           ;//sapper
      f.ModObjectLimit(FourCC("h08Y"), Faction.UNLIMITED)          ;//Gunner
      f.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED)   ;//GOBLIN Witch Doctor
      f.ModObjectLimit(FourCC("o04P"), Faction.UNLIMITED)   ;//Mage
      f.ModObjectLimit(FourCC("o04O"), Faction.UNLIMITED)   ;//Alch
      f.ModObjectLimit(FourCC("o04Q"), 6)           ;//Tinker
      f.ModObjectLimit(FourCC("obot"), 12)  	    ;//Transport Ship
      f.ModObjectLimit(FourCC("odes"), 12)  	    ;//Orc Frigate
      f.ModObjectLimit(FourCC("ojgn"), 6)          ;//Juggernaught
      f.ModObjectLimit(FourCC("n062"), 12)          ;//Shredder
      f.ModObjectLimit(FourCC("h08Z"), 5)           ;//Tank
      f.ModObjectLimit(FourCC("h091"), 6)           ;//Zep
      f.ModObjectLimit(FourCC("nzep"), 16)           ;//Trading Zeppelin
      f.ModObjectLimit(FourCC("o04S"), 10)           ;//Trader
      f.ModObjectLimit(FourCC("u028"), 2)           ;//Fuel Tanker

      f.ModObjectLimit(FourCC("O04N"), 1)           ;//Jastor
      f.ModObjectLimit(FourCC("Ntin"), 1)           ;//Gazlowee
      f.ModObjectLimit(FourCC("Nalc"), 1)           ;//Noggenfogger

      f.ModObjectLimit(FourCC("R07L"), Faction.UNLIMITED)   ;//Wizard Training
      f.ModObjectLimit(FourCC("R07M"), Faction.UNLIMITED)   ;//Alchemist Training
      f.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED)   ;//Spiritual Infusion

    }

  }
}
