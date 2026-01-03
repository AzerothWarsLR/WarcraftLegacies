using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class IronforgeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H07E_MINING_COLONY_IRONFORGE_T1, Unlimited, TownHall);
    yield return new(UNIT_H07F_DWARF_HOLD_IRONFORGE_T2, Unlimited, TownHall);
    yield return new(UNIT_H07G_GREAT_HOLD_IRONFORGE_T3, Unlimited, TownHall);
    yield return new(UNIT_H01S_TAVERN_IRONFORGE_FARM, Unlimited, Farm);
    yield return new(UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H07C_MUSTERING_HALL_IRONFORGE_BARRACKS, Unlimited, Barracks);
    yield return new(1751938413, Unlimited, Research); // Lumber Mill
    yield return new(UNIT_H048_FORGEWORKS_IRONFORGE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H042_PINNACLE_IRONFORGE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_HARM_IRONFORGE_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_HGRA_GRYPHON_AVIARY_IRONFORGE_SIEGE, Unlimited, FlyingBuilding);
    yield return new(UNIT_H07H_SCOUT_TOWER_IRONFORGE_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07J_CANNON_TOWER_IRONFORGE_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07K_IMPROVED_CANNON_TOWER_IRONFORGE_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07D_SHIPYARD_IRONFORGE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_N07U_EXPLORER_S_VAULT_IRONFORGE_SHOP, Unlimited, Shop);
    yield return new(UNIT_H07I_GUARD_TOWER_IRONFORGE_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07L_IMPROVED_GUARD_TOWER_IRONFORGE_TOWER, Unlimited, Tower);

    yield return new(UNIT_H019_MASON_IRONFORGE_WORKER, Unlimited, Worker);
    yield return new(UNIT_HRIF_RIFLEMAN_IRONFORGE, Unlimited, Marksman);
    yield return new(UNIT_HMTM_MORTAR_TEAM_IRONFORGE, 9, Siege);
    yield return new(UNIT_N0CZ_DREADNAUGHT_IRONFORGE, 4, Tank);
    yield return new(UNIT_HGRY_GRYPHON_RIDER_IRONFORGE, 6, new List<UnitCategory> { Flyer, Destroyer });
    yield return new(UNIT_H018_WARRIOR_IRONFORGE, Unlimited, Tank);
    yield return new(UNIT_H01L_THANE_IRONFORGE_ELITE, 6, new List<UnitCategory> { Elite, Tank, Support });
    yield return new(UNIT_H037_ENGINEER_IRONFORGE, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_N02D_WAR_GOLEM_IRONFORGE, Unlimited, new List<UnitCategory> { Tank, AntiMage });
    yield return new(UNIT_H01P_STEAM_TANK_IRONFORGE, 3, new List<UnitCategory> { Siege, Destroyer, Support });
    yield return new(UNIT_N00C_RUNE_PRIEST_IRONFORGE, Unlimited, Support);
    yield return new(UNIT_H03Z_STORMRIDER_IRONFORGE, 3, new List<UnitCategory> { Flyer, Destroyer, Support });

    yield return new(UNIT_H01M_BAELGUN_FLAMEBEARD_IRONFORGE_DEMI, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_H00S_KING_OF_KHAZ_MODAN_IRONFORGE, 1, Support);
    yield return new(UNIT_HMBR_HIGH_THANE_OF_THE_BRONZEBEARDS_IRONFORGE, 1, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_H03G_EMPEROR_OF_BLACKROCK_RAGNAROS, 1, new List<UnitCategory> { Destroyer, Summoner, Support });
    yield return new(UNIT_H028_THANE_OF_AERIE_PEAK_IRONFORGE, 1, new List<UnitCategory> { Tank, Support });

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UPGRADE_R03H_ENGINEERING_ADEPT_TRAINING_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_R00F_MITHRIL_PLATED_ARMOR_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHFL_FLARE_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHFS_FRAGMENTATION_SHARDS_YELLOW_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHRI_LONG_RIFLES_IRONFORGE, Unlimited);
    yield return new(UPGRADE_RHHB_STORM_HAMMERS_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_R063_QUEST_COMPLETED_GUARDIAN_OF_TIRISFAL, Unlimited);
    yield return new(UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN, Unlimited);
    yield return new(UPGRADE_RHME_COPPER_FORGED_WEAPONRY_UNIVERSAL_UPGRADE, 2);
    yield return new(UPGRADE_RHAR_COPPER_ARMOR_PLATING_UNIVERSAL_UPGRADE, 2);
    yield return new(UPGRADE_R00V_RUNE_PRIEST_ADEPT_TRAINING_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R00Z_ARMOR_PENETRATION_ROUNDS_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R010_IMPROVED_SPELL_RESISTANCE_IRONFORGE, Unlimited);
    yield return new(UPGRADE_R00T_OVERCLOCK_IRONFORGE_STEAM_TANK, Unlimited);
    yield return new(UPGRADE_R00N_IMPROVED_SWIG_IRONFORGE_TAVERN, Unlimited);
    yield return new(UPGRADE_R014_DEEPRUN_TRAM_IRONFORGE, 1);
  }
}
