using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class FelHordeSetup
  {
    public static Faction FactionFelHorde { get; private set; }
    
    public static void Setup()
    {
      Faction f;

      FactionFelHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000",
        "ReplaceableTextures\\CommandButtons\\BTNPitLord.blp")
      {
        UndefeatedResearch = FourCC("R05L"),
        StartingGold = 300,
        StartingLumber = 600,
        Team = TeamSetup.TeamLegion
      };

      FactionFelHorde.ModObjectLimit(FourCC("o02Y"), Faction.UNLIMITED); //Great Hall
      FactionFelHorde.ModObjectLimit(FourCC("o02Z"), Faction.UNLIMITED); //Stronghold
      FactionFelHorde.ModObjectLimit(FourCC("o030"), Faction.UNLIMITED); //Fortress
      FactionFelHorde.ModObjectLimit(FourCC("o02V"), Faction.UNLIMITED); //Altar of Storms
      FactionFelHorde.ModObjectLimit(FourCC("o02W"), Faction.UNLIMITED); //Barracks
      FactionFelHorde.ModObjectLimit(FourCC("o031"), Faction.UNLIMITED); //War Mill
      FactionFelHorde.ModObjectLimit(FourCC("o033"), Faction.UNLIMITED); //Spirit Lodge
      FactionFelHorde.ModObjectLimit(FourCC("o02X"), Faction.UNLIMITED); //Bestiary
      FactionFelHorde.ModObjectLimit(FourCC("o032"), Faction.UNLIMITED); //Shipyard
      FactionFelHorde.ModObjectLimit(FourCC("o034"), Faction.UNLIMITED); //Watch Tower
      FactionFelHorde.ModObjectLimit(FourCC("o035"), Faction.UNLIMITED); //Improved Watch Tower
      FactionFelHorde.ModObjectLimit(FourCC("u00Q"), Faction.UNLIMITED); //Hellforge
      FactionFelHorde.ModObjectLimit(FourCC("n0AM"), Faction.UNLIMITED); //Boulder Tower
      FactionFelHorde.ModObjectLimit(FourCC("n0AN"), Faction.UNLIMITED); //Advanced Boulder Tower
      FactionFelHorde.ModObjectLimit(FourCC("ocbw"), Faction.UNLIMITED); //Burrow
      FactionFelHorde.ModObjectLimit(FourCC("n0AP"), Faction.UNLIMITED); //Focal Demon Gate

      FactionFelHorde.ModObjectLimit(FourCC("nbdk"), 6); //Black Drake
      FactionFelHorde.ModObjectLimit(FourCC("odkt"), 6); //Eredar Warlock
      FactionFelHorde.ModObjectLimit(FourCC("nchw"), Faction.UNLIMITED); //Fel Orc Warlock
      FactionFelHorde.ModObjectLimit(FourCC("nchg"), Faction.UNLIMITED); //Fel Orc Grunt
      FactionFelHorde.ModObjectLimit(FourCC("nchr"), Faction.UNLIMITED); //Fel Orc Raider
      FactionFelHorde.ModObjectLimit(FourCC("ncpn"), Faction.UNLIMITED); //Fel Orc Peon
      FactionFelHorde.ModObjectLimit(FourCC("owar"), Faction.UNLIMITED); //Horde Cavarly
      FactionFelHorde.ModObjectLimit(FourCC("o01L"), 6); //Executioner
      FactionFelHorde.ModObjectLimit(FourCC("o01O"), 8); //Demolisher
      FactionFelHorde.ModObjectLimit(FourCC("u018"), 10); //Eye of Grillok
      FactionFelHorde.ModObjectLimit(FourCC("u00V"), Faction.UNLIMITED); //Necrolyte
      FactionFelHorde.ModObjectLimit(FourCC("n057"), -Faction.UNLIMITED); //Nether Dragon Hatchling
      FactionFelHorde.ModObjectLimit(FourCC("n058"), Faction.UNLIMITED); //Troll Axethrowers
      FactionFelHorde.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      FactionFelHorde.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      FactionFelHorde.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      FactionFelHorde.ModObjectLimit(FourCC("n05T"), 1); //Kazzak
      FactionFelHorde.ModObjectLimit(FourCC("n064"), 1); //Voone
      FactionFelHorde.ModObjectLimit(FourCC("n08A"), 1); //neltharaktu
      FactionFelHorde.ModObjectLimit(FourCC("Nmag"), 1); //Magtheridon
      FactionFelHorde.ModObjectLimit(FourCC("N03D"), 1); //Kargath
      FactionFelHorde.ModObjectLimit(FourCC("Nbbc"), 1); //Rend
      FactionFelHorde.ModObjectLimit(FourCC("U02D"), 1); //Teron

      FactionFelHorde.ModObjectLimit(FourCC("Robf"), Faction.UNLIMITED); //Demonic Flux
      FactionFelHorde.ModObjectLimit(FourCC("R066"), Faction.UNLIMITED); //Burning Oil
      FactionFelHorde.ModObjectLimit(FourCC("R00O"), Faction.UNLIMITED); //Ensnare
      FactionFelHorde.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      FactionFelHorde.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      FactionFelHorde.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      FactionFelHorde.ModObjectLimit(FourCC("R000"), -Faction.UNLIMITED); //Skeletal Perserverance
      FactionFelHorde.ModObjectLimit(FourCC("R024"), Faction.UNLIMITED); //Necrolyte adept Training
      FactionFelHorde.ModObjectLimit(FourCC("R00M"), Faction.UNLIMITED); //Warlock Adept Training
      FactionFelHorde.ModObjectLimit(FourCC("R03I"), Faction.UNLIMITED); //Eredar Warlock Adept Training
      FactionFelHorde.ModObjectLimit(FourCC("R00Y"), Faction.UNLIMITED); //Improved Self-Bloodlust
      FactionFelHorde.ModObjectLimit(FourCC("R03L"), Faction.UNLIMITED); //Improved Shadow Infusion
      FactionFelHorde.ModObjectLimit(FourCC("R036"), Faction.UNLIMITED); //Incinerate
      FactionFelHorde.ModObjectLimit(FourCC("R02L"), Faction.UNLIMITED); //Bloodcraze
      FactionFelHorde.ModObjectLimit(FourCC("R03O"), Faction.UNLIMITED); //Bloodcraze
      FactionFelHorde.ModObjectLimit(FourCC("R034"), Faction.UNLIMITED); //Enhanced Breath
      FactionFelHorde.ModObjectLimit(FourCC("R035"), Faction.UNLIMITED); //Improved Firebolt
      FactionFelHorde.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      FactionFelHorde.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations


      FactionFelHorde.ModObjectLimit(FourCC("n05R"), 1); //Felguard
      FactionFelHorde.ModObjectLimit(FourCC("n06H"), 1); //Pit Fiend
      FactionFelHorde.ModObjectLimit(FourCC("n07B"), 1); //Queen
      FactionFelHorde.ModObjectLimit(FourCC("n07D"), 1); //Maiden
      FactionFelHorde.ModObjectLimit(FourCC("n07o"), 1); //Terror
      FactionFelHorde.ModObjectLimit(FourCC("n07N"), 1); //Lord
    }
  }
}