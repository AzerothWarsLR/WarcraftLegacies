using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class ZandalarObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
   {
      //Buildings
      yield return new(UNIT_O03R_GREAT_HALL_CREEP_T1, Unlimited, TownHall);
      yield return new(UNIT_O03Y_STRONGHOLD_CREEP_T2,Unlimited, Keep);
      yield return new(UNIT_O03Z_FORTRESS_CREEP_T3, Unlimited, Castle);
      yield return new(UNIT_O045_DWELLING_CREEP_FARM, Unlimited, Farm);
      yield return new(UNIT_O047_BAZAAR_CREEP_SHOP, Unlimited, Shop);
      yield return new(UNIT_O046_WATCH_TOWER_CREEP_TOWER, Unlimited, Tower);
      yield return new(UNIT_O048_IMPROVED_WATCH_TOWER_CREEP_TOWER_2, Unlimited, Tower);
      yield return new(UNIT_O040_ALTAR_OF_LOA_CREEP_ALTAR, Unlimited, Altar);
      yield return new(UNIT_O041_TRAINING_GROUND_CREEP_BARRACKS, Unlimited, Barracks);
      yield return new(UNIT_O043_SPIRIT_SPIRE_CREEP_MAGIC, Unlimited, Magic);
      yield return new(UNIT_O044_DINOSAUR_PEN_ZANDALAR_SPECIALIST, Unlimited, Specialist);
      yield return new(UNIT_O04X_LOA_SHRINE_CREEP_SIEGE, Unlimited, Specialist);
      yield return new(UNIT_O042_WAR_MILL_CREEP_RESEARCH, Unlimited, Research);
      yield return new(UNIT_O049_GOLDEN_DOCK_CREEP_SHIPYARD, Unlimited, Shipyard);
      //Townhall
      yield return new(UNIT_O04A_GATHERER_CREEP_ZANDALARI_WORKER, Unlimited, Builder);
      yield return new(UNIT_O04E_BONESEER_CREEP, 6, Elite);
      //Barracks
      yield return new(UNIT_H021_WATCHER_CREEP, Unlimited);
      yield return new(UNIT_O04D_SCOUT_CREEP, Unlimited);
      yield return new(UNIT_H05D_RAPTOR_RIDER_CREEP, Unlimited);
      //Magic
      yield return new(UNIT_O04G_HARUSPEX_CREEP, Unlimited);
      yield return new(UNIT_O04F_HEX_DOCTOR_CREEP, Unlimited);
      yield return new(UNIT_MD42_LOA_MEDIUM_CREEP, 6);
      //Specialist 1
      yield return new(UNIT_NSTW_STORM_WYRM_ZANDALAR, 3);
      yield return new(UNIT_MD47_DIREHORN_ZANDALAR, 12);
      yield return new(UNIT_MD43_THRONE_OF_WAR_ZANDALAR, 3);
      //Specialist 2
      yield return new(UNIT_MD44_RAVAGER_ZANDALAR, 12);
      yield return new(UNIT_MD45_BEAR_RIDER_ZANDALAR, 6);
      yield return new(UNIT_MD46_WARLORD_ZANDALAR, 12);
      //Altar
      yield return new(UNIT_MD39_ZANDALARI_PROPHET_ZANDALAR, 1);
      yield return new(UNIT_MD41_KING_OF_THE_ZANDALARI_ZANDALAR, 1);
      yield return new(UNIT_MD40_DEMIGOD_ZANDALAR, 1);
      //Upgrades
      yield return new(UPGRADE_R070_HARUSPEX_ADEPT_TRAINING_TROLL, Unlimited);
      yield return new(UPGRADE_R071_HEX_DOCTOR_ADEPT_TRAINING_TROLL, Unlimited);
      yield return new(UPGRADE_MD50_LOA_MEDIUM_ADEPT_TRAINING_TROLL, Unlimited);
      yield return new(UPGRADE_MD53_TROLL_REGENERATION_ZANDALAR, Unlimited);
  }
}
