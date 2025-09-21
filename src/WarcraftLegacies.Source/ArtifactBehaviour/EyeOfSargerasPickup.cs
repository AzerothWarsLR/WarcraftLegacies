using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.ArtifactBehaviour;

/// <summary>
/// When the Eye of Sargeras is picked up with a hostile unit nearby, it transfers itself to the inventory of that hostile unit.
/// </summary>
public static class EyeOfSargerasPickup
{
  /// <summary>
  /// Sets up <see cref="EyeOfSargerasPickup"/>.
  /// </summary>
  public static void Setup()
  {
    PlayerUnitEvents.Register(ItemTypeEvent.IsPickedUp, OnEyeOfSargerasPickedUp, ITEM_I003_EYE_OF_SARGERAS);
  }

  private static void OnEyeOfSargerasPickedUp()
  {
    if (@event.Unit.Owner == player.NeutralAggressive)
    {
      return;
    }

    var hostileNearby = GlobalGroup
      .EnumUnitsInRange(@event.Unit.GetPosition(), 700)
      .OrderByDescending(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), @event.Unit.GetPosition()))
      .FirstOrDefault(x => x.Owner == player.NeutralAggressive && x.Alive && !x.IsUnitType(unittype.Ancient));
    if (hostileNearby == null)
    {
      PlayerUnitEvents.Unregister(ItemTypeEvent.IsPickedUp, OnEyeOfSargerasPickedUp,
        ITEM_I003_EYE_OF_SARGERAS);
      return;
    }

    MissileSystem.Add(new EyeOfSargerasMissile(@event.Unit, hostileNearby, @event.ManipulatedItem));
  }
}
