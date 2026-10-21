using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Shared;
using MacroTools.Utils;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

/// <summary>Shared steps for moving Quel'thalas to a Sunfury base beside Tempest Keep.</summary>
public static class SunfuryRelocation
{
  /// <summary>Where the new town hall goes.</summary>
  public const float BaseX = 2752;

  /// <inheritdoc cref="BaseX"/>
  public const float BaseY = -22912;

  private static Dictionary<int, int> SunfuryEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), SunfuryObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_NEGT_SUN_TOWER, UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER }
    });

  private static Dictionary<int, int> ArmyEquivalents => UnitEquivalents.Pair(
    QuelthalasObjectInfo.GetAllObjectLimits(), SunfuryObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_HMPR_PRIEST_QUELTHALAS, UNIT_H0CH_ASTROMANCER_SUNFURY },
      { UNIT_HSOR_SORCERESS_QUELTHALAS, UNIT_H0CG_FLAMEKEEPER_SUNFURY },
      { UNIT_N048_BLOOD_MAGE_QUELTHALAS, UNIT_N0E3_WARLOCK_SUNFURY },
      { UNIT_HSPT_SPELLBREAKER_QUELTHALAS, UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY },
      { UNIT_U00J_ARCANE_WAGON_QUELTHALAS, UNIT_U02W_ENERGY_WAGON_SUNFURY }
    });

  /// <summary>Replaces <paramref name="whichPlayer"/>'s Quel'thalas buildings and workers with their Sunfury equivalents.</summary>
  public static void ConvertToSunfury(player whichPlayer)
  {
    var sunfuryEquivalents = SunfuryEquivalents;
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable() ||
          (!whichUnit.IsUnitType(unittype.Structure) && !whichUnit.IsUnitType(unittype.Peon)))
      {
        continue;
      }

      if (sunfuryEquivalents.TryGetValue(whichUnit.UnitType, out var sunfuryType))
      {
        PathBase.ReplaceUnit(whichUnit, whichPlayer, sunfuryType, whichUnit.X, whichUnit.Y);
      }
    }
  }

  /// <summary>Brings <paramref name="whichPlayer"/>'s army to the new base as Sunfury units.</summary>
  public static void RelocateArmy(player whichPlayer) =>
    PathBase.RelocateArmy(whichPlayer, ArmyEquivalents, BaseX, BaseY + 800);

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
