using System;
using WCSharp.Events;

namespace MacroTools.Mechanics;

/// <summary>
///   Notices when a Waygate structure is built and registers it a new <see cref="Waygate" />.
///   Enforces that there can only be two such Waygates.
/// </summary>
public static class WaygateManager
{
  private static Waygate? WaygateA { get; set; }
  private static Waygate? WaygateB { get; set; }

  private static void OnWaygateDied(object? sender, Waygate waygate)
  {
    if (WaygateA == waygate)
    {
      WaygateA = null;
      return;
    }

    if (WaygateB == waygate)
    {
      WaygateB = null;
    }
  }

  private static void OnWaygateCreated()
  {
    var newWaygate = new Waygate(@event.Unit);
    if (WaygateA == null)
    {
      WaygateA = newWaygate;
    }
    else if (WaygateB == null)
    {
      WaygateB = newWaygate;
    }
    WaygateA.Sister = WaygateB;
    if (WaygateB != null)
    {
      WaygateB.Sister = WaygateA;
    }

    newWaygate.Died += OnWaygateDied;

    throw new Exception("Cannot have more than 2 buildable Waygates on the map.");
  }

  /// <summary>
  /// Sets up the <see cref="WaygateManager"/> system.
  /// </summary>
  /// <param name="waygateUnitTypeId">The unit type ID of the buildable Waygate as specified in the Object Editor.</param>
  public static void Setup(int waygateUnitTypeId)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnWaygateCreated,
      waygateUnitTypeId);
  }
}
