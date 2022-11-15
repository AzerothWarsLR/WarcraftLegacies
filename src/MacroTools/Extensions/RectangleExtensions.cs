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
    /// The mode to use when rescuing group of nuetral passive units in the region
    /// </summary>
    public enum RescueMode
    {
      /// <summary>
      /// Just return the group of nuetral passive units.
      /// </summary>
      Group,
      /// <summary>
      /// Return the group of nuetral passive units and set them to be invulnerable.
      /// </summary>
      Invulnerable,
      /// <summary>
      /// Return the group of nuetral passive units and set them to be invulnerable and hide the units.
      /// </summary>
      HideUnits,
      /// <summary>
      /// Return the group of nuetral passive units and set them to be invulnerable, hide the units, and hide structures.
      /// </summary>
      HideStructures
    }
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
    /// Creates a group of units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/>.
    /// </summary>
    /// <param name="area">The area in which to get the group of units.</param>
    /// <returns>A list of all units found in the specified area</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle area)
    {
      var group = new GroupWrapper()
        .EnumUnitsInRect(area)
        .EmptyToList();
      return group;
    }
    
    /// <summary>
    /// Creates a group of units inside the specified <paramref name="area"/> that belong to the neutral passive player.
    /// </summary>
    /// <param name="area">The area in which to get the group of units.</param>
    /// <param name="rescueMode">Set the <see cref="RescueMode"/> to use</param>
    /// <returns>A list of all units found in the specified area that belong to the neutral passive player.</returns>
    public static List<unit> PrepareUnitsForRescue(this Rectangle area, RescueMode rescueMode)
    {
      switch(rescueMode)
      {
        case RescueMode.Group:
        {
          return PrepareUnitsForRescue(area, Player(PLAYER_NEUTRAL_PASSIVE));
        }
        case RescueMode.Invulnerable:
        {
          return PrepareUnitsForRescue(area, Player(PLAYER_NEUTRAL_PASSIVE),true);
        }
        case RescueMode.HideUnits:
        {
          return PrepareUnitsForRescue(area, Player(PLAYER_NEUTRAL_PASSIVE),true,true);
        }
        case RescueMode.HideStructures:
        {
          return PrepareUnitsForRescue(area, Player(PLAYER_NEUTRAL_PASSIVE),true,true,true);
        }
        default:
          return PrepareUnitsForRescue(area, Player(PLAYER_NEUTRAL_PASSIVE),true);;
      }
    }
    
    /// <summary>
    /// Creates a group of units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/>.
    /// </summary>
    /// <param name="area">The area in which to get the group of units.</param>
    /// <param name="owningUnitsPlayer">Only units owned by this player will be selected.</param>
    /// <returns>A list of all units found in the specified area that belong to <paramref name="owningUnitsPlayer"/>.</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle area, player owningUnitsPlayer)
    {
      var group = PrepareUnitsForRescue(area)
        .Where(x => x.OwningPlayer() == owningUnitsPlayer)
        .ToList();
      return group;
    }

    /// <summary>
    /// Renders all units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/> invulnerable.
    /// </summary>
    /// <param name="area">The area in which to make units invulnerable.</param>
    /// <param name="owningUnitsPlayer">Only units owned by this player will be selected.</param>
    /// <param name="invulnerable">Flag for if units should be made invulnerable</param>
    /// <returns>A list of all units found in the specified area that belong to <paramref name="owningUnitsPlayer"/>.</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle area, player owningUnitsPlayer, bool invulnerable)
    {
      var group = PrepareUnitsForRescue(area, owningUnitsPlayer);
      if (!invulnerable) return group;
      foreach (var unit in group)
      {
        unit.SetInvulnerable(true);
      }
      return group;
    }
    
    /// <summary>
    /// Renders all units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/> invulnerable.
    /// </summary>
    /// <param name="area">The area in which to get the group of units.</param>
    /// <param name="owningUnitsPlayer">Only units owned by this player will be selected.</param>
    /// <param name="invulnerable">Flag for if units should be made invulnerable</param>
    /// <param name="hideUnits">Flag for if units should be hidden</param>
    /// <returns>A list of all units found in the specified area that belong to <paramref name="owningUnitsPlayer"/>.</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle area, player owningUnitsPlayer, bool invulnerable, bool hideUnits)
    {
      var group = PrepareUnitsForRescue(area, owningUnitsPlayer);
      foreach (var unit in group)
      {
        if (invulnerable)
          unit.SetInvulnerable(true);
        if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideUnits)
          unit.Show(false);
      }
      return group;
    }
    
    /// <summary>
    /// Renders all units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/> invulnerable.
    /// </summary>
    /// <param name="area">The area in which to get the group of units.</param>
    /// <param name="owningUnitsPlayer">Only units owned by this player will be selected.</param>
    /// <param name="invulnerable">Flag for if units should be made invulnerable</param>
    /// <param name="hideUnits">Flag for if units should be hidden</param>
    /// <param name="hideStructures">Flag for if structures should be hidden. Won't hide control points.</param>
    /// <returns>A list of all units found in the specified area that belong to <paramref name="owningUnitsPlayer"/>.</returns>
    private static List<unit> PrepareUnitsForRescue(this Rectangle area, player owningUnitsPlayer, bool invulnerable, bool hideUnits, bool hideStructures)
    {
      var group = PrepareUnitsForRescue(area, owningUnitsPlayer);
      foreach (var unit in group)
      {
        if (invulnerable)
          unit.SetInvulnerable(true);
        if ((IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideStructures) && !IsUnitType(unit, UNIT_TYPE_ANCIENT))
          unit.Show(false);
        if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE) && hideUnits)
          unit.Show(false);
      }
      return group;
    }
  }
}