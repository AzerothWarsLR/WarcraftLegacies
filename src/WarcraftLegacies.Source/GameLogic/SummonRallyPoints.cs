using MacroTools.Extensions;
using WCSharp.Events;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// When units are summoned by buildings, send them to attack-move towards their rally points.
/// </summary>
public static class SummonRallyPoints
{
  /// <summary>
  /// Sets up <see cref="SummonRallyPoints"/>.
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsSummoned, () =>
    {
      var summoningUnit = @event.SummoningUnit;
      if (summoningUnit.IsUnitType(unittype.Structure))
      {
        @event.SummonedUnit.IssueOrder("attack", summoningUnit.GetRallyPoint());
      }
    });
  }
}
