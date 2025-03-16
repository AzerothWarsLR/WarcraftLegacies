﻿using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Utils;
using WCSharp.Shared.Data;
using static War3Api.Common;


namespace MacroTools.Extensions
{
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
      var width = GetRectMaxX(region.Rect) - GetRectMinX(region.Rect);
      var height = GetRectMaxY(region.Rect) - GetRectMinY(region.Rect);
      SetSoundPosition(soundHandle, GetRectCenterX(region.Rect), GetRectCenterY(region.Rect), 0);
      RegisterStackedSound(soundHandle, true, width, height);
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
        if (unit.OwningPlayer() != Player(PLAYER_NEUTRAL_PASSIVE) || unit.GetTypeId() == FourCC("ngol"))
          continue;

        if (!unit.IsRemovable())
        {
          unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
          continue;
        }

        if (unit.IsRemovable() && !BlzIsUnitInvulnerable(unit) &&
            (cleanupType == NeutralPassiveCleanupType.RemoveUnits || unit.IsType(UNIT_TYPE_STRUCTURE)))
          unit.Remove();
        else
          unit.SetOwner(Player(PLAYER_NEUTRAL_AGGRESSIVE));
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
        if (unit.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && unit.IsRemovable())
        {
          unit.Remove();
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
        .Where(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_PASSIVE) && filter.Invoke(x))
        .ToList();
      foreach (var unit in group)
      {
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideStructures && !IsUnitType(unit, UNIT_TYPE_ANCIENT) ||
            !IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideUnits)
          unit.Show(false);
        unit
          .SetInvulnerable(true)
          .PauseEx(true);
      }

      return group;
    }
  }
}