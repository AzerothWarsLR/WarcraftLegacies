using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Utils;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Shared steps for moving Quel'thalas to a Sunfury base beside Tempest Keep.</summary>
public static class SunfuryRelocation
{
  /// <summary>Where the new town hall goes.</summary>
  public const float BaseX = 2752;

  /// <inheritdoc cref="BaseX"/>
  public const float BaseY = -22912;

  private static readonly Dictionary<int, int> _sunfuryEquivalents = new()
  {
    { UNIT_H033_STEADING_QUELTHALAS_T1, UNIT_H02P_HOLDING_SUNFURY_T1 },
    { UNIT_H03S_MANSION_QUELTHALAS_T2, UNIT_H0C4_COVENANT_SUNFURY_T2 },
    { UNIT_H03T_PALACE_QUELTHALAS_T3, UNIT_H0C5_SANCTUARY_SUNFURY_T3 },
    { UNIT_H01H_ALTAR_OF_PROWESS_QUELTHALAS_ALTAR, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR },
    { UNIT_H02Y_ARTISAN_S_HALL_QUELTHALAS_RESEARCH, UNIT_H0C8_FORGE_SUNFURY_RESEARCH },
    { UNIT_H034_ARCANE_SANCTUM_QUELTHALAS_MAGIC, UNIT_H0CB_LYCEUM_ARCANUM_SUNFURY_MAGIC },
    { UNIT_H073_SCOUT_TOWER_QUELTHALAS_TOWER, UNIT_H0CD_SCOUT_TOWER_SUNFURY_TOWER },
    { UNIT_H074_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_H075_IMPROVED_ARCANE_TOWER_QUELTHALAS_TOWER, UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_NEGT_SUN_TOWER, UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_N003_IMPROVED_SUN_TOWER_QUELTHALAS_TOWER, UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER },
    { UNIT_H04V_ARCANE_VAULT_QUELTHALAS_SHOP, UNIT_H0CC_SHAPER_S_HALL_SUNFURY_SHOP },
    { UNIT_NHEB_CANTONMENT_QUELTHALAS_BARRACKS, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS },
    { UNIT_N0A2_CONSORTIUM_QUELTHALAS_SIEGE, UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE },
    { UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST, UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST },
    { UNIT_H077_SHIPYARD_QUELTHALAS_SHIPYARD, UNIT_TP04_SHIPYARD_SUNFURY_SHIPYARD },
    { UNIT_NBEE_ARCHITECT_QUELTHALAS_WORKER, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER }
  };

  private static readonly Dictionary<int, int> _armyEquivalents = new()
  {
    { UNIT_NBEE_ARCHITECT_QUELTHALAS_WORKER, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER },
    { UNIT_HHES_SWORDSMAN_QUELTHALAS, UNIT_N09S_CENTURION_SUNFURY },
    { UNIT_HMPR_PRIEST_QUELTHALAS, UNIT_H0CH_ASTROMANCER_SUNFURY },
    { UNIT_HSOR_SORCERESS_QUELTHALAS, UNIT_H0CG_FLAMEKEEPER_SUNFURY },
    { UNIT_N063_MAGUS_QUELTHALAS, UNIT_H0CG_FLAMEKEEPER_SUNFURY },
    { UNIT_HDHW_DRAGONHAWK_RIDER_QUELTHALAS, UNIT_N0E8_SKYSHIP_SUNFURY },
    { UNIT_NHEA_RANGER_QUELTHALAS, UNIT_H0CF_BOWMAN_SUNFURY },
    { UNIT_E008_BALLISTA_QUELTHALAS, UNIT_N0E4_SCORPION_SUNFURY },
    { UNIT_N00A_FARSTRIDER_QUELTHALAS_ELITE, UNIT_N0E7_BLOODWARDER_SUNFURY },
    { UNIT_E024_ARCANE_ANNIHILATOR_QUELTHALAS, UNIT_E01B_ARCANE_ANNIHILATOR_SUNFURY },
    { UNIT_N02F_WARLOCK_QUELTHALAS, UNIT_N0E3_WARLOCK_SUNFURY },
    { UNIT_N048_BLOOD_MAGE_QUELTHALAS, UNIT_N0E3_WARLOCK_SUNFURY },
    { UNIT_HSPT_SPELLBREAKER_QUELTHALAS, UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY },
    { UNIT_U00J_ARCANE_WAGON_QUELTHALAS, UNIT_U02W_ENERGY_WAGON_SUNFURY }
  };

  /// <summary>Replaces <paramref name="whichPlayer"/>'s Quel'thalas buildings and workers with their Sunfury equivalents.</summary>
  public static void ConvertToSunfury(player whichPlayer)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (whichUnit.Alive && whichUnit.IsRemovable() &&
          _sunfuryEquivalents.TryGetValue(whichUnit.UnitType, out var sunfuryType))
      {
        PathBase.ReplaceUnit(whichUnit, whichPlayer, sunfuryType, whichUnit.X, whichUnit.Y);
      }
    }
  }

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Sunfury units.</summary>
  public static void RelocateArmy(player whichPlayer) =>
    PathBase.RelocateArmy(whichPlayer, _armyEquivalents, BaseX, BaseY + 800);

  /// <summary>Creates the new base beside Tempest Keep.</summary>
  public static void BuildBase(player whichPlayer)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_H02P_HOLDING_SUNFURY_T1, BaseX, BaseY);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, BaseX + 512, BaseY + 192);
    PathBase.CreateStructure(whichPlayer, UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, BaseX - 512, BaseY + 192);
    PathBase.CreateUnits(whichPlayer, UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, 5, BaseX + 200, BaseY + 200);
    PathBase.CreateUnits(whichPlayer, UNIT_N09S_CENTURION_SUNFURY, 3, BaseX, BaseY + 500);
    PathBase.CreateUnits(whichPlayer, UNIT_H0CF_BOWMAN_SUNFURY, 3, BaseX + 200, BaseY + 500);

    PathBase.CreateStructure(whichPlayer, UNIT_N05X_TEMPEST_KEEP_QUELTHALAS_OTHER, 4480, -21696);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST, 4192, -21344);
    PathBase.CreateStructure(whichPlayer, UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE, 4064, -22048);
  }
}
