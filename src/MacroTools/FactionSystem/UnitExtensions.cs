using System;
using MacroTools.Extensions;
using MacroTools.Shared;
using MacroTools.Systems;

namespace MacroTools.FactionSystem
{
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
        return whichUnit;
      
      if (!UnitType.TryGetFromHandle(whichUnit, out var unitType)) 
        throw new InvalidOperationException($"{GetUnitName(whichUnit)} doesn't have a registered {nameof(UnitType)}.");

      if (unitType.Category == UnitCategory.None)
        throw new InvalidOperationException($"{GetUnitName(whichUnit)} doesn't have a category.");

      if (!newFaction.TryGetObjectByCategory(unitType.Category, out var newUnitType)) 
        throw new InvalidOperationException($"{GetUnitName(whichUnit)} can't be replaced because {newFaction.Name} doesn't have a registered unit type of category {unitType.Category}.");

      if (GetUnitTypeId(whichUnit) == newUnitType)
        return whichUnit;

      var oldPosition = whichUnit.GetPosition();
      var oldOwner = whichUnit.OwningPlayer();
      var oldFacing = GetUnitFacing(whichUnit);
      
      RemoveUnit(whichUnit);
      var newUnit = CreateUnit(oldOwner, newUnitType, oldPosition.X, oldPosition.Y, oldFacing);

      return newUnit;
    }
  }
}