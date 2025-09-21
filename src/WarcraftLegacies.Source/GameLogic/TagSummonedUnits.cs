using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// When any unit is summoned for any reason, tag it with the Summoned classification.
/// </summary>
public static class TagSummonedUnits
{
  /// <summary>
  /// Sets up <see cref="TagSummonedUnits"/>.
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsSummoned, () =>
    {
      var unit = @event.Unit;
      if (unit.IsUnitType(unittype.Undead))
      {
        @event.Unit.AddType(unittype.Summoned);
      }
    });
  }
}
