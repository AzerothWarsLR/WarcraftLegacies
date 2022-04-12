using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class QuelthalasSetup
  {
    public static Faction FactionQuelthalas { get; private set; }


    public static void Setup()
    {
      Faction f;
      FactionQuelthalas =
        new Faction(
          "Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF","ReplaceableTextures\\CommandButtons\\BTNSylvanusWindrunner.blp");
      f = FactionQuelthalas;
      f.Team = TeamSetup.TeamAlliance;
      f.UndefeatedResearch = FourCC("R05U");
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h033"), Faction.UNLIMITED); //Steading
      f.ModObjectLimit(FourCC("h03S"), Faction.UNLIMITED); //Mansion
      f.ModObjectLimit(FourCC("h03T"), Faction.UNLIMITED); //Palace
      f.ModObjectLimit(FourCC("h01H"), Faction.UNLIMITED); //Altar of Prowess
      f.ModObjectLimit(FourCC("h02Y"), Faction.UNLIMITED); //Artisan)s Hall
      f.ModObjectLimit(FourCC("h034"), Faction.UNLIMITED); //Arcane Sanctum (Quel)thalas)
      f.ModObjectLimit(FourCC("h073"), Faction.UNLIMITED); //Scout Tower
      f.ModObjectLimit(FourCC("h074"), Faction.UNLIMITED); //Arcane Tower
      f.ModObjectLimit(FourCC("h075"), Faction.UNLIMITED); //Arcane Tower (Improved)
      f.ModObjectLimit(FourCC("negt"), Faction.UNLIMITED); //High Elven Guard Tower
      f.ModObjectLimit(FourCC("n003"), Faction.UNLIMITED); //High Elven Guard Tower (Improved)
      f.ModObjectLimit(FourCC("h04V"), Faction.UNLIMITED); //Arcane Vault (Elven)
      f.ModObjectLimit(FourCC("nheb"), Faction.UNLIMITED); //Cantonment
      f.ModObjectLimit(FourCC("n0A2"), Faction.UNLIMITED); //Consortium
      f.ModObjectLimit(FourCC("h03J"), Faction.UNLIMITED); //Academy
      f.ModObjectLimit(FourCC("h077"), Faction.UNLIMITED); //Alliance Shipyard
      f.ModObjectLimit(FourCC("nefm"), Faction.UNLIMITED); //Residence

      //Units
      f.ModObjectLimit(FourCC("nbee"), Faction.UNLIMITED); //Elven Worker
      f.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      f.ModObjectLimit(FourCC("hhes"), Faction.UNLIMITED); //Elven Warrior
      f.ModObjectLimit(FourCC("hmpr"), Faction.UNLIMITED); //Priest
      f.ModObjectLimit(FourCC("hsor"), Faction.UNLIMITED); //Sorceress
      f.ModObjectLimit(FourCC("hdhw"), 6); //Dragonhawk Rider
      f.ModObjectLimit(FourCC("nhea"), Faction.UNLIMITED); //Archer
      f.ModObjectLimit(FourCC("e008"), 6); //Elven Ballista
      f.ModObjectLimit(FourCC("n00A"), 6); //Farstrider
      f.ModObjectLimit(FourCC("n063"), 12); //Magus
      f.ModObjectLimit(FourCC("hspt"), Faction.UNLIMITED); //Spell Breaker
      f.ModObjectLimit(FourCC("u00J"), 2); //Arcane Wagon

      //Demi-heroes
      f.ModObjectLimit(FourCC("n075"), 1); //Vareesa
      f.ModObjectLimit(FourCC("Hvwd"), 1); //Sylvanas
      f.ModObjectLimit(FourCC("H00Q"), 1); //Anasterian
      f.ModObjectLimit(FourCC("H098"), 1); //Pathaleone
      f.ModObjectLimit(FourCC("H04F"), 1); //Rommath
      f.ModObjectLimit(FourCC("H02E"), 1); //Lorthemar

      //Upgrades
      f.ModObjectLimit(FourCC("R01S"), Faction.UNLIMITED); //Aimed Shot
      f.ModObjectLimit(FourCC("R00G"), Faction.UNLIMITED); //Feint
      f.ModObjectLimit(FourCC("R01R"), Faction.UNLIMITED); //Improved Bows
      f.ModObjectLimit(FourCC("R029"), Faction.UNLIMITED); //Magus Adept Training
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      f.ModObjectLimit(FourCC("Rhcd"), Faction.UNLIMITED); //Cloud
      f.ModObjectLimit(FourCC("Rhss"), Faction.UNLIMITED); //Control Magic
      f.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      f.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      f.ModObjectLimit(FourCC("Rhpt"), Faction.UNLIMITED); //Priest Adept Training
      f.ModObjectLimit(FourCC("Rhst"), Faction.UNLIMITED); //Sorceress Adept Training

      //Masteries
      f.ModObjectLimit(FourCC("R01A"), Faction.UNLIMITED); //Arcane Empowerment
      f.ModObjectLimit(FourCC("R00T"), Faction.UNLIMITED); //Archery Mastery
      f.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Blood Elf Mastery

      //Paths
      f.ModObjectLimit(FourCC("R046"), Faction.UNLIMITED); //Quel)thelas Full Mobilization
      f.ModObjectLimit(FourCC("R04U"), Faction.UNLIMITED); //Solo Path
    }
  }
}