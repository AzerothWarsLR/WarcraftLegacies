using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Cinematics;
using MacroTools.Factions;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

/// <summary>
/// Provides a helpful set of extension methods for <see cref="Rectangle"/>s.
/// </summary>
public static class RectangleExtensions
{
  /// <summary>
  /// Causes the provided sound to be played as ambience whenever a player has their camera near this <see cref="Rectangle"/>.
  /// </summary>
  public static void AddSound(this Rectangle region, sound soundHandle)
  {
    var width = region.Rect.MaxX - region.Rect.MinX;
    var height = region.Rect.MaxY - region.Rect.MinY;
    soundHandle.SetPosition(region.Rect.CenterX, region.Rect.CenterY, 0);
    soundHandle.RegisterStackedSound(true, width, height);
  }

  /// <summary>
  /// Prepares neutral passive units within the specified <paramref name="rectangle"/> according to
  /// the provided <see cref="RescuePreparationMode"/>.
  /// </summary>
  /// <param name="rectangle">The rectangle in which to prepare units.</param>
  /// <param name="rescuePreparationMode">Determines how units are prepared.</param>
  /// <param name="filter">A function that is applied to each unit found in <paramref name="rectangle"/>.
  /// The unit gets rescued if and only if <paramref name="filter"/> returns true.
  /// </param>
  /// <returns>Returns all neutral passive units not matching the <paramref name="filter"/> in the specified rectangle.</returns>
  public static List<unit> PrepareUnitsForRescue(this Rectangle rectangle,
    RescuePreparationMode rescuePreparationMode, Func<unit, bool>? filter = null)
  {
    filter ??= _ => true;
    return rescuePreparationMode switch
    {
      RescuePreparationMode.Invulnerable => PrepareUnitsForRescue(rectangle, false, false, filter),
      RescuePreparationMode.HideNonStructures => PrepareUnitsForRescue(rectangle, true, false, filter),
      RescuePreparationMode.HideAll => PrepareUnitsForRescue(rectangle, true, true, filter),
      _ => throw new ArgumentException($"{nameof(rescuePreparationMode)} is not implemented for this function.",
        nameof(rescuePreparationMode))
    };
  }

  /// <summary>
  /// Removes all Neutral Passive units from the area, except for unremovable units, which are instead made hostile.
  /// </summary>
  public static void CleanupNeutralPassiveUnits(this Rectangle area,
    NeutralPassiveCleanupType cleanupType = NeutralPassiveCleanupType.RemoveUnits)
  {
    var unitsInArea = GlobalGroup
      .EnumUnitsInRect(area);

    foreach (var unit in unitsInArea)
    {
      if (unit.Owner != player.NeutralPassive || unit.UnitType == FourCC("ngol"))
      {
        continue;
      }

      if (!unit.IsRemovable())
      {
        unit.SetOwner(player.NeutralAggressive);
        continue;
      }

      if (unit.IsRemovable() && !unit.IsInvulnerable &&
          (cleanupType == NeutralPassiveCleanupType.RemoveUnits || unit.IsUnitType(unittype.Structure)))
      {
        unit.Dispose();
      }
      else
      {
        unit.SetOwner(player.NeutralAggressive);
      }
    }
  }

  /// <summary>
  /// Removes all removable, hostile units in the area.
  /// </summary>
  public static void CleanupHostileUnits(this Rectangle area)
  {
    var unitsInArea = GlobalGroup
      .EnumUnitsInRect(area);
    foreach (var unit in unitsInArea)
    {
      if (unit.Owner == player.NeutralAggressive && unit.IsRemovable())
      {
        unit.Dispose();
      }
    }
  }

  /// <summary>
  /// Prepares all Neutral Passive inside the specified <paramref name="rectangle"/>.
  /// </summary>
  /// <param name="rectangle">The rectangle in which to prepare units.</param>
  /// <param name="hideUnits">If true, prepared units are hidden.</param>
  /// <param name="hideStructures">If true, prepared structures are hidden.</param>
  /// <param name="filter"></param>
  /// <returns>Returns all neutral passive units not matching the <paramref name="filter"/> in the specified rectangle.</returns>
  private static List<unit> PrepareUnitsForRescue(this Rectangle rectangle, bool hideUnits, bool hideStructures,
    Func<unit, bool> filter)
  {
    var group = GlobalGroup
      .EnumUnitsInRect(rectangle)
      .Where(x => x.Owner == player.NeutralPassive && filter.Invoke(x))
      .ToList();
    foreach (var unit in group)
    {
      if (unit.IsUnitType(unittype.Structure) && hideStructures && !unit.IsUnitType(unittype.Ancient) ||
          !unit.IsUnitType(unittype.Structure) && hideUnits)
      {
        unit.IsVisible = false;
      }

      unit.IsInvulnerable = true;
      unit.SetPausedEx(true);
    }

    return group;
  }

  /// <summary>
  /// Replaces all units in a rectangle with their equivalents from the specified faction.
  /// Ignores all units with the type ID "ngol".
  /// </summary>
  /// <param name="region">The rectangular region.</param>
  /// <param name="pickedFaction">The faction whose equivalents will be used.</param>
  public static void ReplaceUnitsWithFactionEquivalents(this Rectangle region, Faction pickedFaction)
  {
    if (pickedFaction == null)
    {
      throw new ArgumentNullException(nameof(pickedFaction), "pickedFaction cannot be null.");
    }

    var unitsInRegion = GlobalGroup
      .EnumUnitsInRect(region)
      .Where(x => x.UnitType != FourCC("ngol")) // exclude goldmines
      .Where(unit => unit.IsUnitType(unittype.Structure)); // Filter to include only structures

    foreach (var unit in unitsInRegion)
    {
      var replacedUnit = unit.ReplaceWithFactionEquivalent(pickedFaction); // Replaces with faction equivalent

      if (replacedUnit != unit && CinematicMode.State == CinematicState.Active)
      {
        CinematicMode.AddPausedUnit(replacedUnit); // Handles cinematic transitions
      }
    }
  }

}
