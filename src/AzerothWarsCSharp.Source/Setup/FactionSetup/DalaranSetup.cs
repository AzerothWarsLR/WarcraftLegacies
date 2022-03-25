using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public class DalaranSetup{

  
    Faction FACTION_DALARAN
  

    public static void Setup( ){
      Faction f;

      FACTION_DALARAN = Faction.create("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0","ReplaceableTextures\\CommandButtons\\BTNJaina.blp");
      f = FACTION_DALARAN;
      f.UndefeatedResearch = FourCC("R05N");
      f.Team = TEAM_ALLIANCE;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC("h065"), Faction.UNLIMITED)   ;//Refuge
      f.ModObjectLimit(FourCC("h066"), Faction.UNLIMITED)   ;//Conclave
      f.ModObjectLimit(FourCC("h068"), Faction.UNLIMITED)   ;//Observatory
      f.ModObjectLimit(FourCC("h063"), Faction.UNLIMITED)   ;//Granary
      f.ModObjectLimit(FourCC("h044"), Faction.UNLIMITED)   ;//Altar of Knowledge
      f.ModObjectLimit(FourCC("h069"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("h02N"), Faction.UNLIMITED)   ;//Trade Quarters
      f.ModObjectLimit(FourCC("h036"), Faction.UNLIMITED)   ;//Arcane Sanctuary
      f.ModObjectLimit(FourCC("h078"), Faction.UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC("h079"), Faction.UNLIMITED)   ;//Arcane Tower
      f.ModObjectLimit(FourCC("h07A"), Faction.UNLIMITED)   ;//Arcane Tower (Improved)
      f.ModObjectLimit(FourCC("hvlt"), Faction.UNLIMITED)   ;//Arcane Vault
      f.ModObjectLimit(FourCC("h076"), Faction.UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC("ndgt"), Faction.UNLIMITED)   ;//Dalaran Tower
      f.ModObjectLimit(FourCC("n004"), Faction.UNLIMITED)   ;//Dalaran Tower (Improved)
      f.ModObjectLimit(FourCC("h067"), Faction.UNLIMITED)   ;//Laboratory
      f.ModObjectLimit(FourCC("n0AO"), 2)           ;//Way Gate

      //Units
      f.ModObjectLimit(FourCC("h022"), Faction.UNLIMITED)   ;//Shaper
      f.ModObjectLimit(FourCC("hbot"), 12)  	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC("hdes"), 12)  	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC("hbsh"), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC("nhym"), Faction.UNLIMITED)   ;//Hydromancer
      f.ModObjectLimit(FourCC("h032"), Faction.UNLIMITED)   ;//Battlemage
      f.ModObjectLimit(FourCC("h02D"), Faction.UNLIMITED)   ;//Geomancer
      f.ModObjectLimit(FourCC("h01I"), Faction.UNLIMITED)   ;//Arcanist
      f.ModObjectLimit(FourCC("n007"), 6)           ;//Kirin Tor
      f.ModObjectLimit(FourCC("n096"), 6)           ;//Earth Golem
      f.ModObjectLimit(FourCC("n03E"), Faction.UNLIMITED)   ;//Pyromancer
      f.ModObjectLimit(FourCC("n0AK"), Faction.UNLIMITED)   ;//Sludge Flinger
      f.ModObjectLimit(FourCC("o02U"), 6)           ;//Crystal Artillery


      //Demi-heroes
      f.ModObjectLimit(FourCC("njks"), 1)           ;//Jailor Kassan
      f.ModObjectLimit(FourCC("Hjai"), 1)           ;//jaina
      f.ModObjectLimit(FourCC("Hant"), 1)           ;//antonidas

      //Upgrades
      f.ModObjectLimit(FourCC("R01I"), Faction.UNLIMITED)   ;//Arcanist Adept Training
      f.ModObjectLimit(FourCC("R01V"), Faction.UNLIMITED)   ;//Geomancer Adept Training
      f.ModObjectLimit(FourCC("R00E"), Faction.UNLIMITED)   ;//Hydromancer Adept Training
      f.ModObjectLimit(FourCC("R01L"), Faction.UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC("R00D"), Faction.UNLIMITED)   ;//Pyromancer Adept Training
      f.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC("R06J"), Faction.UNLIMITED)   ;//Improved Ooze
      f.ModObjectLimit(FourCC("R061"), Faction.UNLIMITED)   ;//Improved Forked Lightning
      f.ModObjectLimit(FourCC("R06O"), Faction.UNLIMITED)   ;//Improved Phase Blade
      f.ModObjectLimit(FourCC("R00J"), Faction.UNLIMITED)   ;//Combat Tomes
    }

  }
}
