﻿using System.Collections.Generic;

namespace WarcraftLegacies.Shared.FactionObjectLimits
{
  public static class SkywallObjectLimitData
  {
    private const int Unlimited = 200;

    public static IEnumerable<ObjectLimit> GetAllObjectLimits()
    {
      yield return new(Constants.UNIT_N05Q_HOLDFAST_ELEMENTAL_T1, Unlimited);
      yield return new(Constants.UNIT_N05W_FORTIFIED_BURG_ELEMENTAL_T2, Unlimited);
      yield return new(Constants.UNIT_N06R_GREAT_ALCAZAR_ELEMENTAL_T3, Unlimited);
      yield return new(Constants.UNIT_H03I_PROCESSING_FACILITY_ELEMENTAL_RESEARCH, Unlimited);
      yield return new(Constants.UNIT_N08A_ARCANE_FOUNDRY_ELEMENTAL_BARRACKS, Unlimited);
      yield return new(Constants.UNIT_N07N_PAVILION_ELEMENTAL_MAGIC, Unlimited);
      yield return new(Constants.UNIT_N08B_DJINN_PALACE_ELEMENTAL_SPECIALIST, Unlimited);
      yield return new(Constants.UNIT_N07J_FORGE_OF_WISHES_ELEMENTAL_SHOP, Unlimited);
      yield return new(Constants.UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR, Unlimited);
      yield return new(Constants.UNIT_N08L_LATICE_SPIRE_ELEMENTAL_TOWER, Unlimited);
      yield return new(Constants.UNIT_N08N_IMPROVED_LATICE_SPIRE_ELEMENTAL_TOWER, Unlimited);

      yield return new(Constants.UNIT_LS05_SHAPER_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_N08S_ARMORED_MISTRAL_ELEMENTAL, 6);
      yield return new(Constants.UNIT_O01I_ANIMATED_ARMOR_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_SFH5_AIR_REVENANT_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_SGH5_BALLISTA_CARRIER_ELEMENTAL, 8);
      yield return new(Constants.UNIT_O05E_LURKING_TEMPEST_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_N08Z_WHIPPING_WIND_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_OETL_TIDAL_LORD_ELEMENTAL, 6);
      yield return new(Constants.UNIT_U02P_DJINN_ELEMENTAL, 4);
      yield return new(Constants.UNIT_LS06_EFREET_ELEMENTAL, 4);
      yield return new(Constants.UNIT_N0CG_CORE_HOUND_RAGNAROS, 12);
      yield return new(Constants.UNIT_N0CF_FIRE_WYRM_RAGNAROS, 2);

      yield return new("e020", Unlimited); //Shipyard
      yield return new("etrs", Unlimited); //Night Elf Transport Ship
      yield return new("h0AU", Unlimited); // Scout
      yield return new("h0AV", Unlimited); // Frigate
      yield return new("h0B1", Unlimited); // Fireship
      yield return new("h057", Unlimited); // Galley
      yield return new("h0B4", Unlimited); // Boarding
      yield return new("h0BA", Unlimited); // Juggernaut
      yield return new("h0B8", 6); // Bombard

      yield return new(Constants.UNIT_U02K_LORD_OF_THE_FIRELANDS_ELEMENTAL, 1);
      yield return new(Constants.UNIT_E023_GRAND_VIZIER_ELEMENTAL, 1);
      yield return new(Constants.UNIT_U01S_WINDLORD_ELEMENTAL, 1);
    }
  }
}