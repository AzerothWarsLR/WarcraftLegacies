using System.Collections.Generic;
using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.FactionMechanics.Fel_Horde;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class FelHorde : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public FelHorde(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Fel Horde", PLAYER_COLOR_GREEN, "|c0020c000",
      @"ReplaceableTextures\CommandButtons\BTNPitLord.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = FourCC("R05L");
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "Doom";
      ControlPointDefenderUnitTypeId = Constants.UNIT_N0AA_CONTROL_POINT_DEFENDER_FEL_HORDE;
      IntroText = @"You are playing as the bloodthirsty Fel Horde.

You begin in Nagrand, cut off from your forces in Hellfire Citadel. You must raise an army and quickly conquer Outland.

Once Outland is under your control, gather your hordes and prepare to invade Azeroth through the Dark Portal.

The Alliance is gathering outside the Dark Portal to stop you, so prepare to for a very hard breakout.";
      FoodMaximum = 250;
      GoldMines = new List<unit>
      {
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-2735, -30242))
      };
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      JuggernautDeath.Setup(_preplacedUnitSystem);
    }

    private void RegisterObjectLimits()
    {
      ModObjectLimit(FourCC("o02Y"), Faction.UNLIMITED); //Great Hall
      ModObjectLimit(FourCC("o02Z"), Faction.UNLIMITED); //Stronghold
      ModObjectLimit(FourCC("o030"), Faction.UNLIMITED); //Fortress
      ModObjectLimit(FourCC("o02V"), Faction.UNLIMITED); //Altar of Storms
      ModObjectLimit(FourCC("o02W"), Faction.UNLIMITED); //Barracks
      ModObjectLimit(FourCC("o031"), Faction.UNLIMITED); //War Mill
      ModObjectLimit(FourCC("o033"), Faction.UNLIMITED); //Spirit Lodge
      ModObjectLimit(FourCC("o02X"), Faction.UNLIMITED); //Bestiary
      ModObjectLimit(FourCC("o032"), Faction.UNLIMITED); //Shipyard
      ModObjectLimit(FourCC("o034"), Faction.UNLIMITED); //Watch Tower
      ModObjectLimit(FourCC("o035"), Faction.UNLIMITED); //Improved Watch Tower
      ModObjectLimit(FourCC("u00Q"), Faction.UNLIMITED); //Hellforge
      ModObjectLimit(FourCC("n0AM"), Faction.UNLIMITED); //Boulder Tower
      ModObjectLimit(FourCC("n0AN"), Faction.UNLIMITED); //Advanced Boulder Tower
      ModObjectLimit(FourCC("ocbw"), Faction.UNLIMITED); //Burrow
      ModObjectLimit(FourCC("n0AP"), Faction.UNLIMITED); //Focal Demon Gate

      ModObjectLimit(FourCC("nbdk"), 6); //Black Drake
      ModObjectLimit(FourCC("odkt"), 6); //Eredar Warlock
      ModObjectLimit(FourCC("nchw"), Faction.UNLIMITED); //Fel Orc Warlock
      ModObjectLimit(FourCC("nchg"), Faction.UNLIMITED); //Fel Orc Grunt
      ModObjectLimit(FourCC("nchr"), Faction.UNLIMITED); //Fel Orc Raider
      ModObjectLimit(FourCC("ncpn"), Faction.UNLIMITED); //Fel Orc Peon
      ModObjectLimit(FourCC("owar"), 12); //Horde Cavarly
      ModObjectLimit(FourCC("o01L"), 6); //Executioner
      ModObjectLimit(FourCC("o01O"), 8); //Demolisher
      ModObjectLimit(FourCC("u018"), 10); //Eye of Grillok
      ModObjectLimit(FourCC("u00V"), Faction.UNLIMITED); //Necrolyte
      ModObjectLimit(FourCC("n058"), Faction.UNLIMITED); //Troll Axethrowers
      ModObjectLimit(Constants.UNIT_NINA_INFERNAL_JUGGERNAUT_FEL_HORDE, 4);
      ModObjectLimit(Constants.UNIT_N086_FEL_DEATH_KNIGHT_FEL_HORDE_ELITE_TIER, 6);

      //Ship
      ModObjectLimit(FourCC("obot"), Faction.UNLIMITED); //Transport Ship
      ModObjectLimit(FourCC("h0AS"), Faction.UNLIMITED); //Scout
      ModObjectLimit(FourCC("h0AP"), Faction.UNLIMITED); //Frigate
      ModObjectLimit(FourCC("h0B2"), Faction.UNLIMITED); //Fireship
      ModObjectLimit(FourCC("h0AY"), Faction.UNLIMITED); //Galley
      ModObjectLimit(FourCC("h0B5"), Faction.UNLIMITED); //Boarding
      ModObjectLimit(FourCC("h0BC"), Faction.UNLIMITED); //Juggernaut
      ModObjectLimit(FourCC("h0AO"), 6); //Bombard

      ModObjectLimit(FourCC("n05T"), 1); //Kazzak
      ModObjectLimit(FourCC("n08A"), 1); //neltharaktu
      ModObjectLimit(FourCC("N03D"), 1); //Kargath
      ModObjectLimit(FourCC("Nbbc"), 1); //Rend
      ModObjectLimit(FourCC("U02D"), 1); //Teron
      ModObjectLimit(FourCC("Nmag"), 1); //Magtheridon

      ModObjectLimit(FourCC("Robf"), Faction.UNLIMITED); //Demonic Flux
      ModObjectLimit(FourCC("R066"), Faction.UNLIMITED); //Burning Oil
      ModObjectLimit(FourCC("R00O"), Faction.UNLIMITED); //Ensnare
      ModObjectLimit(FourCC("Rorb"), Faction.UNLIMITED); //Reinforced Defenses
      ModObjectLimit(FourCC("Rosp"), Faction.UNLIMITED); //Spiked Barricades
      ModObjectLimit(FourCC("R000"), -Faction.UNLIMITED); //Skeletal Perserverance
      ModObjectLimit(FourCC("R024"), Faction.UNLIMITED); //Necrolyte adept Training
      ModObjectLimit(FourCC("R00M"), Faction.UNLIMITED); //Warlock Adept Training
      ModObjectLimit(FourCC("R03I"), Faction.UNLIMITED); //Eredar Warlock Adept Training
      ModObjectLimit(FourCC("R00Y"), Faction.UNLIMITED); //Improved Self-Bloodlust
      ModObjectLimit(FourCC("R03L"), Faction.UNLIMITED); //Improved Shadow Infusion
      ModObjectLimit(FourCC("R036"), Faction.UNLIMITED); //Incinerate
      ModObjectLimit(FourCC("R02L"), Faction.UNLIMITED); //Bloodcraze
      ModObjectLimit(FourCC("R03O"), Faction.UNLIMITED); //Bloodcraze
      ModObjectLimit(FourCC("R034"), Faction.UNLIMITED); //Enhanced Breath
      ModObjectLimit(FourCC("R035"), Faction.UNLIMITED); //Improved Firebolt
      ModObjectLimit(FourCC("R01Z"), Faction.UNLIMITED); //Battle Stations
      ModObjectLimit(Constants.UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R09W_IMPROVED_GREATER_CARRION_SWARM_LEGION, Faction.UNLIMITED); 
      SetObjectLevel(FourCC("R01Z"), 1); //Battle Stations
      
      ModObjectLimit(FourCC("n05R"), Faction.UNLIMITED); //Felguard
      ModObjectLimit(FourCC("n06H"), Faction.UNLIMITED); //Pit Fiend
      ModObjectLimit(FourCC("n07B"), Faction.UNLIMITED); //Queen
      ModObjectLimit(FourCC("n07D"), Faction.UNLIMITED); //Maiden
      ModObjectLimit(FourCC("n07o"), Faction.UNLIMITED); //Terror
      ModObjectLimit(FourCC("n07N"), Faction.UNLIMITED); //Lord
      
      ModAbilityAvailability(Constants.ABILITY_A0MZ_DEMONIC_CONSTRUCTION_TEAL_DEMOLISHERS, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GM_FOR_THE_HORDE_PINK_GREY_MAIN_BUILDINGS, -1);

      ModObjectLimit(FourCC("R090"), Faction.UNLIMITED); //Blackrock
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }
  }
}