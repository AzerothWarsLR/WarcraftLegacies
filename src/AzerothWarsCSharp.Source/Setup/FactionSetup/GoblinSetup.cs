using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class GoblinSetup
  {
    public static Faction factionGoblin;

    public static void Setup()
    {
      factionGoblin = new Faction("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080",
        "ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        IntroText = @"You are playing as the industrious |cff808080Bilgewater Cartel|r.

Early on you must rely on Traders for resources. 
Build Trading Zeppelins for Lumber and Traders for Gold.

Some of your more advanced units and buildings require Fuel. Use the Kezan Oil Supply to discover and build new Oil Platforms and start accumulating it. Your global supply is indicated by the mana of the Kezan Oil Supply.

The Cataclysm is coming, and when it does your Trading Center and Traders will be destroyed. 
Use your resources to raise an army strong enough to take land elsewhere."
      };

      factionGoblin.ModObjectLimit(FourCC("o03L"), Faction.UNLIMITED); //Great Hall
      factionGoblin.ModObjectLimit(FourCC("o03M"), Faction.UNLIMITED); //Stronghold
      factionGoblin.ModObjectLimit(FourCC("o03N"), Faction.UNLIMITED); //Fortress
      factionGoblin.ModObjectLimit(FourCC("o03O"), Faction.UNLIMITED); //Altar of Storms
      factionGoblin.ModObjectLimit(FourCC("o03P"), Faction.UNLIMITED); //Barracks
      factionGoblin.ModObjectLimit(FourCC("o03Q"), Faction.UNLIMITED); //War Mill
      factionGoblin.ModObjectLimit(FourCC("o03S"), Faction.UNLIMITED); //Tauren Totem
      factionGoblin.ModObjectLimit(FourCC("o01M"), Faction.UNLIMITED); //Spirit Lodge
      factionGoblin.ModObjectLimit(FourCC("o03T"), Faction.UNLIMITED); //Orc Burrow
      factionGoblin.ModObjectLimit(FourCC("o03U"), Faction.UNLIMITED); //Watch Tower
      factionGoblin.ModObjectLimit(FourCC("o03W"), Faction.UNLIMITED); //Improved Watch Tower
      factionGoblin.ModObjectLimit(FourCC("o03X"), Faction.UNLIMITED); //Voodoo Lounge
      factionGoblin.ModObjectLimit(FourCC("o03V"), Faction.UNLIMITED); //Shipyard
      factionGoblin.ModObjectLimit(FourCC("n0AQ"), 6); //Oil Platform
      factionGoblin.ModObjectLimit(FourCC("h011"), 1); //Artillery

      factionGoblin.ModObjectLimit(FourCC("o02I"), Faction.UNLIMITED); //Peon
      factionGoblin.ModObjectLimit(FourCC("n099"), Faction.UNLIMITED); //Ogre
      factionGoblin.ModObjectLimit(FourCC("h08X"), 8); //sapper
      factionGoblin.ModObjectLimit(FourCC("h08Y"), Faction.UNLIMITED); //Gunner
      factionGoblin.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //GOBLIN Witch Doctor
      factionGoblin.ModObjectLimit(FourCC("o04P"), Faction.UNLIMITED); //Mage
      factionGoblin.ModObjectLimit(FourCC("o04O"), Faction.UNLIMITED); //Alch
      factionGoblin.ModObjectLimit(FourCC("o04Q"), 6); //Tinker
      factionGoblin.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      factionGoblin.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      factionGoblin.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      factionGoblin.ModObjectLimit(FourCC("n062"), 12); //Shredder
      factionGoblin.ModObjectLimit(FourCC("h08Z"), 5); //Tank
      factionGoblin.ModObjectLimit(FourCC("h091"), 6); //Zep
      factionGoblin.ModObjectLimit(FourCC("nzep"), 16); //Trading Zeppelin
      factionGoblin.ModObjectLimit(FourCC("o04S"), 10); //Trader
      factionGoblin.ModObjectLimit(FourCC("u028"), 2); //Fuel Tanker

      factionGoblin.ModObjectLimit(Constants.UNIT_O04N_TRADE_PRINCE_OF_THE_BILGEWATER_CARTEL_GOBLIN, 1);
      factionGoblin.ModObjectLimit(Constants.UNIT_NTIN_CHIEF_ENGINEER_GOBLIN, 1);
      factionGoblin.ModObjectLimit(Constants.UNIT_NALC_BARON_OF_GADGETZAN_GOBLIN, 1);

      factionGoblin.ModObjectLimit(Constants.UPGRADE_R07L_WIZARD_MASTER_TRAINING_GOBLIN, Faction.UNLIMITED);
      factionGoblin.ModObjectLimit(Constants.UPGRADE_R07M_ALCHEMIST_MASTER_TRAINING_GOBLIN, Faction.UNLIMITED);
      factionGoblin.ModObjectLimit(Constants.UPGRADE_R023_SPIRITUAL_INFUSION_WARSONG_FROSTWOLF_FEL_HORDE, Faction.UNLIMITED);

      var oilPower = new OilPower
      {
        Name = "Oil Tycoon",
        IconName = "OilStation"
      };
      factionGoblin.AddPower(oilPower);

      FactionManager.Register(factionGoblin);
    }
  }
}