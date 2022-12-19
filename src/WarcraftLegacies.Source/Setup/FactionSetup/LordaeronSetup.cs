using MacroTools;
using MacroTools.FactionSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.FactionSetup
{
  public static class LordaeronSetup
  {
    public static Faction? Lordaeron { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Lordaeron = new Faction("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff",
        "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        UndefeatedResearch = FourCC("R05M"),
        CinematicMusic = "Comradeship",
        ControlPointDefenderTemplateUnitTypeId = Constants.UNIT_HGTW_GUARD_TOWER_LORDAERON,
        IntroText = @"You are playing as the royal |cff4242ebKingdom of Lordaeron|r.

You start the game with the largest territory, but the Plague of Undeath is coming.

Secure your major cities by clearing out clusters of enemies and fortify your Kingdom as much as possible.

Keep an eye out for the Cult of the Damned, they have several agents in your lands that will infect your buidings. 
Burn these infected buildings to weaken the Cult's power."
      };

      //Structures
      Lordaeron.ModObjectLimit(FourCC("htow"), Faction.UNLIMITED); //Town Hall
      Lordaeron.ModObjectLimit(FourCC("hkee"), Faction.UNLIMITED); //Keep
      Lordaeron.ModObjectLimit(FourCC("hcas"), Faction.UNLIMITED); //Castle
      Lordaeron.ModObjectLimit(FourCC("hhou"), Faction.UNLIMITED); //Farm
      Lordaeron.ModObjectLimit(FourCC("halt"), Faction.UNLIMITED); //Altar of Kings
      Lordaeron.ModObjectLimit(FourCC("hbar"), Faction.UNLIMITED); //Barracks
      Lordaeron.ModObjectLimit(FourCC("hbla"), Faction.UNLIMITED); //Blacksmith
      Lordaeron.ModObjectLimit(FourCC("h035"), Faction.UNLIMITED); //Chapel
      Lordaeron.ModObjectLimit(FourCC("hwtw"), Faction.UNLIMITED); //Scout Tower
      Lordaeron.ModObjectLimit(FourCC("hgtw"), Faction.UNLIMITED); //Guard Tower
      Lordaeron.ModObjectLimit(FourCC("h006"), Faction.UNLIMITED); //Guard Tower (Improved)
      Lordaeron.ModObjectLimit(FourCC("hctw"), Faction.UNLIMITED); //Cannon Tower
      Lordaeron.ModObjectLimit(FourCC("h007"), Faction.UNLIMITED); //Cannon Tower (Improved)
      Lordaeron.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED); //Alliance Shipyard
      Lordaeron.ModObjectLimit(FourCC("nmrk"), Faction.UNLIMITED); //Marketplace
      Lordaeron.ModObjectLimit(FourCC("h06C"), Faction.UNLIMITED); //Aviary
      Lordaeron.ModObjectLimit(FourCC("h094"), Faction.UNLIMITED); //Siege Camp

      //Units
      Lordaeron.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      Lordaeron.ModObjectLimit(FourCC("hbot"), Faction.UNLIMITED); //Alliance Transport Ship
      Lordaeron.ModObjectLimit(FourCC("hdes"), Faction.UNLIMITED); //Alliance Frigate
      Lordaeron.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      Lordaeron.ModObjectLimit(FourCC("hfoo"), Faction.UNLIMITED); //Footman
      Lordaeron.ModObjectLimit(FourCC("hkni"), Faction.UNLIMITED); //Knight
      Lordaeron.ModObjectLimit(FourCC("nchp"), Faction.UNLIMITED); //Cleric
      Lordaeron.ModObjectLimit(FourCC("h00F"), 6); //Paladin
      Lordaeron.ModObjectLimit(FourCC("nwe2"), 6); //Thunder Eagle
      Lordaeron.ModObjectLimit(FourCC("h01C"), Faction.UNLIMITED); //Longbowman
      Lordaeron.ModObjectLimit(FourCC("n03K"), Faction.UNLIMITED); //Chaplain
      Lordaeron.ModObjectLimit(FourCC("hcth"), Faction.UNLIMITED); //Silver Hand Squire
      Lordaeron.ModObjectLimit(FourCC("h02Q"), 6); //Pegasus Knight
      Lordaeron.ModObjectLimit(FourCC("e017"), 8); //Scorpion
      Lordaeron.ModObjectLimit(FourCC("o02F"), 6); //Mangonel
      Lordaeron.ModObjectLimit(FourCC("h09Y"), 2); //Throne Guard

      //Demis
      Lordaeron.ModObjectLimit(FourCC("h012"), 1); //Falric

      Lordaeron.ModObjectLimit(FourCC("Hart"), 1); //Arthas
      Lordaeron.ModObjectLimit(FourCC("Huth"), 1); //Uther
      Lordaeron.ModObjectLimit(FourCC("H01J"), 1); //Mograine

      Lordaeron.ModObjectLimit(FourCC("Harf"), 1); //Arthas

      //Upgrades
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R02E_LIGHT_S_PRAISE_MASTER_TRAINING_ARATHOR_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R00I_MAGE_MASTER_TRAINING_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R00K_POWER_INFUSION_4_SHARED, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_RHSE_MAGIC_SENTRY_PURPLE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_RHAN_ANIMAL_WAR_TRAINING_DARK_GREEN_PURPLE_RESEARCH, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_RHLH_IMPROVED_LUMBER_HARVESTING_ADVANCED_LUMBER_HARVESTING_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R04D_SEAL_OF_RIGHTEOUSNESS_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R01P_ENSNARE_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R06Q_PALADIN_MASTER_TRAINING_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R04A_RAPID_FIRE_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R01Q_PEGASUS_TAMING_LORDAERON, Faction.UNLIMITED);

      Lordaeron.ModObjectLimit(Constants.UPGRADE_R08E_JOIN_THE_CRUSADE_LORDAERON, Faction.UNLIMITED);
      Lordaeron.ModObjectLimit(Constants.UPGRADE_R08F_GARITHOS_MIND_CONTROL_LORDAERON, Faction.UNLIMITED);

      //Todo: these probably should be in some kind of ability library, not here
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0KC_INCINERATE_PURPLE_ALEXANDROS, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0MQ_PULVERIZE_PURPLE_ALEXANDROS, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0NP_COMMUNION_ALEXANDROS_SPELLBOOK, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0N2_GRASPING_VINES_TREANTS, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      Lordaeron.ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
      
      Lordaeron.AddGoldMine(preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(13617, 8741)));
      
      FactionManager.Register(Lordaeron);
    }
  }
}