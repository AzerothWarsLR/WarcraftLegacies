using System.Collections.Generic;
using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public class Ironforge : Faction
  {
    private readonly PreplacedUnitSystem _preplacedUnitSystem;
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;

    /// <inheritdoc />
    public Ironforge(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01",
      @"ReplaceableTextures\CommandButtons\BTNHeroMountainKing.blp")
    {
      _preplacedUnitSystem = preplacedUnitSystem;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      UndefeatedResearch = FourCC("R05T");
      StartingGold = 200;
      StartingLumber = 700;
      CinematicMusic = "PursuitTheme";
      ControlPointDefenderUnitTypeId = Constants.UNIT_H0AL_CONTROL_POINT_DEFENDER_IRONFORGE;
      IntroText = @"You are playing as the long-enduring |cffe4bc00Kingdom of 
                    |r
You begin in the Wetlands, separated from the rest of your forces. Conquer Loch Modan and Dun Morough to gain access to 
 
Stormwind is preparing for an invasion through the Dark Portal in the South. Muster the throng and help them, or you may lose your strongest ally.";
      GoldMines = new List<unit>
      {
        preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(12079, -2768))
      };
    }
        
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
    }

    private void RegisterObjectLimits()
    {
      //Structures
      ModObjectLimit(FourCC("h07E"), Faction.UNLIMITED); //Town Hall
      ModObjectLimit(FourCC("h07F"), Faction.UNLIMITED); //Keep
      ModObjectLimit(FourCC("h07G"), Faction.UNLIMITED); //Castle
      ModObjectLimit(FourCC("h02P"), Faction.UNLIMITED); //Farm  (Dwarven)
      ModObjectLimit(FourCC("h01S"), Faction.UNLIMITED); //Tavern
      ModObjectLimit(FourCC("h07B"), Faction.UNLIMITED); //Altar of Kings
      ModObjectLimit(FourCC("h07C"), Faction.UNLIMITED); //Barracks
      ModObjectLimit(FourCC("hlum"), Faction.UNLIMITED); //Lumber Mill
      ModObjectLimit(FourCC("h048"), Faction.UNLIMITED); //Blacksmith (Dwarven)
      ModObjectLimit(FourCC("h042"), Faction.UNLIMITED); //Machine Factory
      ModObjectLimit(FourCC("harm"), Faction.UNLIMITED); //Workshop
      ModObjectLimit(FourCC("hgra"), Faction.UNLIMITED); //Gryphon Aviary
      ModObjectLimit(FourCC("h07H"), Faction.UNLIMITED); //Scout Tower
      ModObjectLimit(FourCC("h07J"), Faction.UNLIMITED); //Cannon Tower
      ModObjectLimit(FourCC("h07K"), Faction.UNLIMITED); //Cannon Tower (Improved)
      ModObjectLimit(FourCC("h07D"), Faction.UNLIMITED); //Alliance Shipyard
      ModObjectLimit(FourCC("n07U"), Faction.UNLIMITED); //Marketplace
      ModObjectLimit(FourCC("h07I"), Faction.UNLIMITED); //Guard Tower
      ModObjectLimit(FourCC("h07L"), Faction.UNLIMITED); //Guard Tower (Improved)

      //Units
      ModObjectLimit(FourCC("h019"), Faction.UNLIMITED); //Dwarven Worker
      ModObjectLimit(FourCC("hrif"), Faction.UNLIMITED); //Rifleman
      ModObjectLimit(FourCC("hmtm"), 9); //Mortar Team
      ModObjectLimit(FourCC("n0CZ"), 4); //Dreadnaught
      ModObjectLimit(FourCC("hgry"), 6); //Gryphon Rider
      ModObjectLimit(FourCC("h018"), Faction.UNLIMITED); //Dwarven Warrior
      ModObjectLimit(FourCC("h01L"), 6); //Thane
      ModObjectLimit(FourCC("h037"), Faction.UNLIMITED); //Engineer
      ModObjectLimit(FourCC("n02D"), Faction.UNLIMITED); //War Golem
      ModObjectLimit(FourCC("h01P"), 3); //Steam Tank
      ModObjectLimit(FourCC("n00C"), Faction.UNLIMITED); //Rune Priest
      ModObjectLimit(FourCC("h03Z"), 3); //War Gryphon

      ModObjectLimit(FourCC("h01M"), 1); //Baelgun
      ModObjectLimit(FourCC("H00S"), 1); //Magni
      ModObjectLimit(FourCC("Hmbr"), 1); //Muradin
      ModObjectLimit(Constants.UNIT_H03G_EMPEROR_OF_BLACKROCK_RAGNAROS, 1);
      ModObjectLimit(Constants.UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE, 1);

      //Ships
      ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      ModObjectLimit(FourCC("h0AR"), Faction.UNLIMITED); //Alliance Scout
      ModObjectLimit(FourCC("h0AX"), Faction.UNLIMITED); //Alliance Frigate
      ModObjectLimit(FourCC("h0B3"), Faction.UNLIMITED); //Alliance Fireship
      ModObjectLimit(FourCC("h0B0"), Faction.UNLIMITED); //Alliance Galley
      ModObjectLimit(FourCC("h0B6"), Faction.UNLIMITED); //Alliance Boarding
      ModObjectLimit(FourCC("h0AN"), Faction.UNLIMITED); //Alliance Juggernaut
      ModObjectLimit(FourCC("h0B7"), 6); //Alliance Bombard

      //Upgrades
      ModObjectLimit(FourCC("R03H"), Faction.UNLIMITED); //Engineering Adept Training
      ModObjectLimit(FourCC("R00F"), Faction.UNLIMITED); //Mithril Armor
      ModObjectLimit(FourCC("Rhfl"), Faction.UNLIMITED); //Flare
      ModObjectLimit(FourCC("Rhfs"), Faction.UNLIMITED); //Dragmentation Shards
      ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      ModObjectLimit(FourCC("Rhri"), Faction.UNLIMITED); //Long Rifles
      ModObjectLimit(FourCC("Rhhb"), Faction.UNLIMITED); //Storm Hammers
      ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Thunder Ale
      ModObjectLimit(FourCC("R02K"), Faction.UNLIMITED); //Gryphon Superior Breed
      ModObjectLimit(Constants.UPGRADE_RHME_PYRITE_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, 2);
      ModObjectLimit(Constants.UPGRADE_RHAR_PYRITE_ARMOR_PLATING_UNIVERSAL_UPGRADE, 2);
      ModObjectLimit(Constants.UPGRADE_R00V_RUNE_PRIEST_MASTER_TRAINING_IRONFORGE, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R00N_IMPROVED_SWIG_IRONFORGE_TAVERN, Faction.UNLIMITED);
      ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);

      ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
    }

    private void RegisterQuests()
    {
      throw new System.NotImplementedException();
    }

    private void RegisterDialogue()
    {
      throw new System.NotImplementedException();
    }
  }
}