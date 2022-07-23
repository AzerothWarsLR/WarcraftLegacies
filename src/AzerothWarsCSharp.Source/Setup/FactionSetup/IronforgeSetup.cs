using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class IronforgeSetup
  {
    public static Faction? Ironforge { get; private set; }
    
    public static void Setup()
    {
      Ironforge = new Faction("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01",
        "ReplaceableTextures\\CommandButtons\\BTNHeroMountainKing.blp")
      {
        UndefeatedResearch = FourCC("R05T"),
        StartingGold = 150,
        StartingLumber = 500,
        CinematicMusic = "PursuitTheme",
        IntroText = @"You are playing as the long- enduring |cffe4bc00Kingdom of Ironforge.
                    |r
Re-establish your stronghold by capturing the surrounding lands.

The Twilight Hammer clan is gathering in the East, behind the Dragonmaw Gate. It cannot be destroyed, but it can be opened by anyone who owns Grim Batol. 
Once the gate opens, it cannot be closed for 7 minutes, use this opening to your advantage.

Stormwind is preparing for the Fel Horde invasion in the South, muster the throng to help them or you may lose your strongest ally."
      };

      //Structures
      Ironforge.ModObjectLimit(FourCC("h07E"), Faction.UNLIMITED); //Town Hall
      Ironforge.ModObjectLimit(FourCC("h07F"), Faction.UNLIMITED); //Keep
      Ironforge.ModObjectLimit(FourCC("h07G"), Faction.UNLIMITED); //Castle
      Ironforge.ModObjectLimit(FourCC("h02P"), Faction.UNLIMITED); //Farm  (Dwarven)
      Ironforge.ModObjectLimit(FourCC("h01S"), Faction.UNLIMITED); //Tavern
      Ironforge.ModObjectLimit(FourCC("h07B"), Faction.UNLIMITED); //Altar of Kings
      Ironforge.ModObjectLimit(FourCC("h07C"), Faction.UNLIMITED); //Barracks
      Ironforge.ModObjectLimit(FourCC("hlum"), Faction.UNLIMITED); //Lumber Mill
      Ironforge.ModObjectLimit(FourCC("h048"), Faction.UNLIMITED); //Blacksmith (Dwarven)
      Ironforge.ModObjectLimit(FourCC("h042"), Faction.UNLIMITED); //Machine Factory
      Ironforge.ModObjectLimit(FourCC("harm"), Faction.UNLIMITED); //Workshop
      Ironforge.ModObjectLimit(FourCC("hgra"), Faction.UNLIMITED); //Gryphon Aviary
      Ironforge.ModObjectLimit(FourCC("h07H"), Faction.UNLIMITED); //Scout Tower
      Ironforge.ModObjectLimit(FourCC("h07J"), Faction.UNLIMITED); //Cannon Tower
      Ironforge.ModObjectLimit(FourCC("h07K"), Faction.UNLIMITED); //Cannon Tower (Improved)
      Ironforge.ModObjectLimit(FourCC("h07D"), Faction.UNLIMITED); //Alliance Shipyard
      Ironforge.ModObjectLimit(FourCC("n07U"), Faction.UNLIMITED); //Marketplace
      Ironforge.ModObjectLimit(FourCC("h00B"), 4); //Dwarven Keep Tower
      Ironforge.ModObjectLimit(FourCC("h07I"), Faction.UNLIMITED); //Guard Tower
      Ironforge.ModObjectLimit(FourCC("h07L"), Faction.UNLIMITED); //Guard Tower (Improved)

      //Units
      Ironforge.ModObjectLimit(FourCC("h019"), Faction.UNLIMITED); //Dwarven Worker
      Ironforge.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      Ironforge.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      Ironforge.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      Ironforge.ModObjectLimit(FourCC("hrif"), Faction.UNLIMITED); //Rifleman
      Ironforge.ModObjectLimit(FourCC("hmtm"), 9); //Mortar Team
      Ironforge.ModObjectLimit(FourCC("hgyr"), 12); //Flying Machine
      Ironforge.ModObjectLimit(FourCC("hgry"), 6); //Gryphon Rider
      Ironforge.ModObjectLimit(FourCC("h018"), Faction.UNLIMITED); //Dwarven Warrior
      Ironforge.ModObjectLimit(FourCC("h01L"), 6); //Thane
      Ironforge.ModObjectLimit(FourCC("h037"), Faction.UNLIMITED); //Engineer
      Ironforge.ModObjectLimit(FourCC("n02D"), Faction.UNLIMITED); //War Golem
      Ironforge.ModObjectLimit(FourCC("h01P"), 3); //Steam Tank
      Ironforge.ModObjectLimit(FourCC("n00C"), Faction.UNLIMITED); //Rune Priest

      Ironforge.ModObjectLimit(FourCC("h01M"), 1); //Baelgun
      Ironforge.ModObjectLimit(FourCC("H00S"), 1); //Magni
      Ironforge.ModObjectLimit(FourCC("Hmbr"), 1); //Muradin

      //Upgrades
      Ironforge.ModObjectLimit(FourCC("R03H"), Faction.UNLIMITED); //Engineering Adept Training
      Ironforge.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      Ironforge.ModObjectLimit(FourCC("R00F"), Faction.UNLIMITED); //Mithril Armor
      Ironforge.ModObjectLimit(FourCC("Rhfl"), Faction.UNLIMITED); //Flare
      Ironforge.ModObjectLimit(FourCC("Rhfs"), Faction.UNLIMITED); //Dragmentation Shards
      Ironforge.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      Ironforge.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      Ironforge.ModObjectLimit(FourCC("Rhri"), Faction.UNLIMITED); //Long Rifles
      Ironforge.ModObjectLimit(FourCC("Rhhb"), Faction.UNLIMITED); //Storm Hammers
      Ironforge.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Thunder Ale
      Ironforge.ModObjectLimit(Constants.UPGRADE_RHME_PYRITE_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_RHAR_PYRITE_ARMOR_PLATING_UNIVERSAL_UPGRADE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R00V_RUNE_PRIEST_MASTER_TRAINING_IRONFORGE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R00N_IMPROVED_SWIG_IRONFORGE_TAVERN, Faction.UNLIMITED);
      Ironforge.ModObjectLimit(Constants.UPGRADE_R08K_TITANFORGE_ARTIFACT_IRONFORGE, Faction.UNLIMITED);

      Ironforge.ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
      Ironforge.ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      Ironforge.ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      Ironforge.ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      Ironforge.ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
      
      Ironforge.AddGoldMine(PreplacedUnitSystem.GetUnit(FourCC("ugol"), new Point(12079, -2768)));
      
      FactionManager.Register(Ironforge);
    }
  }
}