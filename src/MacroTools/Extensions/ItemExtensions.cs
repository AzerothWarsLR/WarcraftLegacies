using System;
using MacroTools.ShoreSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions
{
  public static class ItemExtensions
  {
    /// <summary>
    /// Drop the item at the given position. If the position turns out to be non-ground-pathable,
    /// return it to a nearby <see cref="Shore"/> instead.
    /// </summary>
    public static void SetPositionSafe(this item whichItem, Point position)
    {
      if (!IsTerrainPathable(position.X, position.Y, PATHING_TYPE_WALKABILITY))
      {
        SetItemPosition(whichItem, position.X, position.Y);
        return;
      }

      var shore = ShoreManager.GetNearestShore(position);
      if (shore == null)
      {
        throw new InvalidOperationException(
          $"{nameof(ItemExtensions)} could not find a {nameof(Shore)} to dump a {GetItemName(whichItem)}.");
      }
      SetItemPosition(whichItem, shore.Position.X, shore.Position.Y);
    }
  }
}