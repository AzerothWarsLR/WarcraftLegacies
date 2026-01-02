using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class QuelthalasObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H033_STEADING_QUELTHALAS_T1, Unlimited, TownHall);
    yield return new(UNIT_H03S_MANSION_QUELTHALAS_T2, Unlimited, TownHall);
    yield return new(UNIT_H03T_PALACE_QUELTHALAS_T3, Unlimited, TownHall);
    yield return new(UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC, Unlimited, Magic);
    yield return new(UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_NEGT_SUN_TOWER, Unlimited, Tower);
    yield return new(UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP, Unlimited, Shop);
    yield return new(UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, Unlimited, Specialist);
    yield return new(UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST, Unlimited, new List<UnitCategory> { Specialist, Magic });
    yield return new(UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_NEFM_RESIDENCE_QUELTHALAS, Unlimited, Farm);

    yield return new(UNIT_NBEE_ARCHITECT_QUELTHALAS_WORKER, Unlimited, Worker);
    yield return new(UNIT_HHES_SWORDSMAN_QUELTHALAS, Unlimited, Tank);
    yield return new(UNIT_HMPR_PRIEST_QUELTHALAS, Unlimited, Support);
    yield return new(UNIT_HSOR_SORCERESS_QUELTHALAS, Unlimited, Support);
    yield return new(UNIT_HDHW_DRAGONHAWK_RIDER_QUELTHALAS, 6, new List<UnitCategory> { Flyer, Support });
    yield return new(UNIT_NHEA_RANGER_QUELTHALAS, Unlimited, Marksman);
    yield return new(UNIT_E008_BALLISTA_QUELTHALAS, 6, Siege);
    yield return new(UNIT_N00A_FARSTRIDER_QUELTHALAS_ELITE, 6, new List<UnitCategory> { Elite, Marksman });
    yield return new(UNIT_E024_ARCANE_ANNIHILATOR_QUELTHALAS, 6, Marksman);
    yield return new(UNIT_N02F_WARLOCK_QUELTHALAS, 6, new List<UnitCategory> { Destroyer, Summoner });
    yield return new(UNIT_N063_MAGUS_QUELTHALAS, 12, Support);
    yield return new(UNIT_HSPT_SPELLBREAKER_QUELTHALAS, Unlimited, AntiMage);
    yield return new(UNIT_U00J_ARCANE_WAGON_QUELTHALAS, 2, Support);
    yield return new(UNIT_N048_BLOOD_MAGE_QUELTHALAS, 6, new List<UnitCategory> { Destroyer, Summoner });

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UNIT_HVWD_RANGER_GENERAL_OF_SILVERMOON_QUELTHALAS, 1, new List<UnitCategory> { Marksman, Support });
    yield return new(UNIT_H00Q_KING_OF_QUEL_THALAS_QUELTHALAS, 1, new List<UnitCategory> { Tank, Destroyer });
    yield return new(UNIT_H04F_ARCHMAGE_QUELTHALAS, 1, Support);
    yield return new(UNIT_H02E_REGENT_OF_QUEL_THALAS_QUELTHALAS_VASSAL, 1, Fighter);

    yield return new(UPGRADE_R01S_RAPID_SHOTS_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R00G_FEINT_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R01R_ENCHANTED_BOWSTRINGS_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R029_MAGUS_ADEPT_TRAINING_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_RHCD_CLOUD_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_RHSS_CONTROL_MAGIC_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Unlimited);
    yield return new(UPGRADE_RHSE_MAGIC_SENTRY, Unlimited);
    yield return new(UPGRADE_RHPT_PRIEST_ADEPT_TRAINING_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_RHST_SORCERESS_ADEPT_TRAINING_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R004_SUNFURY_TRAINING_QUEL_THALAS, Unlimited);
    yield return new(UPGRADE_R02Y_IMPROVED_GLAIVES_QUEL_THALAS, Unlimited);
  }
}
