using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class StormwindObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H06K_TOWN_HALL_STORMWIND_T1, Unlimited, TownHall);
    yield return new(UNIT_H06M_STORMWIND_T2, Unlimited, Keep);
    yield return new(UNIT_H06N_CASTLE_STORMWIND_T3, Unlimited, Castle);
    yield return new(UNIT_H072_HOMESTEAD_STORMWIND_FARM, Unlimited, Farm);
    yield return new(UNIT_H06T_ALTAR_OF_KINGS_STORMWIND_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H06E_BARRACKS_STORMWIND_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_H06F_BLACKSMITH_STORMWIND_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H06A_SMITHY_STORMWIND_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_HARS_ARCANE_SANCTUM_STORMWIND_MAGIC, Unlimited, Magic);
    yield return new(UNIT_H06V_SCOUT_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H06W_GUARD_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H070_IMPROVED_GUARD_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H06X_CANNON_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H071_IMPROVED_CANNON_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_N07T_AUCTION_HOUSE_STORMWIND_SHOP, Unlimited, Shop);
    yield return new(UNIT_H06D_ROYAL_HARBOUR_STORMWIND_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_H06Y_ARCANE_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H06Z_IMPROVED_ARCANE_TOWER_STORMWIND_TOWER, Unlimited, Tower);
    yield return new(UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, 10, Tower);
    yield return new(UNIT_H05J_CHAMPION_S_HALL_STORMWIND_OTHER, 1, Research);
    yield return new(UNIT_H05A_WIZARD_S_SANCTUM_STORMWIND_OTHER, 1, Research);

    yield return new(UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, Unlimited, Worker);
    yield return new(UNIT_H02O_BLADESMAN_STORMWIND, Unlimited, Tank);
    yield return new(UNIT_H03K_MARSHAL_STORMWIND, 12, Tank);
    yield return new(UNIT_H00A_SPEARMAN_STORMWIND, Unlimited, Marksman);
    yield return new(UNIT_H01B_OUTRIDER_STORMWIND, Unlimited, Fighter);
    yield return new(UNIT_H05F_STORMWIND_CHAMPION_STORMWIND_ELITE, 6, new List<UnitCategory> { Elite, Fighter, Support });
    yield return new(UNIT_N05L_CONJURER_STORMWIND_ELITE, 6, new List<UnitCategory> { Destroyer, Support, Summoner });
    yield return new(UNIT_H00J_CLERGYMAN_STORMWIND, Unlimited, Support);
    yield return new(UNIT_N06N_GUNSHIP_STORMWIND, 6, new List<UnitCategory> { Flyer, Marksman, Support });
    yield return new(UNIT_N093_CHAPLAIN_STORMWIND, Unlimited, Support);
    yield return new(UNIT_O06K_SIEGE_TOWER_STORMWIND, 5, Siege);

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UNIT_H060_CARRIER_FLAGSHIP_STORMWIND, 3);

    yield return new(UNIT_H00R_KING_OF_STORMWIND_STORMWIND, 1, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_H017_HIGHLORD_OF_THE_ALLIANCE_STORMWIND, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_H05Y_LORD_WIZARD_STORMWIND, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_H00Z_CROWN_PRINCE_OF_STROMGARDE_STORMWIND, 1, new List<UnitCategory> { Tank, Support });

    yield return new(UPGRADE_R02E_LIGHT_S_PRAISE_ADEPT_TRAINING_ARATHOR_LORDAERON, Unlimited);
    yield return new(UPGRADE_R005_CLERGYMAN_ADEPT_TRAINING_ARATHOR, Unlimited);
    yield return new(UPGRADE_R02B_CHAINMAIL_LAYERING_ARATHOR, Unlimited);
    yield return new(UPGRADE_RHAN_ANIMAL_WAR_TRAINING_DARK_GREEN_PURPLE_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHSE_MAGIC_SENTRY, Unlimited);
    yield return new(UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);
    yield return new(UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2, Unlimited);
    yield return new(UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3, Unlimited);
    yield return new(UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3, Unlimited);
    yield return new(UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2, Unlimited);
    yield return new(UPGRADE_R03W_KNOWLEDGE_OF_HONOR_HOLD_ARATHOR_T2, Unlimited);
    yield return new(UPGRADE_R038_QUEST_COMPLETED_OUTSKIRTS, Unlimited);
    yield return new(UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3, Unlimited);
    yield return new(UPGRADE_R02Y_IMPROVED_GLAIVES_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1, Unlimited);
    yield return new(UPGRADE_R03A_QUEST_COMPLETED_WAR_OF_THE_SPIDER, Unlimited);
    yield return new(UPGRADE_R03T_ELECTRIC_STRIKE_RITUAL_ARATHOR_T1, Unlimited);
    yield return new(UPGRADE_R03U_SOLAR_FLARE_RITUAL_ARATHOR_T1, Unlimited);
    yield return new(UPGRADE_R03X_CONJURERS_ARATHOR_T3, Unlimited);
  }
}
