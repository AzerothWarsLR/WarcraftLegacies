using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class NazjatarObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_N0C2_PILLAR_OF_WAVES_NZOTH_T1, Unlimited);
    yield return new(UNIT_N0C8_MONUMENT_OF_THE_DEEP_NZOTH_T2, Unlimited);
    yield return new(UNIT_N0C9_TEMPLE_OF_TIDES_NZOTH_T3, Unlimited);
    yield return new(UNIT_N0C1_CORAL_BED_NZOTH_FARM, Unlimited);
    yield return new(UNIT_H0A4_CORAL_FORGE_NZOTH_RESEARCH, Unlimited);
    yield return new(UNIT_N0C4_SPAWNING_GROUNDS_NZOTH_BARRACKS, Unlimited);
    yield return new(UNIT_N0C7_ROYAL_TEMPLE_NZOTH_MAGIC, Unlimited);
    yield return new(UNIT_N0C3_SHRINE_OF_AZSHARA_NZOTH_SPECIALIST, Unlimited);
    yield return new(UNIT_N08V_PORTAL_OF_THE_DEEP_NZOTH_SIEGE, Unlimited);
    yield return new(UNIT_N0BZ_DEEP_VAULT_NZOTH_SHOP, Unlimited);
    yield return new(UNIT_N0C0_ALTAR_OF_THE_QUEEN_NZOTH_ALTAR, Unlimited);
    yield return new(UNIT_N0D7_DEEP_FORAGER_N_ZOTH_WORKER, Unlimited);
    yield return new(UNIT_N0DT_TIDEMISTRESS_NZOTH, 6);
    yield return new(UNIT_N0CA_NAGA_INCURSOR_NZOTH, Unlimited);
    yield return new(UNIT_N0CE_HATCHLING_NZOTH, Unlimited);
    yield return new(UNIT_N0CL_GARGANTUAN_SEA_TURTLE_NZOTH, 8);
    yield return new(UNIT_N0CB_DEEPSEER_NZOTH, Unlimited);
    yield return new(UNIT_N0CD_BLOODKIN_NZOTH, Unlimited);
    yield return new(UNIT_O060_RIPTIDE_DRAKE_NZOTH, 6);
    yield return new(UNIT_U02J_TIDAL_TERROR_NZOTH, 4);
    yield return new(UNIT_H01Q_IMMORTAL_GUARDIAN_NZOTH, 4);
    yield return new(UNIT_N0CO_TRENCH_HYDRA_NZOTH, 2);
    yield return new(UNIT_E020_ANCIENT_SHIPYARD_NAGA_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHT_ELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHT_ELVES, 6);
    yield return new(UNIT_H08U_EMPRESS_OF_NAZJATAR_NZOTH, 1);
    yield return new(UNIT_H0A5_SEA_WITCH_NZOTH, 1);
    yield return new(UNIT_U02U_ABYSSAL_COMMANDER_NAZJATAR, 1);
  }
}
