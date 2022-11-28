using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Mechanics.Fel_Horde;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class FelHordeSetup
  {
    public static Faction? FelHorde { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      FelHorde = new Faction("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000",
        "ReplaceableTextures\\CommandButtons\\BTNPitLord.blp")
      {
        UndefeatedResearch = FourCC("R05L"),
        StartingGold = 300,
        StartingLumber = 600,
        CinematicMusic = "Doom",
        IntroText = @"You are playing as the bloodthirsty Fel Horde.

The Draenei survivors are fleeing Shattrath for Tempest Keep. At the bidding of your demon-masters, you must slay them all before they can escape Outland.

Once the Draenei have been dealt with, gather the hordes and prepare to invade Azeroth through the Dark Portal.

The Alliance is gathering outside the Dark Portal to stop you, so prepare to for a very hard breakout.
Your allies cannot reach you on Outland, you are alone.",
        FoodMaximum = 250
      };

      FelHorde.ModObjectLimit(FourCC("o02Y"), Faction.UNLIMITED); //Great Hall
      FelHorde.ModObjectLimit(FourCC("o02Z"), Faction.UNLIMITED); //Stronghold
      FelHorde.ModObjectLimit(FourCC("o030"), Faction.UNLIMITED); //Fortress
      FelHorde.ModObjectLimit(FourCC("o02V"), Faction.UNLIMITED); //Altar of Storms
      FelHorde.ModObjectLimit(FourCC("o02W"), Faction.UNLIMITED); //Barracks
      FelHorde.ModObjectLimit(FourCC("o031"), Faction.UNLIMITED); //War Mill
      FelHorde.ModObjectLimit(FourCC("o033"), Faction.UNLIMITED); //Spirit Lodge
      FelHorde.ModObjectLimit(FourCC("o02X"), Faction.UNLIMITED); //Bestiary
      FelHorde.ModObjectLimit(FourCC("o032"), Faction.UNLIMITED); //Shipyard
      FelHorde.ModObjectLimit(FourCC("o034"), Faction.UNLIMITED); //Watch Tower
      FelHorde.ModObjectLimit(FourCC("o035"), Faction.UNLIMITED); //Improved Watch Tower
      FelHorde.ModObjectLimit(FourCC("u00Q"), Faction.UNLIMITED); //Hellforge
      FelHorde.ModObjectLimit(FourCC("n0AM"), Faction.UNLIMITED); //Boulder Tower
      FelHorde.ModObjectLimit(FourCC("n0AN"), Faction.UNLIMITED); //Advanced Boulder Tower
      FelHorde.ModObjectLimit(FourCC("ocbw"), Faction.UNLIMITED); //Burrow
      FelHorde.ModObjectLimit(FourCC("n0AP"), Faction.UNLIMITED); //Focal Demon Gate

      FelHorde.ModObjectLimit(FourCC("nbdk"), 6); //Black Drake
      FelHorde.ModObjectLimit(FourCC("odkt"), 6); //Eredar Warlock
      FelHorde.ModObjectLimit(FourCC("nchw"), Faction.UNLIMITED); //Fel Orc Warlock
      FelHorde.ModObjectLimit(FourCC("nchg"), Faction.UNLIMITED); //Fel Orc Grunt
      FelHorde.ModObjectLimit(FourCC("nchr"), Faction.UNLIMITED); //Fel Orc Raider
      FelHorde.ModObjectLimit(FourCC("ncpn"), Faction.UNLIMITED); //Fel Orc Peon
      FelHorde.ModObjectLimit(FourCC("owar"), Faction.UNLIMITED); //Horde Cavarly
      FelHorde.ModObjectLimit(FourCC("o01L"), 6); //Executioner
      FelHorde.ModObjectLimit(FourCC("o01O"), 8); //Demolisher
      FelHorde.ModObjectLimit(FourCC("u018"), 10); //Eye of Grillok
      FelHorde.ModObjectLimit(FourCC("u00V"), Faction.UNLIMITED); //Necrolyte
      FelHorde.ModObjectLimit(FourCC("n057"), -Faction.UNLIMITED); //Nether Dragon Hatchling
      FelHorde.ModObjectLimit(FourCC("n058"), Faction.UNLIMITED); //Troll Axethrowers
      FelHorde.ModObjectLimit(FourCC("obot"), 12); //Transport Ship
      FelHorde.ModObjectLimit(FourCC("odes"), 12); //Orc Frigate
      FelHorde.ModObjectLimit(FourCC("ojgn"), 6); //Juggernaught

      FelHorde.ModObjectLimit(FourCC("n05T"), 1); //Kazzak
      FelHorde.ModObjectLimit(FourCC("n064"), 1); //Voone
      FelHorde.ModObjectLimit(FourCC("n08A"), 1); //neltharaktu
      FelHorde.ModObjectLimit(FourCC("Nmag"), 1); //Magtheridon
      FelHorde.ModObjectLimit(FourCC("N03D"), 1); //Kargath
      FelHorde.ModObjectLimit(FourCC("Nbbc"), 1); //Rend
      FelHorde.ModObjectLimit(FourCC("U02D"), 1); //Teron

      FelHorde.ModObjectLimit(FourCC("Robf"), Faction.UNLIMITED); //Demonic Flux
      FelHorde.ModObjectLimit(FourCC("R066"), Faction.UNLIMITED); //Burning Oil
      FelHorde.ModObjectLimit(FourCC("R00O"), Faction.UNLIMITED); //Ensnare
      FelHorde.ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      FelHorde.ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      FelHorde.ModObjectLimit(FourCC("R023"), Faction.UNLIMITED); //Spiritual Infusion
      FelHorde.ModObjectLimit(FourCC("R000"), -Faction.UNLIMITED); //Skeletal Perserverance
      FelHorde.ModObjectLimit(FourCC("R024"), Faction.UNLIMITED); //Necrolyte adept Training
      FelHorde.ModObjectLimit(FourCC("R00M"), Faction.UNLIMITED); //Warlock Adept Training
      FelHorde.ModObjectLimit(FourCC("R03I"), Faction.UNLIMITED); //Eredar Warlock Adept Training
      FelHorde.ModObjectLimit(FourCC("R00Y"), Faction.UNLIMITED); //Improved Self-Bloodlust
      FelHorde.ModObjectLimit(FourCC("R03L"), Faction.UNLIMITED); //Improved Shadow Infusion
      FelHorde.ModObjectLimit(FourCC("R036"), Faction.UNLIMITED); //Incinerate
      FelHorde.ModObjectLimit(FourCC("R02L"), Faction.UNLIMITED); //Bloodcraze
      FelHorde.ModObjectLimit(FourCC("R03O"), Faction.UNLIMITED); //Bloodcraze
      FelHorde.ModObjectLimit(FourCC("R034"), Faction.UNLIMITED); //Enhanced Breath
      FelHorde.ModObjectLimit(FourCC("R035"), Faction.UNLIMITED); //Improved Firebolt
      FelHorde.ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      FelHorde.SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations
      
      FelHorde.ModObjectLimit(FourCC("n05R"), 1); //Felguard
      FelHorde.ModObjectLimit(FourCC("n06H"), 1); //Pit Fiend
      FelHorde.ModObjectLimit(FourCC("n07B"), 1); //Queen
      FelHorde.ModObjectLimit(FourCC("n07D"), 1); //Maiden
      FelHorde.ModObjectLimit(FourCC("n07o"), 1); //Terror
      FelHorde.ModObjectLimit(FourCC("n07N"), 1); //Lord
      
      FelHorde.ModAbilityAvailability(Constants.ABILITY_A0MZ_DEMONIC_CONSTRUCTION_TEAL_DEMOLISHERS, -1);
      FelHorde.ModAbilityAvailability(Constants.ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, -1);

      FelHorde.AddGoldMine(preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(5804, -29242)));
      
      FactionManager.Register(FelHorde);

      FelHordeJuggernautDeath.Setup(preplacedUnitSystem);
    }
  }
}