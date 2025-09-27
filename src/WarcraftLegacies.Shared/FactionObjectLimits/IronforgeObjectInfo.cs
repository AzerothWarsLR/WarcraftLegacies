using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class IronforgeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H07E_MINING_COLONY_IRONFORGE_T1, Unlimited);
    yield return new(UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, Unlimited);
    yield return new(UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, Unlimited);
    yield return new(UNIT_H01S_TAVERN_IRONFORGE_FARM, Unlimited, UnitCategory.Farm);
    yield return new(UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, Unlimited);
    yield return new(UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, Unlimited);
    yield return new(1751938413, Unlimited); // Lumber Mill
    yield return new(UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, Unlimited);
    yield return new(UNIT_H042_PINNACLE_IRONFORGE_MAGIC, Unlimited);
    yield return new(UNIT_HARM_WORKSHOP_IRONFORGE_SPECIALIST, Unlimited);
    yield return new(UNIT_HGRA_GRYPHON_AVIARY_IRONFORGE_SIEGE, Unlimited);
    yield return new(UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, Unlimited);
    yield return new(UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, Unlimited);
    yield return new(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, Unlimited);
    yield return new(UNIT_H07D_SHIPYARD_IRONFORGE_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP, Unlimited);
    yield return new(UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, Unlimited);
    yield return new(UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, Unlimited);
    yield return new(UNIT_H019_MASON_IRONFORGE_WORKER, Unlimited);
    yield return new(UNIT_HRIF_RIFLEMAN_IRONFORGE, Unlimited);
    yield return new(UNIT_HMTM_MORTAR_TEAM_IRONFORGE, 9);
    yield return new(UNIT_N0CZ_DREADNAUGHT_DWARF, 4);
    yield return new(UNIT_HGRY_GRYPHON_RIDER_IRONFORGE, 6);
    yield return new(UNIT_H018_WARRIOR_IRONFORGE, Unlimited);
    yield return new(UNIT_H01L_THANE_IRONFORGE_ELITE, 6);
    yield return new(UNIT_H037_ENGINEER_IRONFORGE, Unlimited);
    yield return new(UNIT_N02D_WAR_GOLEM_IRONFORGE, Unlimited);
    yield return new(UNIT_H01P_STEAM_TANK_IRONFORGE, 3);
    yield return new(UNIT_N00C_RUNE_PRIEST_IRONFORGE, Unlimited);
    yield return new(UNIT_H03Z_STORMRIDER_IRONFORGE, 3);
    yield return new(UNIT_H01M_BAELGUN_FLAMEBEARD_IRONFORGE_DEMI, 1);
    yield return new(UNIT_H00S_KING_OF_KHAZ_MODAN_KHAZ_MODAN, 1);
    yield return new(UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_KHAZ_MODAN, 1);
    yield return new(UNIT_H03G_EMPEROR_OF_BLACKROCK_RAGNAROS, 1);
    yield return new(UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE, 1);
    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UPGRADE_R03H_ENGINEERING_GUILDMASTER_TRAINING_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_R00F_MITHRIL_PLATED_ARMOR_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHFL_FLARE_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHFS_FRAGMENTATION_SHARDS_YELLOW_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHRI_LONG_RIFLES_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHHB_STORM_HAMMERS_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_R063_QUEST_COMPLETED_GUARDIAN_OF_TIRISFAL, Unlimited);
    yield return new(UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_RHME_PYRITE_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, 2);
    yield return new(UPGRADE_RHAR_PYRITE_ARMOR_PLATING_UNIVERSAL_UPGRADE, 2);
    yield return new(UPGRADE_R00V_RUNE_PRIEST_MASTER_TRAINING_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, Unlimited);
    yield return new(UPGRADE_R00N_IMPROVED_SWIG_IRONFORGE_TAVERN, Unlimited);
    yield return new(UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);
  }
}
