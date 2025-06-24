using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits
{
  public static class GilneasObjectInfo
  {
    private const int Unlimited = 200;

    public static IEnumerable<ObjectInfo> GetAllObjectLimits()
    {
      yield return new(UNIT_H01R_TOWN_HALL_GILNEAS_T1, Unlimited, UnitCategory.TownHall); //Townhall
      yield return new(UNIT_H023_KEEP_GILNEAS_T2, Unlimited); //Keep
      yield return new(UNIT_H02C_CASTLE_GILNEAS_T3, Unlimited); //Castle
      yield return new(UNIT_H0A9_MANOR_GILNEAS_OTHER, Unlimited, UnitCategory.GilneasManor); //Greymane Manor
      yield return new(UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, Unlimited, UnitCategory.LightHouse); // Lighthouse
      yield return new(UNIT_H02F_HOUSEHOLD_GILNEAS_FARM, Unlimited, UnitCategory.Farm); //Farm
      yield return new(UNIT_H01T_INN_LORDAERON_OTHER, Unlimited, UnitCategory.SpecailFarm4); //Farm 2
      yield return new(UNIT_H05P_DALARAN_BUILDING_DALARAN_OTHER_1, Unlimited, UnitCategory.SpecailFarm1); //farm in Dalaran
      yield return new(UNIT_H05Q_DALARAN_BUILDING_DALARAN_OTHER_2, Unlimited, UnitCategory.SpecailFarm2); //farm in Dalaran
      yield return new(UNIT_H05O_DALARAN_BUILDING_DALARAN_OTHER_3, Unlimited, UnitCategory.SpecailFarm3); //farm in Dalaran
      yield return new(UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR, Unlimited, UnitCategory.Altar); //Altar
      yield return new(UNIT_H03D_TEMPLE_OF_THE_CURSED_GILNEAS_MAGIC, Unlimited, UnitCategory.Magic); //Temple of the cursed
      yield return new(UNIT_H03E_WORGEN_MANOR_GILNEAS_SPECIALIST, Unlimited,UnitCategory.Specialist); //Worgen Manor
      yield return new(UNIT_N008_TRADE_HOUSE_GILNEAS_SHOP, Unlimited, UnitCategory.Shop); //Marketplace
      yield return new(UNIT_H03H_SHIPYARD_GILNEAS_SHIPYARD, Unlimited, UnitCategory.Shipyard); // Shipyard
      yield return new(UNIT_H03O_BLACKSMITH_GILNEAS_RESEARCH, Unlimited, UnitCategory.Research); //Blacksmith
      yield return new(UNIT_H03Q_CITY_WATCH_GILNEAS_BARRACKS, Unlimited, UnitCategory.Barracks); //City Watch (Barracks)

      yield return new(UNIT_H039_SCOUT_TOWER_GILNEAS_TOWER, Unlimited, UnitCategory.Tower); //Scout Tower
      yield return new(UNIT_H03A_GUARD_TOWER_GILNEAS_TOWER, Unlimited, UnitCategory.Tower2); //Guard Tower  
      yield return new(UNIT_H03B_CANNON_TOWER_GILNEAS_TOWER, Unlimited, UnitCategory.Tower3); //Cannon Tower
      yield return new(UNIT_H052_IMPROVED_GUARD_TOWER_GILNEAS_TOWER, Unlimited, UnitCategory.Tower4); //Improved Guard Tower
      yield return new(UNIT_H04N_IMPROVED_CANNON_TOWER_GILNEAS_TOWER, Unlimited, UnitCategory.Tower5); //Improved Cannon Tower
      yield return new(UNIT_N03G_VIOLET_TOWER_DALARAN, Unlimited, UnitCategory.Tower6); //Violet Towers

      yield return new(UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, Unlimited, UnitCategory.Worker); //Worker
      yield return new(UNIT_H04M_CLERIC_GILNEAS, Unlimited, UnitCategory.CasterSupport); //Cleric
      yield return new(UNIT_N06K_DRUID_OF_THE_SCYTHE_GILNEAS, Unlimited, UnitCategory.CasterBasic); //Druid of the Scythe
      yield return new(UNIT_H04X_HARVEST_WITCH_GILNEAS, 6, UnitCategory.CasterAdvanced); //HarvestWitch
      yield return new(UNIT_O06P_WORGEN_SHAMAN_GILNEAS, 6, UnitCategory.CasterAdvanced2); //Worgen Shaman

      yield return new(UNIT_H04E_PROTECTOR_GILNEAS, Unlimited, UnitCategory.MeleeBasic); //Protector
      yield return new(UNIT_N06L_ARMORED_WOLF_GILNEAS, Unlimited, UnitCategory.MeleeAdvanced); //Armored Wolf
      yield return new(UNIT_O01V_GREYGUARD_GILNEAS, 6, UnitCategory.Elite); //Greyguard
      yield return new(UNIT_O02J_WORGEN_GILNEAS, 12, UnitCategory.MeleeSpecial); //Worgen

      yield return new(UNIT_H03L_SHOTGUNNER_GILNEAS, Unlimited, UnitCategory.RangedBasic); //Shotgunner
      yield return new(UNIT_N067_MINI_SPIDERS, Unlimited); //Spider summon
      yield return new(UNIT_O04U_CYCLONE_CANNON_GILNEAS, 6, UnitCategory.Siege); //Cyclone Cannon

      yield return new(UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS, 1); //Goldrinn
      yield return new(UNIT_TGGN_PRINCESS_OF_GILNEAS_GILNEAS, 1); //Tess
      yield return new(UNIT_HHKL_KING_OF_GILNEAS_GILNEAS, 1); //Genn
      yield return new(UNIT_HPB2_GILNEAN_LORD_GILNEAS, 1); //Darius

      yield return new("hbot", Unlimited); //Alliance Transport Ship
      yield return new("h0AR", Unlimited); //Alliance Scout
      yield return new("h0AX", Unlimited); //Alliance Frigate
      yield return new("h0B3", Unlimited); //Alliance Fireship
      yield return new("h0B0", Unlimited); //Alliance Galley
      yield return new("h0B6", Unlimited); //Alliance Boarding
      yield return new("h0AN", Unlimited); //Alliance Juggernaut
      yield return new("h0B7", 6); //Alliance Bombard
      yield return new(UPGRADE_R04O_CLERIC_MASTER_TRAINING_GILNEAS, Unlimited);
      yield return new(UPGRADE_R04P_DRUID_OF_THE_SCYTHE_MASTER_TRAINING_GILNEAS, Unlimited);
      yield return new(
        UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
        Unlimited);
      yield return new(UPGRADE_R09M_HARVEST_WITCH_MASTER_TRAINING_GILNEAS, Unlimited);
    }
  }
}