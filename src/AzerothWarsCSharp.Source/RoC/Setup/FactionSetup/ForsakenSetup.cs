public class ForsakenSetup{

  
    Faction FACTION_FORSAKEN
  

  public static void OnInit( ){
    Faction f;

    FACTION_FORSAKEN = Faction.create("Cult", PLAYER_COLOR_LIGHT_BLUE, "|cff8080ff","ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp");
    f = FACTION_FORSAKEN;
    f.Team = TEAM_LEGION;
    f.StartingGold = 0;
    f.StartingLumber = 100;

    //Buildings
    f.ModObjectLimit(FourCC(h089), UNLIMITED)   ;//Necropolis
    f.ModObjectLimit(FourCC(h08A), UNLIMITED)   ;//Halls of the Dead
    f.ModObjectLimit(FourCC(h08B), UNLIMITED)   ;//Black Citadel
    f.ModObjectLimit(FourCC(h08C), UNLIMITED)   ;//Ziggurat
    f.ModObjectLimit(FourCC(h08D), UNLIMITED)   ;//Spirit Tower
    f.ModObjectLimit(FourCC(h08E), UNLIMITED)   ;//Nerubian Tower
    f.ModObjectLimit(FourCC(u010), UNLIMITED)   ;//Altar of Darkness
    f.ModObjectLimit(FourCC(u011), UNLIMITED)   ;//Crypt
    f.ModObjectLimit(FourCC(u01J), UNLIMITED)   ;//Graveyard
    f.ModObjectLimit(FourCC(u016), UNLIMITED)   ;//Slaughterhouse
    f.ModObjectLimit(FourCC(u01W), UNLIMITED)   ;//Royal Sepulcur
    f.ModObjectLimit(FourCC(u014), UNLIMITED)   ;//Temple of the Damned
    f.ModObjectLimit(FourCC(u017), UNLIMITED)   ;//Tomb of Relics
    f.ModObjectLimit(FourCC(u01A), UNLIMITED)   ;//Undead Shipyard
    f.ModObjectLimit(FourCC(h08F), UNLIMITED)   ;//Improved Spirit Tower

    //Units
    f.ModObjectLimit(FourCC(u01K), UNLIMITED)   ;//Acolyte
    f.ModObjectLimit(FourCC(h08O), UNLIMITED)   ;//Ghoul
    f.ModObjectLimit(FourCC(h08N), UNLIMITED)   ;//Abomination
    f.ModObjectLimit(FourCC(u01P), 6)           ;//Plague Catapult
    f.ModObjectLimit(FourCC(n07S), UNLIMITED)   ;//Deadeye
    f.ModObjectLimit(FourCC(h08P), UNLIMITED)   ;//Sorceress
    f.ModObjectLimit(FourCC(u01R), UNLIMITED)   ;//Apothecary

    f.ModObjectLimit(FourCC(u02G), 12) 	    ;//Undercity Guardian
    f.ModObjectLimit(FourCC(n07V), 6)           ;//Elder Banshee
    f.ModObjectLimit(FourCC(o05H), 8)           ;//PlagueFlyer
    f.ModObjectLimit(FourCC(n0BY), 6)           ;//dread knight
    f.ModObjectLimit(FourCC(u01V), 2)           ;//Valyr
    f.ModObjectLimit(FourCC(ubot), 12)	    ;//Undead Transport Ship
    f.ModObjectLimit(FourCC(udes), 12) 	    ;//Undead Frigate
    f.ModObjectLimit(FourCC(uubs), 6)          ;//Undead Battleship

    f.ModObjectLimit(FourCC(U01O), 1)        ;//Putress
    f.ModObjectLimit(FourCC(Usyl), 1)        ;//Sylvanas
    f.ModObjectLimit(FourCC(U02I), 1)        ;//Farenell

    //Upgrades
    f.ModObjectLimit(FourCC(Ruba), UNLIMITED)   ;//Banshee Adept Training
    f.ModObjectLimit(FourCC(R05C), UNLIMITED)   ;//Banshee Adept Training
    f.ModObjectLimit(FourCC(R051), UNLIMITED)   ;//Apotechary Training
    f.ModObjectLimit(FourCC(R02X), UNLIMITED)   ;// Open Scholomance
    f.ModObjectLimit(FourCC(R02A), UNLIMITED)   ;//Chaos Infusion
  }

}
