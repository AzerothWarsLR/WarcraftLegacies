
public class DraeneiSetup{

  
    Faction FACTION_DRAENEI
  

  public static void OnInit( ){
    Faction f;

    FACTION_DRAENEI = Faction.create("The Exodar", PLAYER_COLOR_NAVY, "|cff000080","ReplaceableTextures\\CommandButtons\\BTNBOSSVelen.blp");
    f = FACTION_DRAENEI;
    f.Team = TEAM_NIGHT_ELVES;
    f.UndefeatedResearch = FourCC(R06E);
    f.StartingGold = 150;
    f.StartingLumber = 500;

    f.ModObjectLimit(FourCC(o02P), UNLIMITED)   ;//Crystal Hall
    f.ModObjectLimit(FourCC(o050), UNLIMITED)   ;//Metropolis
    f.ModObjectLimit(FourCC(o051), UNLIMITED)   ;//Divine Citadel
    f.ModObjectLimit(FourCC(o058), UNLIMITED)   ;//Altar of Light
    f.ModObjectLimit(FourCC(o052), UNLIMITED)   ;//Ceremonial Altar
    f.ModObjectLimit(FourCC(o053), UNLIMITED)   ;//Smithery
    f.ModObjectLimit(FourCC(o054), UNLIMITED)   ;//Astral Sanctum
    f.ModObjectLimit(FourCC(o055), UNLIMITED)   ;//Crystal Spire
    f.ModObjectLimit(FourCC(o056), UNLIMITED)   ;//Arcane Well
    f.ModObjectLimit(FourCC(o057), UNLIMITED)   ;//Vaults of Relic
    f.ModObjectLimit(FourCC(u00U), UNLIMITED)   ;//Crystal Protector
    f.ModObjectLimit(FourCC(u01Q), UNLIMITED)   ;//Crystal Protector improved
    f.ModObjectLimit(FourCC(o059), UNLIMITED)   ;//Improved Ancient Protector

    f.ModObjectLimit(FourCC(o05A), UNLIMITED)   ;//Wisp
    f.ModObjectLimit(FourCC(o05B), UNLIMITED)   ;//Defender
    f.ModObjectLimit(FourCC(h09T), UNLIMITED)   ;//Rangari
    f.ModObjectLimit(FourCC(e01K), 3)           ;//Polybolos
    f.ModObjectLimit(FourCC(o05D), UNLIMITED)   ;//Elementalist
    f.ModObjectLimit(FourCC(o05C), UNLIMITED)   ;//Luminarch
    f.ModObjectLimit(FourCC(h09R), 6)           ;//Vindicator
    f.ModObjectLimit(FourCC(nmdr), UNLIMITED)   ;//Elekk
    f.ModObjectLimit(FourCC(h09U), 4)           ;//Elekk Knight
    f.ModObjectLimit(FourCC(u02H), 6)           ;//Nether Ray

    f.ModObjectLimit(FourCC(etrs), 12)   	    ;//Night Elf Transport Ship
    f.ModObjectLimit(FourCC(edes), 12) 	      ;//Night Elf Frigate
    f.ModObjectLimit(FourCC(ebsh), 6)          ;//Night Elf Battleship

    f.ModObjectLimit(FourCC(H09S), 1)           ;//Maraad
    f.ModObjectLimit(FourCC(E01I), 1)           ;//Velen
    f.ModObjectLimit(FourCC(E01J), 1)           ;//Nobundo

    f.ModObjectLimit(FourCC(R023), UNLIMITED)   ;//Spiritual Infusion
    f.ModObjectLimit(FourCC(R078), UNLIMITED)   ;//Elementalist training
    f.ModObjectLimit(FourCC(R07C), UNLIMITED)   ;//Luminarch training

  }

}
