using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class GoblinSetup
  {
    public static Faction? Goblin { get; private set; }

    public static void Setup()
    {
      Goblin = new Faction("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080",
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

      Goblin.ModObjectLimit(FourCC("o03L"), Faction.UNLIMITED); //Great Hall
      Goblin.ModObjectLimit(FourCC("o03M"), Faction.UNLIMITED); //Stronghold
      Goblin.ModObjectLimit(FourCC("o03N"), Faction.UNLIMITED); //Fortress
      Goblin.ModObjectLimit(FourCC("o03O"), Faction.UNLIMITED); //Altar of Storms
      Goblin.ModObjectLimit(FourCC("o03P"), Faction.UNLIMITED); //Barracks
      Goblin.ModObjectLimit(FourCC("o03Q"), Faction.UNLIMITED); //War Mill
      Goblin.ModObjectLimit(FourCC("o03S"), Faction.UNLIMITED); //Tauren Totem
      Goblin.ModObjectLimit(FourCC("o01M"), Faction.UNLIMITED); //Spirit Lodge
      Goblin.ModObjectLimit(FourCC("o03T"), Faction.UNLIMITED); //Orc Burrow
      Goblin.ModObjectLimit(FourCC("o03U"), Faction.UNLIMITED); //Watch Tower
      Goblin.ModObjectLimit(FourCC("o03W"), Faction.UNLIMITED); //Improved Watch Tower
      Goblin.ModObjectLimit(FourCC("o03X"), Faction.UNLIMITED); //Voodoo Lounge
      Goblin.ModObjectLimit(FourCC("o03V"), Faction.UNLIMITED); //Shipyard
      Goblin.ModObjectLimit(FourCC("n0AQ"), 6); //Oil Platform
      Goblin.ModObjectLimit(FourCC("h011"), 1); //Artillery

      Goblin.ModObjectLimit(FourCC("o02I"), Faction.UNLIMITED); //Peon
      Goblin.ModObjectLimit(FourCC("n099"), Faction.UNLIMITED); //Ogre
      Goblin.ModObjectLimit(FourCC("h08X"), 8); //sapper
      Goblin.ModObjectLimit(FourCC("h08Y"), Faction.UNLIMITED); //Gunner
      Goblin.ModObjectLimit(FourCC("odoc"), Faction.UNLIMITED); //GOBLIN Witch Doctor
      Goblin.ModObjectLimit(FourCC("o04P"), Faction.UNLIMITED); //Mage
      Goblin.ModObjectLimit(FourCC("o04O"), Faction.UNLIMITED); //Alch
      Goblin.ModObjectLimit(FourCC("o04Q"), 6); //Tinker
      Goblin.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      Goblin.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      Goblin.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught
      Goblin.ModObjectLimit(FourCC("n062"), 12); //Shredder
      Goblin.ModObjectLimit(FourCC("h08Z"), 5); //Tank
      Goblin.ModObjectLimit(FourCC("h091"), 6); //Zep
      Goblin.ModObjectLimit(FourCC("nzep"), 16); //Trading Zeppelin
      Goblin.ModObjectLimit(FourCC("o04S"), 10); //Trader
      Goblin.ModObjectLimit(FourCC("u028"), 2); //Fuel Tanker

      Goblin.ModObjectLimit(Constants.UNIT_O04N_TRADE_PRINCE_OF_THE_BILGEWATER_CARTEL_GOBLIN, 1);
      Goblin.ModObjectLimit(Constants.UNIT_NTIN_CHIEF_ENGINEER_GOBLIN, 1);
      Goblin.ModObjectLimit(Constants.UNIT_NALC_BARON_OF_GADGETZAN_GOBLIN, 1);

      Goblin.ModObjectLimit(Constants.UPGRADE_R07L_WIZARD_MASTER_TRAINING_GOBLIN, Faction.UNLIMITED);
      Goblin.ModObjectLimit(Constants.UPGRADE_R07M_ALCHEMIST_MASTER_TRAINING_GOBLIN, Faction.UNLIMITED);
      Goblin.ModObjectLimit(Constants.UPGRADE_R023_SPIRITUAL_INFUSION_WARSONG_FROSTWOLF_FEL_HORDE, Faction.UNLIMITED);

      var oilPower = new OilPower
      {
        Name = "Oil Tycoon",
        IconName = "OilStation"
      };
      Goblin.AddPower(oilPower);

      FactionManager.Register(Goblin);
    }
  }
}