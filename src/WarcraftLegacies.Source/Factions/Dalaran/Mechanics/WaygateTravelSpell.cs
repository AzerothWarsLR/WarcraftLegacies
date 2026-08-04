using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran.Mechanics;

/// <summary>
/// Moves nearby alies between gates.
/// </summary>
public sealed class WaygateTravelSpell : Spell
{
  internal const float TravelRadius = 500;

  public WaygateTravelSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (!WaygateManager.TryGetTravelDestination(caster, out var destinationWaygate))
    {
      caster.Owner.DisplayTextTo("Both Way Gates must be fully contructed before they can be used.");
      return;
    }

    var sourcePosition = new Point(caster.X, caster.Y);
    var destinationPosition = new Point(destinationWaygate.X, destinationWaygate.Y);

    foreach (var nearbyUnit in GlobalGroup.EnumUnitsInRange(sourcePosition, TravelRadius))
    {
      if (!IsEligible(caster, nearbyUnit))
      {
        continue;
      }

      nearbyUnit.SetPosition(
        destinationPosition.X + nearbyUnit.X - sourcePosition.X,
        destinationPosition.Y + nearbyUnit.Y - sourcePosition.Y);
    }
  }

  private static bool IsEligible(unit caster, unit nearbyUnit)
  {
    return nearbyUnit.Alive &&
           !nearbyUnit.IsUnitType(unittype.Structure) &&
           nearbyUnit.IsAllyTo(caster.Owner);
  }
}
