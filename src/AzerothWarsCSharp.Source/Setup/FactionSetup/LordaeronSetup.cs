using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.FactionSetup
{
  public static class LordaeronSetup
  {
    public static Faction FactionLordaeron { get; private set; }

    public static void Setup()
    {
      FactionLordaeron = new Faction("Lordaeron", PLAYER_COLOR_BLUE, "|c000042ff",
        "ReplaceableTextures\\CommandButtons\\BTNArthas.blp")
      {
        StartingGold = 150,
        StartingLumber = 500,
        UndefeatedResearch = FourCC("R05M"),
        CinematicMusic = "Comradeship",
        IntroText = @"You are playing as the royal |cff4242ebKingdom of Lordaeron|r.

You start the game with the largest territory, but the Plague of Undeath is coming.

Secure your major cities by clearing out clusters of enemies and fortify your Kingdom as much as possible.

Keep an eye out for the Cult of the Damned, they have several agents in your lands that will infect your buidings. 
Burn these infected buildings to weaken the Cult's power."
      };

      //Structures
      FactionLordaeron.ModObjectLimit(FourCC("htow"), Faction.UNLIMITED); //Town Hall
      FactionLordaeron.ModObjectLimit(FourCC("hkee"), Faction.UNLIMITED); //Keep
      FactionLordaeron.ModObjectLimit(FourCC("hcas"), Faction.UNLIMITED); //Castle
      FactionLordaeron.ModObjectLimit(FourCC("hhou"), Faction.UNLIMITED); //Farm
      FactionLordaeron.ModObjectLimit(FourCC("halt"), Faction.UNLIMITED); //Altar of Kings
      FactionLordaeron.ModObjectLimit(FourCC("hbar"), Faction.UNLIMITED); //Barracks
      FactionLordaeron.ModObjectLimit(FourCC("hbla"), Faction.UNLIMITED); //Blacksmith
      FactionLordaeron.ModObjectLimit(FourCC("h035"), Faction.UNLIMITED); //Chapel
      FactionLordaeron.ModObjectLimit(FourCC("hwtw"), Faction.UNLIMITED); //Scout Tower
      FactionLordaeron.ModObjectLimit(FourCC("hgtw"), Faction.UNLIMITED); //Guard Tower
      FactionLordaeron.ModObjectLimit(FourCC("h006"), Faction.UNLIMITED); //Guard Tower (Improved)
      FactionLordaeron.ModObjectLimit(FourCC("hctw"), Faction.UNLIMITED); //Cannon Tower
      FactionLordaeron.ModObjectLimit(FourCC("h007"), Faction.UNLIMITED); //Cannon Tower (Improved)
      FactionLordaeron.ModObjectLimit(FourCC("hshy"), Faction.UNLIMITED); //Alliance Shipyard
      FactionLordaeron.ModObjectLimit(FourCC("nmrk"), Faction.UNLIMITED); //Marketplace
      FactionLordaeron.ModObjectLimit(FourCC("h06C"), Faction.UNLIMITED); //Aviary
      FactionLordaeron.ModObjectLimit(FourCC("h094"), Faction.UNLIMITED); //Siege Camp

      //Units
      FactionLordaeron.ModObjectLimit(FourCC("hpea"), Faction.UNLIMITED); //Peasant
      FactionLordaeron.ModObjectLimit(FourCC("hbot"), 12); //Alliance Transport Ship
      FactionLordaeron.ModObjectLimit(FourCC("hdes"), 12); //Alliance Frigate
      FactionLordaeron.ModObjectLimit(FourCC("hbsh"), 6); //Alliance Battle Ship
      FactionLordaeron.ModObjectLimit(FourCC("hfoo"), Faction.UNLIMITED); //Footman
      FactionLordaeron.ModObjectLimit(FourCC("hkni"), Faction.UNLIMITED); //Knight
      FactionLordaeron.ModObjectLimit(FourCC("nchp"), Faction.UNLIMITED); //Cleric
      FactionLordaeron.ModObjectLimit(FourCC("h00F"), 6); //Paladin
      FactionLordaeron.ModObjectLimit(FourCC("nwe2"), 6); //Thunder Eagle
      FactionLordaeron.ModObjectLimit(FourCC("h01C"), Faction.UNLIMITED); //Longbowman
      FactionLordaeron.ModObjectLimit(FourCC("n03K"), Faction.UNLIMITED); //Chaplain
      FactionLordaeron.ModObjectLimit(FourCC("hcth"), Faction.UNLIMITED); //Silver Hand Squire
      FactionLordaeron.ModObjectLimit(FourCC("h02Q"), 6); //Pegasus Knight
      FactionLordaeron.ModObjectLimit(FourCC("e017"), 8); //Scorpion
      FactionLordaeron.ModObjectLimit(FourCC("o02F"), 6); //Mangonel
      FactionLordaeron.ModObjectLimit(FourCC("h09Y"), 2); //Throne Guard

      //Demis
      FactionLordaeron.ModObjectLimit(FourCC("h012"), 1); //Falric

      FactionLordaeron.ModObjectLimit(FourCC("Hart"), 1); //Arthas
      FactionLordaeron.ModObjectLimit(FourCC("Huth"), 1); //Uther
      FactionLordaeron.ModObjectLimit(FourCC("H01J"), 1); //Mograine

      FactionLordaeron.ModObjectLimit(FourCC("Harf"), 1); //Arthas

      //Upgrades
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R02E_LIGHT_S_PRAISE_MASTER_TRAINING_ARATHOR_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R00I_MAGE_MASTER_TRAINING_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R00K_POWER_INFUSION_4_SHARED, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_RHSE_MAGIC_SENTRY_PURPLE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_RHAN_ANIMAL_WAR_TRAINING_DARK_GREEN_PURPLE_RESEARCH, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_RHLH_IMPROVED_LUMBER_HARVESTING_ADVANCED_LUMBER_HARVESTING_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R04D_SEAL_OF_RIGHTEOUSNESS_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R01P_ENSNARE_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R06Q_PALADIN_MASTER_TRAINING_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R04A_RAPID_FIRE_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R01Q_PEGASUS_TAMING_LORDAERON, Faction.UNLIMITED);

      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R08E_JOIN_THE_CRUSADE_LORDAERON, Faction.UNLIMITED);
      FactionLordaeron.ModObjectLimit(Constants.UPGRADE_R08F_GARITHOS_MIND_CONTROL_LORDAERON, Faction.UNLIMITED);

      //Todo: these probably should be in some kind of ability library, not here
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0KC_INCINERATE_PURPLE_ALEXANDROS, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0MQ_PULVERIZE_PURPLE_ALEXANDROS, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0NP_COMMUNION_ALEXANDROS_SPELLBOOK, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0N2_GRASPING_VINES_TREANTS, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0GD_SUMMON_GARRISON_STORMWIND, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0GC_REPLENISH_MANA_ORANGE_KEEPS_CAPITALS, -1);
      FactionLordaeron.ModAbilityAvailability(Constants.ABILITY_A0K5_DWARVEN_MASONRY_CASTLES_YELLOW, -1);
      
      FactionManager.Register(FactionLordaeron);
    }
  }
}