using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Wrappers;
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
    /// Prepares units belonging to <paramref name="owningPlayer"/> within the specified <paramref name="rectangle"/> according to
    /// the provided <see cref="RescuePreparationMode"/>.
    /// </summary>
    /// <param name="rectangle">The rectangle in which to prepare units.</param>
    /// <param name="rescuePreparationMode">Determines how units are prepared.</param>
    /// <param name="filter">A function that is applied to each unit found in <paramref name="rectangle"/>.
    /// The unit gets rescued if and only if <paramref name="filter"/> returns true.
    /// </param>
    /// <param name="owningPlayer">Player the units inside the specified rectangle belong to. The default value is neutral passive.</param>
    /// <returns>Returns all units belonging to <paramref name="owningPlayer"/> and not matching the <paramref name="filter"/> in the specified rectangle.</returns>
    public static List<unit> PrepareUnitsForRescue(this Rectangle rectangle, RescuePreparationMode rescuePreparationMode, Func<unit, bool>? filter = null, player? owningPlayer = null)
    {
      filter ??= _ => true;
      owningPlayer ??= Player(PLAYER_NEUTRAL_PASSIVE);
      return rescuePreparationMode switch
      {
        RescuePreparationMode.None => PrepareUnitsForRescue(rectangle, false, false, false, filter, owningPlayer),
        RescuePreparationMode.Invulnerable => PrepareUnitsForRescue(rectangle, true, false, false, filter, owningPlayer),
        RescuePreparationMode.HideNonStructures => PrepareUnitsForRescue(rectangle, true, true, false, filter, owningPlayer),
        RescuePreparationMode.HideAll => PrepareUnitsForRescue(rectangle, true, true, true, filter, owningPlayer),
        _ => throw new ArgumentException($"{nameof(rescuePreparationMode)} is not implemented for this function.",
          nameof(rescuePreparationMode))
      };
    }

    /// <summary>
    /// Prepares all Neutral Passive inside the specified <paramref name="rectangle"/>.
    /// </summary>
    /// <param name="rectangle">The rectangle in which to prepare units.</param>
    /// <param name="makeInvulnerable">If true, prepared units are made invulnerable.</param>
    /// <param name="hideUnits">If true, prepared units are hidden.</param>
    /// <param name="hideStructures">If true, prepared structures are hidden.</param>
    /// <param name="filter"></param>
    /// <returns>Returns all neutral passive units not matching the <paramref name="filter"/> in the specified rectangle.</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle rectangle, bool makeInvulnerable, bool hideUnits, bool hideStructures, Func<unit, bool> filter, player owningPlayer)
    {
      var group = new GroupWrapper()
        .EnumUnitsInRect(rectangle)
        .EmptyToList()
        .Where(x => x.OwningPlayer() == owningPlayer && filter.Invoke(x))
        .ToList();
      foreach (var unit in group)
      {
        if (makeInvulnerable)
          unit.SetInvulnerable(true);
        if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideStructures && !IsUnitType(unit, UNIT_TYPE_ANCIENT))
          unit.Show(false);
        if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideUnits)
          unit.Show(false);
      }
      return group;
    }
  }
}