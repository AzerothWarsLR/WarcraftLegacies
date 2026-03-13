using System;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives;

/// <summary>
/// Helper methods for invoking <see cref="PlayerUnitEvents"/> registration in a manner that supports the design of
/// <see cref="Objective"/>s.
/// </summary>
public static class PlayerUnitEventsHelper
{
  /// <summary>
  /// Registers <see cref="action"/> to fire when the specified unit either dies or changes owner.
  /// <remarks>Changing owner usually indicates that the unit has been Charmed or Possessed, which can be seen as
  /// equivalent to killing the unit within the framing of a map objective.</remarks>
  /// </summary>
  public static void RegisterDiesOrChangesOwner(Action action, unit unit)
  {
    PlayerUnitEvents.Register(UnitEvent.Dies, action, unit);
    PlayerUnitEvents.Register(UnitEvent.ChangesOwner, action, unit);
  }
}
