using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Systems;

namespace MacroTools.Factions;

/// <summary>
/// Extension methods for native Warcraft III units that relate to the Faction system.
/// </summary>
public static class UnitExtensions
{
  /// <summary>
  /// Replaces a unit with a unit of the same category from a different faction.
  /// <para>Will simply do nothing if either of the specified factions don't have a unit in the right category.</para>
  /// </summary>
  /// <returns>The new unit after a successful replacement, or the old unit if no replacement was needed.</returns>
  /// <exception cref="InvalidOperationException">Thrown if the unit could not be replaced for some reason.</exception>
  public static unit ReplaceWithFactionEquivalent(this unit whichUnit, Faction newFaction)
  {
    if (!whichUnit.IsRemovable())
    {
      return whichUnit;
    }

    if (!UnitType.TryGetFromHandle(whichUnit, out var unitType))
    {
      throw new InvalidOperationException($"{whichUnit.Name} doesn't have a registered {nameof(UnitType)}.");
    }

    if (unitType.Categories.Count == 0)
    {
      throw new InvalidOperationException($"{whichUnit.Name} doesn't have any categories.");
    }

    var firstCategory = unitType.Categories.First();
    if (!newFaction.TryGetObjectByCategory(firstCategory, out var newUnitTypes))
    {
      throw new InvalidOperationException($"{whichUnit.Name} can't be replaced because {newFaction.Name} doesn't have a registered unit type of category {firstCategory}.");
    }

    var newUnitType = newUnitTypes.First();
    if (whichUnit.UnitType == newUnitType)
    {
      return whichUnit;
    }

    var oldPosition = whichUnit.GetPosition();
    var oldOwner = whichUnit.Owner;
    var oldFacing = whichUnit.Facing;

    whichUnit.Dispose();
    var newUnit = unit.Create(oldOwner, newUnitType, oldPosition.X, oldPosition.Y, oldFacing);

    return newUnit;
  }
}
