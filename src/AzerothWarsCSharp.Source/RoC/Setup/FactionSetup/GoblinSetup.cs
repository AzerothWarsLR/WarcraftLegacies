public class GoblinSetup{

  
    Faction FACTION_GOBLIN
  

  public static void OnInit( ){
    Faction f;
    FACTION_GOBLIN = Faction.create("Bilgewater", PLAYER_COLOR_LIGHT_GRAY, "|cff808080","ReplaceableTextures\\CommandButtons\\BTNHeroTinker.blp");
    f = FACTION_GOBLIN;
    f.Team = TEAM_HORDE;
    f.StartingGold = 150;
    f.StartingLumber = 500;

    f.ModObjectLimit(FourCC(o03L), UNLIMITED)   ;//Great Hall
    f.ModObjectLimit(FourCC(o03M), UNLIMITED)   ;//Stronghold
    f.ModObjectLimit(FourCC(o03N), UNLIMITED)   ;//Fortress
    f.ModObjectLimit(FourCC(o03O), UNLIMITED)   ;//Altar of Storms
    f.ModObjectLimit(FourCC(o03P), UNLIMITED)   ;//Barracks
    f.ModObjectLimit(FourCC(o03Q), UNLIMITED)   ;//War Mill
    f.ModObjectLimit(FourCC(o03S), UNLIMITED)   ;//Tauren Totem
    f.ModObjectLimit(FourCC(o01M), UNLIMITED)   ;//Spirit Lodge
    f.ModObjectLimit(FourCC(o03T), UNLIMITED)   ;//Orc Burrow
    f.ModObjectLimit(FourCC(o03U), UNLIMITED)   ;//Watch Tower
    f.ModObjectLimit(FourCC(o03W), UNLIMITED)   ;//Improved Watch Tower
    f.ModObjectLimit(FourCC(o03X), UNLIMITED)   ;//Voodoo Lounge
    f.ModObjectLimit(FourCC(o03V), UNLIMITED)   ;//Shipyard
    f.ModObjectLimit(FourCC(n0AQ), 6)           ;//Oil Platform
    f.ModObjectLimit(FourCC(h011), 1)           ;//Artillery

    f.ModObjectLimit(FourCC(o02I), UNLIMITED)   ;//Peon
    f.ModObjectLimit(FourCC(n099), UNLIMITED)   ;//Ogre
    f.ModObjectLimit(FourCC(h08X), 8)           ;//sapper
    f.ModObjectLimit(FourCC(h08Y), UNLIMITED)          ;//Gunner
    f.ModObjectLimit(FourCC(odoc), UNLIMITED)   ;//GOBLIN Witch Doctor
    f.ModObjectLimit(FourCC(o04P), UNLIMITED)   ;//Mage
    f.ModObjectLimit(FourCC(o04O), UNLIMITED)   ;//Alch
    f.ModObjectLimit(FourCC(o04Q), 6)           ;//Tinker
    f.ModObjectLimit(FourCC(obot), 12)  	    ;//Transport Ship
    f.ModObjectLimit(FourCC(odes), 12)  	    ;//Orc Frigate
    f.ModObjectLimit(FourCC(ojgn), 6)          ;//Juggernaught
    f.ModObjectLimit(FourCC(n062), 12)          ;//Shredder
    f.ModObjectLimit(FourCC(h08Z), 5)           ;//Tank
    f.ModObjectLimit(FourCC(h091), 6)           ;//Zep
    f.ModObjectLimit(FourCC(nzep), 16)           ;//Trading Zeppelin
    f.ModObjectLimit(FourCC(o04S), 10)           ;//Trader
    f.ModObjectLimit(FourCC(u028), 2)           ;//Fuel Tanker

    f.ModObjectLimit(FourCC(O04N), 1)           ;//Jastor
    f.ModObjectLimit(FourCC(Ntin), 1)           ;//Gazlowee
    f.ModObjectLimit(FourCC(Nalc), 1)           ;//Noggenfogger

    f.ModObjectLimit(FourCC(R07L), UNLIMITED)   ;//Wizard Training
    f.ModObjectLimit(FourCC(R07M), UNLIMITED)   ;//Alchemist Training
    f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion

  }

}
