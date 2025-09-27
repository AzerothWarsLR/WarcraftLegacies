using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class ZandalarObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_O03R_GREAT_HALL_ZANDALARI_T1, Unlimited);
    yield return new(UNIT_O03Y_STRONGHOLD_ZANDALARI_T2, Unlimited);
    yield return new(UNIT_O03Z_FORTRESS_ZANDALARI_T3, Unlimited);
    yield return new(UNIT_O040_ALTAR_OF_LOA_ZANDALARI_ALTAR, Unlimited, UnitCategory.Altar);
    yield return new(UNIT_O041_TRAINING_GROUND_ZANDALARI_BARRACKS, Unlimited);
    yield return new(UNIT_O042_WAR_MILL_ZANDALARI_RESEARCH, Unlimited);
    yield return new(UNIT_O044_DINOSAUR_PEN_ZANDALARI_SPECIALIST, Unlimited);
    yield return new(UNIT_O043_SPIRIT_SPIRE_ZANDALARI_MAGIC, Unlimited);
    yield return new(UNIT_O045_DWELLING_ZANDALARI_FARM, Unlimited);
    yield return new(UNIT_O046_WATCH_TOWER_ZANDALARI_TOWER, Unlimited);
    yield return new(UNIT_O048_IMPROVED_WATCH_TOWER_ZANDALARI_TOWER_2, Unlimited);
    yield return new(UNIT_O047_BAZAAR_ZANDALARI_SHOP, Unlimited);
    yield return new(UNIT_O049_GOLDEN_DOCK_ZANDALARI_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_O04X_LOA_SHRINE_ZANDALARI_SIEGE, Unlimited);
    yield return new(UNIT_O04A_GATHERER_TROLL_ZANDALARI_WORKER, Unlimited);
    yield return new(UNIT_H021_WATCHER_TROLL, Unlimited);
    yield return new(UNIT_O04D_SCOUT_TROLL, Unlimited);
    yield return new(UNIT_N09E_STORM_WYRM_TROLL, 2);
    yield return new(UNIT_E00Z_DIREHORN_TROLL, 8);
    yield return new(UNIT_O04F_HEX_DOCTOR_TROLL, Unlimited);
    yield return new(UNIT_O04G_HARUSPEX_TROLL, Unlimited);
    yield return new(UNIT_O04E_BONESEER_TROLL, 6);
    yield return new(UNIT_H05D_RAPTOR_RIDER_TROLL, Unlimited);
    yield return new(UNIT_O021_RAVAGER_ZANDALAR, 12);
    yield return new(UNIT_NFTK_WARLORD_WARSONG, 12);
    yield return new(UNIT_O02K_NALORAKK_S_RIDER_ZANDALAR, 6);
    yield return new(UNIT_N0DN_FOLLOWER_OF_SHADRA_ZANDALAR, 6);
    yield return new(UNIT_E01Z_THRONE_OF_WAR_TROLL, 3);
    yield return new(UNIT_OBOT_HORDE_TRANSPORT_SHIP_WARSONG_FROSTWOLF_FEL_HORDE, Unlimited);
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);
    yield return new(UNIT_O026_GOD_KING_OF_THE_ZANDALARI_TRIBE_TROLL, 1);
    yield return new(UNIT_O01J_THE_DARK_PROPHET_TROLL, 1);
    yield return new(UNIT_U023_THE_SOULFLAYER_LEGION, 1);
    yield return new(UNIT_H06Q_ABERRATION_ZANDALAR, 1);
    yield return new(UPGRADE_RERS_RESISTANT_SKIN_MOUNTAIN_GIANT, Unlimited);
    yield return new(UPGRADE_R00H_ANIMAL_COMPANION_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_R070_HARUSPEX_ADEPT_TRAINING_TROLL, Unlimited);
    yield return new(UPGRADE_R071_HEX_DOCTOR_MASTER_TRAINING_TROLL, Unlimited);
  }
}
