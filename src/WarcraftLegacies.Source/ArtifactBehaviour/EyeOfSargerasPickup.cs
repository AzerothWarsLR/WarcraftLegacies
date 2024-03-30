using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Events;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.ArtifactBehaviour
{
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
      if (GetTriggerUnit().OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE))
        return;

      var hostileNearby = CreateGroup()
        .EnumUnitsInRange(GetTriggerUnit().GetPosition(), 700).EmptyToList()
        .OrderByDescending(x => MathEx.GetDistanceBetweenPoints(x.GetPosition(), GetTriggerUnit().GetPosition()))
        .FirstOrDefault(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE) && UnitAlive(x) && !x.IsType(UNIT_TYPE_ANCIENT));
      if (hostileNearby == null)
      {
        PlayerUnitEvents.Unregister(ItemTypeEvent.IsPickedUp, OnEyeOfSargerasPickedUp,
          ITEM_I003_EYE_OF_SARGERAS);
        return;
      }

      MissileSystem.Add(new EyeOfSargerasMissile(GetTriggerUnit(), hostileNearby, GetManipulatedItem()));
    }
  }
}