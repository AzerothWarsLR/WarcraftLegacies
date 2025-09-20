using System;
using MacroTools.ShoreSystem;
using WCSharp.Shared.Data;

namespace MacroTools.Extensions;

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
      whichItem.SetPosition(position);
      return;
    }

    var shore = ShoreManager.GetNearestShore(position);
    if (shore == null)
    {
      throw new InvalidOperationException(
        $"{nameof(ItemExtensions)} could not find a {nameof(Shore)} to dump a {GetItemName(whichItem)}.");
    }
    whichItem.SetPosition(shore.Position);
  }

  public static void SetPosition(this item whichItem, Point position)
  {
    SetItemPosition(whichItem, position.X, position.Y);
  }
}
