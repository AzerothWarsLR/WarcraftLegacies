using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class IronforgeSetup
  {
    public static Faction FACTION_IRONFORGE { get; private set; }
    
    public static void Setup()
    {
      FACTION_IRONFORGE = new Faction("Ironforge", PLAYER_COLOR_YELLOW, "|C00FFFC01",
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
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07E"), Faction.UNLIMITED); //Town Hall
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07F"), Faction.UNLIMITED); //Keep
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07G"), Faction.UNLIMITED); //Castle
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h02P"), Faction.UNLIMITED); //Farm  (Dwarven)
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h01S"), Faction.UNLIMITED); //Tavern
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07B"), Faction.UNLIMITED); //Altar of Kings
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07C"), Faction.UNLIMITED); //Barracks
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hlum"), Faction.UNLIMITED); //Lumber Mill
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h048"), Faction.UNLIMITED); //Blacksmith (Dwarven)
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h042"), Faction.UNLIMITED); //Machine Factory
      FACTION_IRONFORGE.ModObjectLimit(FourCC("harm"), Faction.UNLIMITED); //Workshop
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hgra"), Faction.UNLIMITED); //Gryphon Aviary
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07H"), Faction.UNLIMITED); //Scout Tower
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07J"), Faction.UNLIMITED); //Cannon Tower
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07K"), Faction.UNLIMITED); //Cannon Tower (Improved)
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07D"), Faction.UNLIMITED); //Alliance Shipyard
      FACTION_IRONFORGE.ModObjectLimit(FourCC("n07U"), Faction.UNLIMITED); //Marketplace
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h00B"), 4); //Dwarven Keep Tower
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07I"), Faction.UNLIMITED); //Guard Tower
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h07L"), Faction.UNLIMITED); //Guard Tower (Improved)

      //Units
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h019"), Faction.UNLIMITED); //Dwarven Worker
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hrif"), Faction.UNLIMITED); //Rifleman
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hmtm"), 9); //Mortar Team
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hgyr"), 12); //Flying Machine
      FACTION_IRONFORGE.ModObjectLimit(FourCC("hgry"), 6); //Gryphon Rider
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h018"), Faction.UNLIMITED); //Dwarven Warrior
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h01L"), 6); //Thane
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h037"), Faction.UNLIMITED); //Engineer
      FACTION_IRONFORGE.ModObjectLimit(FourCC("n02D"), Faction.UNLIMITED); //War Golem
      FACTION_IRONFORGE.ModObjectLimit(FourCC("h01P"), 3); //Steam Tank
      FACTION_IRONFORGE.ModObjectLimit(FourCC("n00C"), Faction.UNLIMITED); //Rune Priest

      FACTION_IRONFORGE.ModObjectLimit(FourCC("h01M"), 1); //Baelgun
      FACTION_IRONFORGE.ModObjectLimit(FourCC("H00S"), 1); //Magni
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Hmbr"), 1); //Muradin

      //Upgrades
      FACTION_IRONFORGE.ModObjectLimit(FourCC("R03H"), Faction.UNLIMITED); //Engineering Adept Training
      FACTION_IRONFORGE.ModObjectLimit(FourCC("R00K"), Faction.UNLIMITED); //Power Infusion
      FACTION_IRONFORGE.ModObjectLimit(FourCC("R00F"), Faction.UNLIMITED); //Mithril Armor
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhfl"), Faction.UNLIMITED); //Flare
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhfs"), Faction.UNLIMITED); //Dragmentation Shards
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhlh"), Faction.UNLIMITED); //Improved Lumber Harvesting
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhac"), Faction.UNLIMITED); //Improved Masonry
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhri"), Faction.UNLIMITED); //Long Rifles
      FACTION_IRONFORGE.ModObjectLimit(FourCC("Rhhb"), Faction.UNLIMITED); //Storm Hammers
      FACTION_IRONFORGE.ModObjectLimit(FourCC("R063"), Faction.UNLIMITED); //Thunder Ale
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_RHME_PYRITE_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_RHAR_PYRITE_ARMOR_PLATING_UNIVERSAL_UPGRADE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R00V_RUNE_PRIEST_MASTER_TRAINING_IRONFORGE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R00N_IMPROVED_SWIG_IRONFORGE_TAVERN, Faction.UNLIMITED);
      FACTION_IRONFORGE.ModObjectLimit(Constants.UPGRADE_R08K_TITANFORGE_ARTIFACT_IRONFORGE, Faction.UNLIMITED);

      FACTION_IRONFORGE.ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
      FACTION_IRONFORGE.ModAbilityAvailability(Constants.ABILITY_A0GA_SUMMON_GARRISON_LORDAERON, -1);
      FACTION_IRONFORGE.ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      FACTION_IRONFORGE.ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      FACTION_IRONFORGE.ModAbilityAvailability(Constants.ABILITY_A0IH_SPIKED_BARRICADES_DWARF_KEEP, -1);
      
      FactionManager.Register(FACTION_IRONFORGE);
    }
  }
}