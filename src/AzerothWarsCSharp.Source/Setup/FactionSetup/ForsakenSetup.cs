using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class ForsakenSetup{

  
    Faction FACTION_FORSAKEN
  

    public static void Setup( ){
      Faction f;

      FACTION_FORSAKEN = Faction.create("Cult", PLAYER_COLOR_LIGHT_BLUE, "|cff8080ff","ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp");
      f = FACTION_FORSAKEN;
      f.Team = TeamSetup.TeamLegion;
      f.StartingGold = 0;
      f.StartingLumber = 100;

      //Buildings
      f.ModObjectLimit(FourCC("h089"), Faction.UNLIMITED)   ;//Necropolis
      f.ModObjectLimit(FourCC("h08A"), Faction.UNLIMITED)   ;//Halls of the Dead
      f.ModObjectLimit(FourCC("h08B"), Faction.UNLIMITED)   ;//Black Citadel
      f.ModObjectLimit(FourCC("h08C"), Faction.UNLIMITED)   ;//Ziggurat
      f.ModObjectLimit(FourCC("h08D"), Faction.UNLIMITED)   ;//Spirit Tower
      f.ModObjectLimit(FourCC("h08E"), Faction.UNLIMITED)   ;//Nerubian Tower
      f.ModObjectLimit(FourCC("u010"), Faction.UNLIMITED)   ;//Altar of Darkness
      f.ModObjectLimit(FourCC("u011"), Faction.UNLIMITED)   ;//Crypt
      f.ModObjectLimit(FourCC("u01J"), Faction.UNLIMITED)   ;//Graveyard
      f.ModObjectLimit(FourCC("u016"), Faction.UNLIMITED)   ;//Slaughterhouse
      f.ModObjectLimit(FourCC("u01W"), Faction.UNLIMITED)   ;//Royal Sepulcur
      f.ModObjectLimit(FourCC("u014"), Faction.UNLIMITED)   ;//Temple of the Damned
      f.ModObjectLimit(FourCC("u017"), Faction.UNLIMITED)   ;//Tomb of Relics
      f.ModObjectLimit(FourCC("u01A"), Faction.UNLIMITED)   ;//Undead Shipyard
      f.ModObjectLimit(FourCC("h08F"), Faction.UNLIMITED)   ;//Improved Spirit Tower

      //Units
      f.ModObjectLimit(FourCC("u01K"), Faction.UNLIMITED)   ;//Acolyte
      f.ModObjectLimit(FourCC("h08O"), Faction.UNLIMITED)   ;//Ghoul
      f.ModObjectLimit(FourCC("h08N"), Faction.UNLIMITED)   ;//Abomination
      f.ModObjectLimit(FourCC("u01P"), 6)           ;//Plague Catapult
      f.ModObjectLimit(FourCC("n07S"), Faction.UNLIMITED)   ;//Deadeye
      f.ModObjectLimit(FourCC("h08P"), Faction.UNLIMITED)   ;//Sorceress
      f.ModObjectLimit(FourCC("u01R"), Faction.UNLIMITED)   ;//Apothecary

      f.ModObjectLimit(FourCC("u02G"), 12) 	    ;//Undercity Guardian
      f.ModObjectLimit(FourCC("n07V"), 6)           ;//Elder Banshee
      f.ModObjectLimit(FourCC("o05H"), 8)           ;//PlagueFlyer
      f.ModObjectLimit(FourCC("n0BY"), 6)           ;//dread knight
      f.ModObjectLimit(FourCC("u01V"), 2)           ;//Valyr
      f.ModObjectLimit(FourCC("ubot"), 12)	    ;//Undead Transport Ship
      f.ModObjectLimit(FourCC("udes"), 12) 	    ;//Undead Frigate
      f.ModObjectLimit(FourCC("uubs"), 6)          ;//Undead Battleship

      f.ModObjectLimit(FourCC("U01O"), 1)        ;//Putress
      f.ModObjectLimit(FourCC("Usyl"), 1)        ;//Sylvanas
      f.ModObjectLimit(FourCC("U02I"), 1)        ;//Farenell

      //Upgrades
      f.ModObjectLimit(FourCC("Ruba"), Faction.UNLIMITED)   ;//Banshee Adept Training
      f.ModObjectLimit(FourCC("R05C"), Faction.UNLIMITED)   ;//Banshee Adept Training
      f.ModObjectLimit(FourCC("R051"), Faction.UNLIMITED)   ;//Apotechary Training
      f.ModObjectLimit(FourCC("R02X"), Faction.UNLIMITED)   ;// Open Scholomance
      f.ModObjectLimit(FourCC("R02A"), Faction.UNLIMITED)   ;//Chaos Infusion
    }

  }
}
