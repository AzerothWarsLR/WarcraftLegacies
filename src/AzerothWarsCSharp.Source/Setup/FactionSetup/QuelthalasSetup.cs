using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class QuelthalasSetup
  {
    public static Faction FactionQuelthalas { get; private set; }
    
    public static void Setup()
    {
      FactionQuelthalas =
        new Faction(
          "Quel'thalas", PLAYER_COLOR_CYAN, "|C0000FFFF",
          "ReplaceableTextures\\CommandButtons\\BTNSylvanusWindrunner.blp")
        {
          UndefeatedResearch = FourCC("R05U"),
          StartingGold = 150,
          StartingLumber = 500,
          CinematicMusic = "BloodElfTheme",
          IntroText = @"You are playing as the mystical |cff32e1e1Kingdom of Quel'thalas|r.

          The Trolls of Zul'Aman have cut you off from Silvermoon City, and are preparing attacks on your base,
          Train soldiers to repel the attack, then gather enough strength to besiege Zul'Aman and take the head of Zul'jin.

          The Plague of Undeath is coming, and your allies to the South will need your help with the Undead soon, be ready to join them as once you have secured Silvermoon and dealt with the Troll threat."
        };

      //Structures
      FactionQuelthalas.ModObjectLimit(FourCC("h033"), Faction.UNLIMITED); //Steading
      FactionQuelthalas.ModObjectLimit(FourCC("h03S"), Faction.UNLIMITED); //Mansion
      FactionQuelthalas.ModObjectLimit(FourCC("h03T"), Faction.UNLIMITED); //Palace
      FactionQuelthalas.ModObjectLimit(FourCC("h01H"), Faction.UNLIMITED); //Altar of Prowess
      FactionQuelthalas.ModObjectLimit(FourCC("h02Y"), Faction.UNLIMITED); //Artisan)s Hall
      FactionQuelthalas.ModObjectLimit(FourCC("h034"), Faction.UNLIMITED); //Arcane Sanctum (Quel)thalas)
      FactionQuelthalas.ModObjectLimit(FourCC("h073"), Faction.UNLIMITED); //Scout Tower
      FactionQuelthalas.ModObjectLimit(FourCC("h074"), Faction.UNLIMITED); //Arcane Tower
      FactionQuelthalas.ModObjectLimit(FourCC("h075"), Faction.UNLIMITED); //Arcane Tower (Improved)
      FactionQuelthalas.ModObjectLimit(FourCC("negt"), Faction.UNLIMITED); //High Elven Guard Tower
      FactionQuelthalas.ModObjectLimit(FourCC("n003"), Faction.UNLIMITED); //High Elven Guard Tower (Improved)
      FactionQuelthalas.ModObjectLimit(FourCC("h04V"), Faction.UNLIMITED); //Arcane Vault (Elven)
      FactionQuelthalas.ModObjectLimit(FourCC("nheb"), Faction.UNLIMITED); //Cantonment
      FactionQuelthalas.ModObjectLimit(FourCC("n0A2"), Faction.UNLIMITED); //Consortium
      FactionQuelthalas.ModObjectLimit(FourCC("h03J"), Faction.UNLIMITED); //Academy
      FactionQuelthalas.ModObjectLimit(FourCC("h077"), Faction.UNLIMITED); //Alliance Shipyard
      FactionQuelthalas.ModObjectLimit(FourCC("nefm"), Faction.UNLIMITED); //Residence

      //Units
      FactionQuelthalas.ModObjectLimit(FourCC("nbee"), Faction.UNLIMITED); //Elven Worker
      FactionQuelthalas.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FactionQuelthalas.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FactionQuelthalas.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FactionQuelthalas.ModObjectLimit(FourCC("hhes"), Faction.UNLIMITED); //Elven Warrior
      FactionQuelthalas.ModObjectLimit(FourCC("hmpr"), Faction.UNLIMITED); //Priest
      FactionQuelthalas.ModObjectLimit(FourCC("hsor"), Faction.UNLIMITED); //Sorceress
      FactionQuelthalas.ModObjectLimit(FourCC("hdhw"), 6); //Dragonhawk Rider
      FactionQuelthalas.ModObjectLimit(FourCC("nhea"), Faction.UNLIMITED); //Archer
      FactionQuelthalas.ModObjectLimit(FourCC("e008"), 6); //Elven Ballista
      FactionQuelthalas.ModObjectLimit(FourCC("n00A"), 6); //Farstrider
      FactionQuelthalas.ModObjectLimit(FourCC("n063"), 12); //Magus
      FactionQuelthalas.ModObjectLimit(FourCC("hspt"), Faction.UNLIMITED); //Spell Breaker
      FactionQuelthalas.ModObjectLimit(FourCC("u00J"), 2); //Arcane Wagon

      //Demi-heroes
      FactionQuelthalas.ModObjectLimit(FourCC("n075"), 1); //Vareesa
      FactionQuelthalas.ModObjectLimit(FourCC("Hvwd"), 1); //Sylvanas
      FactionQuelthalas.ModObjectLimit(FourCC("H00Q"), 1); //Anasterian
      FactionQuelthalas.ModObjectLimit(FourCC("H098"), 1); //Pathaleone
      FactionQuelthalas.ModObjectLimit(FourCC("H04F"), 1); //Rommath
      FactionQuelthalas.ModObjectLimit(FourCC("H02E"), 1); //Lorthemar

      //Upgrades
      FactionQuelthalas.ModObjectLimit(FourCC("R01S"), Faction.UNLIMITED); //Aimed Shot
      FactionQuelthalas.ModObjectLimit(FourCC("R00G"), Faction.UNLIMITED); //Feint
      FactionQuelthalas.ModObjectLimit(FourCC("R01R"), Faction.UNLIMITED); //Improved Bows
      FactionQuelthalas.ModObjectLimit(FourCC("R029"), Faction.UNLIMITED); //Magus Adept Training
      FactionQuelthalas.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      FactionQuelthalas.ModObjectLimit(FourCC("Rhcd"), Faction.UNLIMITED); //Cloud
      FactionQuelthalas.ModObjectLimit(FourCC("Rhss"), Faction.UNLIMITED); //Control Magic
      FactionQuelthalas.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FactionQuelthalas.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      FactionQuelthalas.ModObjectLimit(FourCC("Rhse"), Faction.UNLIMITED); //Magic Sentry
      FactionQuelthalas.ModObjectLimit(FourCC("Rhpt"), Faction.UNLIMITED); //Priest Adept Training
      FactionQuelthalas.ModObjectLimit(FourCC("Rhst"), Faction.UNLIMITED); //Sorceress Adept Training

      //Masteries
      FactionQuelthalas.ModObjectLimit(FourCC("R01A"), Faction.UNLIMITED); //Arcane Empowerment
      FactionQuelthalas.ModObjectLimit(FourCC("R00T"), Faction.UNLIMITED); //Archery Mastery
      FactionQuelthalas.ModObjectLimit(FourCC("R00H"), Faction.UNLIMITED); //Blood Elf Mastery

      //Paths
      FactionQuelthalas.ModObjectLimit(FourCC("R046"), Faction.UNLIMITED); //Quel)thelas Full Mobilization
      FactionQuelthalas.ModObjectLimit(FourCC("R04U"), Faction.UNLIMITED); //Solo Path

      FactionManager.Register(FactionQuelthalas);
    }
  }
}