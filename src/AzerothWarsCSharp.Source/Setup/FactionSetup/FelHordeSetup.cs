using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class FelHordeSetup{

  
    public static Faction FactionFelHorde { get; private set; }
  

    public static void Setup( ){
      Faction f;

      FactionFelHorde = Faction.create("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000","ReplaceableTextures\\CommandButtons\\BTNPitLord.blp");
      f = FactionFelHorde;
      f.Team = TEAM_LEGION;
      f.UndefeatedResearch = FourCC("R05L");
      f.StartingGold = 300;
      f.StartingLumber = 600;

      f.ModObjectLimit(FourCC("o02Y"), Faction.UNLIMITED)   ;//Great Hall
      f.ModObjectLimit(FourCC("o02Z"), Faction.UNLIMITED)   ;//Stronghold
      f.ModObjectLimit(FourCC("o030"), Faction.UNLIMITED)   ;//Fortress
      f.ModObjectLimit(FourCC("o02V"), Faction.UNLIMITED)   ;//Altar of Storms
      f.ModObjectLimit(FourCC("o02W"), Faction.UNLIMITED)   ;//Barracks
      f.ModObjectLimit(FourCC("o031"), Faction.UNLIMITED)   ;//War Mill
      f.ModObjectLimit(FourCC("o033"), Faction.UNLIMITED)   ;//Spirit Lodge
      f.ModObjectLimit(FourCC("o02X"), Faction.UNLIMITED)   ;//Bestiary
      f.ModObjectLimit(FourCC("o032"), Faction.UNLIMITED)   ;//Shipyard
      f.ModObjectLimit(FourCC("o034"), Faction.UNLIMITED)   ;//Watch Tower
      f.ModObjectLimit(FourCC("o035"), Faction.UNLIMITED)   ;//Improved Watch Tower
      f.ModObjectLimit(FourCC("u00Q"), Faction.UNLIMITED)   ;//Hellforge
      f.ModObjectLimit(FourCC("n0AM"), Faction.UNLIMITED)   ;//Boulder Tower
      f.ModObjectLimit(FourCC("n0AN"), Faction.UNLIMITED)   ;//Advanced Boulder Tower
      f.ModObjectLimit(FourCC("ocbw"), Faction.UNLIMITED)   ;//Burrow
      f.ModObjectLimit(FourCC("n0AP"), Faction.UNLIMITED)   ;//Focal Demon Gate

      f.ModObjectLimit(FourCC("nbdk"), 6)           ;//Black Drake
      f.ModObjectLimit(FourCC("odkt"), 6)           ;//Eredar Warlock
      f.ModObjectLimit(FourCC("nchw"), Faction.UNLIMITED)   ;//Fel Orc Warlock
      f.ModObjectLimit(FourCC("nchg"), Faction.UNLIMITED)   ;//Fel Orc Grunt
      f.ModObjectLimit(FourCC("nchr"), Faction.UNLIMITED)   ;//Fel Orc Raider
      f.ModObjectLimit(FourCC("ncpn"), Faction.UNLIMITED)   ;//Fel Orc Peon
      f.ModObjectLimit(FourCC("owar"), Faction.UNLIMITED)   ;//Horde Cavarly
      f.ModObjectLimit(FourCC("o01L"), 6)           ;//Executioner
      f.ModObjectLimit(FourCC("o01O"), 8)           ;//Demolisher
      f.ModObjectLimit(FourCC("u018"), 10)          ;//Eye of Grillok
      f.ModObjectLimit(FourCC("u00V"), Faction.UNLIMITED)   ;//Necrolyte
      f.ModObjectLimit(FourCC("n057"), -Faction.UNLIMITED)  ;//Nether Dragon Hatchling
      f.ModObjectLimit(FourCC("n058"), Faction.UNLIMITED)   ;//Troll Axethrowers
      f.ModObjectLimit(FourCC("obot"), 12)  	    ;//Transport Ship
      f.ModObjectLimit(FourCC("odes"), 12)  	    ;//Orc Frigate
      f.ModObjectLimit(FourCC("ojgn"), 6)          ;//Juggernaught

      f.ModObjectLimit(FourCC("n05T"), 1)           ;//Kazzak
      f.ModObjectLimit(FourCC("n064"), 1)           ;//Voone
      f.ModObjectLimit(FourCC("n08A"), 1)           ;//neltharaktu
      f.ModObjectLimit(FourCC("Nmag"), 1)           ;//Magtheridon
      f.ModObjectLimit(FourCC("N03D"), 1)           ;//Kargath
      f.ModObjectLimit(FourCC("Nbbc"), 1)           ;//Rend
      f.ModObjectLimit(FourCC("U02D"), 1)           ;//Teron

      f.ModObjectLimit(FourCC("Robf"), Faction.UNLIMITED)   ;//Demonic Flux
      f.ModObjectLimit(FourCC("R066"), Faction.UNLIMITED)   ;//Burning Oil
      f.ModObjectLimit(FourCC("R00O"), Faction.UNLIMITED)   ;//Ensnare
      f.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED)   ;//Reinforced Defenses
      f.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED)   ;//Spiked Barricades
      f.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED)   ;//Spiritual Infusion
      f.ModObjectLimit(FourCC("R000"), -Faction.UNLIMITED)  ;//Skeletal Perserverance
      f.ModObjectLimit(FourCC("R024"), Faction.UNLIMITED)   ;//Necrolyte adept Training
      f.ModObjectLimit(FourCC("R00M"), Faction.UNLIMITED)   ;//Warlock Adept Training
      f.ModObjectLimit(FourCC("R03I"), Faction.UNLIMITED)   ;//Eredar Warlock Adept Training
      f.ModObjectLimit(FourCC("R00Y"), Faction.UNLIMITED)   ;//Improved Self-Bloodlust
      f.ModObjectLimit(FourCC("R03L"), Faction.UNLIMITED)   ;//Improved Shadow Infusion
      f.ModObjectLimit(FourCC("R036"), Faction.UNLIMITED)   ;//Incinerate
      f.ModObjectLimit(FourCC("R02L"), Faction.UNLIMITED)   ;//Bloodcraze
      f.ModObjectLimit(FourCC("R03O"), Faction.UNLIMITED)   ;//Bloodcraze
      f.ModObjectLimit(FourCC("R034"), Faction.UNLIMITED)   ;//Enhanced Breath
      f.ModObjectLimit(FourCC("R035"), Faction.UNLIMITED)   ;//Improved Firebolt
      f.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED)   ;//Battle Stations
      f.SetObjectLevel(FourCC("R01Z"), 1)                ;//Battle Stations


      f.ModObjectLimit(FourCC("n05R"), 1)           ;//Felguard
      f.ModObjectLimit(FourCC("n06H"), 1)           ;//Pit Fiend
      f.ModObjectLimit(FourCC("n07B"), 1)           ;//Queen
      f.ModObjectLimit(FourCC("n07D"), 1)           ;//Maiden
      f.ModObjectLimit(FourCC("n07o"), 1)           ;//Terror
      f.ModObjectLimit(FourCC("n07N"), 1)           ;//Lord


    }

  }
}
