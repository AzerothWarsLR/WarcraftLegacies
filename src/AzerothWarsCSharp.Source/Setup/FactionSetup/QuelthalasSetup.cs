using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class QuelthalasSetup{

  
    Faction FACTION_QUELTHALAS
  

    public static void Setup( ){
      Faction f;
      FACTION_QUELTHALAS = Faction.create("QuelFourCC("thalas", PLAYER_COLOR_CYAN, "|C0000FFFF","ReplaceableTextures\\CommandButtons\\BTNSylvanusWindrunner.blp"");
      f = FACTION_QUELTHALAS;
      f.Team = TEAM_ALLIANCE;
      f.UndefeatedResearch = FourCC("R05U");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h033"), UNLIMITED)   ;//Steading
      f.ModObjectLimit(FourCC("h03S"), UNLIMITED)   ;//Mansion
      f.ModObjectLimit(FourCC("h03T"), UNLIMITED)   ;//Palace
      f.ModObjectLimit(FourCC("h01H"), UNLIMITED)   ;//Altar of Prowess
      f.ModObjectLimit(FourCC("h02Y"), UNLIMITED)   ;//Artisan)s Hall
      f.ModObjectLimit(FourCC("h034"), UNLIMITED)   ;//Arcane Sanctum (Quel)thalas)
      f.ModObjectLimit(FourCC("h073"), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h074"), UNLIMITED)   ;//Arcane Tower
      f.ModObjectLimit(FourCC("h075"), UNLIMITED)   ;//Arcane Tower (Improved)
      f.ModObjectLimit(FourCC("negt"), UNLIMITED)   ;//High Elven Guard Tower
      f.ModObjectLimit(FourCC("n003"), UNLIMITED)   ;//High Elven Guard Tower (Improved)
      f.ModObjectLimit(FourCC("h04V"), UNLIMITED)   ;//Arcane Vault (Elven)
      f.ModObjectLimit(FourCC("nheb"), UNLIMITED)   ;//Cantonment
      f.ModObjectLimit(FourCC("n0A2"), UNLIMITED)   ;//Consortium
      f.ModObjectLimit(FourCC("h03J"), UNLIMITED)   ;//Academy
      f.ModObjectLimit(FourCC("h077"), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC("nefm"), UNLIMITED)   ;//Residence

      //Units
      f.ModObjectLimit(FourCC("nbee"), UNLIMITED)   ;//Elven Worker
      f.ModObjectLimit(FourCC("hbot"), 12)   	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12)  	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("hhes"), UNLIMITED)   ;//Elven Warrior
      f.ModObjectLimit(FourCC("hmpr"), UNLIMITED)   ;//Priest
      f.ModObjectLimit(FourCC("hsor"), UNLIMITED)   ;//Sorceress
      f.ModObjectLimit(FourCC("hdhw"), 6)           ;//Dragonhawk Rider
      f.ModObjectLimit(FourCC("nhea"), UNLIMITED)   ;//Archer
      f.ModObjectLimit(FourCC("e008"), 6)           ;//Elven Ballista
      f.ModObjectLimit(FourCC("n00A"), 6)           ;//Farstrider
      f.ModObjectLimit(FourCC("n063"), 12)          ;//Magus
      f.ModObjectLimit(FourCC("hspt"), UNLIMITED)   ;//Spell Breaker
      f.ModObjectLimit(FourCC("u00J"), 2)           ;//Arcane Wagon

      //Demi-heroes
      f.ModObjectLimit(FourCC("n075"), 1)           ;//Vareesa
      f.ModObjectLimit(FourCC("Hvwd"), 1)           ;//Sylvanas
      f.ModObjectLimit(FourCC("H00Q"), 1)           ;//Anasterian
      f.ModObjectLimit(FourCC("H098"), 1)           ;//Pathaleone
      f.ModObjectLimit(FourCC("H04F"), 1)           ;//Rommath
      f.ModObjectLimit(FourCC("H02E"), 1)           ;//Lorthemar

      //Upgrades
      f.ModObjectLimit(FourCC("R01S"), UNLIMITED)   ;//Aimed Shot
      f.ModObjectLimit(FourCC("R00G"), UNLIMITED)   ;//Feint
      f.ModObjectLimit(FourCC("R01R"), UNLIMITED)   ;//Improved Bows
      f.ModObjectLimit(FourCC("R029"), UNLIMITED)   ;//Magus Adept Training
      f.ModObjectLimit(FourCC("R00K"), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("Rhcd"), UNLIMITED)   ;//Cloud
      f.ModObjectLimit(FourCC("Rhss"), UNLIMITED)   ;//Control Magic
      f.ModObjectLimit(FourCC("Rhlh"), UNLIMITED)   ;//Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC("Rhse"), UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC("Rhpt"), UNLIMITED)   ;//Priest Adept Training
      f.ModObjectLimit(FourCC("Rhst"), UNLIMITED)   ;//Sorceress Adept Training

      //Masteries
      f.ModObjectLimit(FourCC("R01A"), UNLIMITED)   ;//Arcane Empowerment
      f.ModObjectLimit(FourCC("R00T"), UNLIMITED)   ;//Archery Mastery
      f.ModObjectLimit(FourCC("R00H"), UNLIMITED)   ;//Blood Elf Mastery

      //Paths
      f.ModObjectLimit(FourCC("R046"), UNLIMITED)   ;//Quel)thelas Full Mobilization
      f.ModObjectLimit(FourCC("R04U"), UNLIMITED)   ;//Solo Path
    }

  }
}
