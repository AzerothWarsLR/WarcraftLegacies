using System.Linq;
using MacroTools.Extensions;
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
    var triggerUnit = @event.Unit;
    if (triggerUnit.Owner == player.NeutralAggressive)
    {
      return;
    }

    var triggerUnitPosition = triggerUnit.GetPosition();

    var hostileNearby = GlobalGroup
      .EnumUnitsInRange(triggerUnitPosition, 700)
      .OrderByDescending(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), triggerUnitPosition))
      .FirstOrDefault(x => x.Owner == player.NeutralAggressive && x.Alive && !x.IsUnitType(unittype.Ancient));
    if (hostileNearby == null)
    {
      PlayerUnitEvents.Unregister(ItemTypeEvent.IsPickedUp, OnEyeOfSargerasPickedUp,
        ITEM_I003_EYE_OF_SARGERAS);
      return;
    }

    MissileSystem.Add(new EyeOfSargerasMissile(triggerUnit, hostileNearby, @event.ManipulatedItem));
  }
}
