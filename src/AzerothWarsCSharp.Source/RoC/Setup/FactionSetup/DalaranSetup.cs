using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup.FactionSetup
{
  public class DalaranSetup{

  
    Faction FACTION_DALARAN
  

    public static void Setup( ){
      Faction f;

      FACTION_DALARAN = Faction.create("Dalaran", PLAYER_COLOR_PINK, "|c00e55bb0","ReplaceableTextures\\CommandButtons\\BTNJaina.blp");
      f = FACTION_DALARAN;
      f.UndefeatedResearch = FourCC(R05N);
      f.Team = TEAM_ALLIANCE;
      f.StartingGold = 150;
      f.StartingLumber = 500;

      //Structures
      f.ModObjectLimit(FourCC(h065), UNLIMITED)   ;//Refuge
      f.ModObjectLimit(FourCC(h066), UNLIMITED)   ;//Conclave
      f.ModObjectLimit(FourCC(h068), UNLIMITED)   ;//Observatory
      f.ModObjectLimit(FourCC(h063), UNLIMITED)   ;//Granary
      f.ModObjectLimit(FourCC(h044), UNLIMITED)   ;//Altar of Knowledge
      f.ModObjectLimit(FourCC(h069), UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC(h02N), UNLIMITED)   ;//Trade Quarters
      f.ModObjectLimit(FourCC(h036), UNLIMITED)   ;//Arcane Sanctuary
      f.ModObjectLimit(FourCC(h078), UNLIMITED)   ;//Scout Tower
      f.ModObjectLimit(FourCC(h079), UNLIMITED)   ;//Arcane Tower
      f.ModObjectLimit(FourCC(h07A), UNLIMITED)   ;//Arcane Tower (Improved)
      f.ModObjectLimit(FourCC(hvlt), UNLIMITED)   ;//Arcane Vault
      f.ModObjectLimit(FourCC(h076), UNLIMITED)   ;//Alliance Shipyard
      f.ModObjectLimit(FourCC(ndgt), UNLIMITED)   ;//Dalaran Tower
      f.ModObjectLimit(FourCC(n004), UNLIMITED)   ;//Dalaran Tower (Improved)
      f.ModObjectLimit(FourCC(h067), UNLIMITED)   ;//Laboratory
      f.ModObjectLimit(FourCC(n0AO), 2)           ;//Way Gate

      //Units
      f.ModObjectLimit(FourCC(h022), UNLIMITED)   ;//Shaper
      f.ModObjectLimit(FourCC(hbot), 12)  	    ;//Alliance Transport Ship
      f.ModObjectLimit(FourCC(hdes), 12)  	    ;//Alliance Frigate
      f.ModObjectLimit(FourCC(hbsh), 6)          ;//Alliance Battle Ship
      f.ModObjectLimit(FourCC(nhym), UNLIMITED)   ;//Hydromancer
      f.ModObjectLimit(FourCC(h032), UNLIMITED)   ;//Battlemage
      f.ModObjectLimit(FourCC(h02D), UNLIMITED)   ;//Geomancer
      f.ModObjectLimit(FourCC(h01I), UNLIMITED)   ;//Arcanist
      f.ModObjectLimit(FourCC(n007), 6)           ;//Kirin Tor
      f.ModObjectLimit(FourCC(n096), 6)           ;//Earth Golem
      f.ModObjectLimit(FourCC(n03E), UNLIMITED)   ;//Pyromancer
      f.ModObjectLimit(FourCC(n0AK), UNLIMITED)   ;//Sludge Flinger
      f.ModObjectLimit(FourCC(o02U), 6)           ;//Crystal Artillery


      //Demi-heroes
      f.ModObjectLimit(FourCC(njks), 1)           ;//Jailor Kassan
      f.ModObjectLimit(FourCC(Hjai), 1)           ;//jaina
      f.ModObjectLimit(FourCC(Hant), 1)           ;//antonidas

      //Upgrades
      f.ModObjectLimit(FourCC(R01I), UNLIMITED)   ;//Arcanist Adept Training
      f.ModObjectLimit(FourCC(R01V), UNLIMITED)   ;//Geomancer Adept Training
      f.ModObjectLimit(FourCC(R00E), UNLIMITED)   ;//Hydromancer Adept Training
      f.ModObjectLimit(FourCC(R01L), UNLIMITED)   ;//Magic Sentry
      f.ModObjectLimit(FourCC(R00K), UNLIMITED)   ;//Power Infusion
      f.ModObjectLimit(FourCC(R00D), UNLIMITED)   ;//Pyromancer Adept Training
      f.ModObjectLimit(FourCC(Rhac), UNLIMITED)   ;//Improved Masonry
      f.ModObjectLimit(FourCC(R06J), UNLIMITED)   ;//Improved Ooze
      f.ModObjectLimit(FourCC(R061), UNLIMITED)   ;//Improved Forked Lightning
      f.ModObjectLimit(FourCC(R06O), UNLIMITED)   ;//Improved Phase Blade
      f.ModObjectLimit(FourCC(R00J), UNLIMITED)   ;//Combat Tomes
    }

  }
}
