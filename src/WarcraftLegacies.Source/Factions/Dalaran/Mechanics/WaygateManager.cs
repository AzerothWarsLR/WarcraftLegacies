using System;
using MacroTools.Spells;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Factions.Dalaran.Mechanics;

/// <summary>
/// Pairs the gates without native dynamic Waygate API.
/// </summary>
public static class WaygateManager
{
  private static Waygate? _waygateA;
  private static Waygate? _waygateB;

  private static void OnWaygateCreated()
  {
    var newUnit = @event.Unit;
    if (Find(newUnit) != null)
    {
      return;
    }

    var newWaygate = new Waygate(newUnit);
    if (_waygateA == null)
    {
      _waygateA = newWaygate;
    }
    else if (_waygateB == null)
    {
      _waygateB = newWaygate;
    }
    else
    {
      Console.WriteLine("Ignored a third Dalaran Way Gate; the faction object limit should prevent this.");
      return;
    }

    PairWaygates();
  }

  private static void OnWaygateConstructed()
  {
    Find(@event.ConstructedStructure)?.MarkConstructed();
  }

  private static void OnWaygateConstructionCancelled()
  {
    Remove(@event.CancelledStructure);
  }

  private static void OnWaygateDied()
  {
    Remove(@event.Unit);
  }

  private static Waygate? Find(unit whichUnit)
  {
    if (_waygateA?.Unit == whichUnit)
    {
      return _waygateA;
    }

    return _waygateB?.Unit == whichUnit ? _waygateB : null;
  }

  private static void PairWaygates()
  {
    if (_waygateA == null || _waygateB == null)
    {
      return;
    }

    _waygateA.Sister = _waygateB;
    _waygateB.Sister = _waygateA;
  }

  private static void Remove(unit whichUnit)
  {
    var waygate = Find(whichUnit);
    if (waygate == null)
    {
      return;
    }

    if (waygate.Sister != null)
    {
      waygate.Sister.Sister = null;
      waygate.Sister = null;
    }

    if (_waygateA == waygate)
    {
      _waygateA = null;
    }
    else
    {
      _waygateB = null;
    }
  }

  internal static bool TryGetTravelDestination(unit source, out unit? destination)
  {
    var sourceWaygate = Find(source);
    if (sourceWaygate?.IsOperational != true)
    {
      destination = null;
      return false;
    }

    destination = sourceWaygate.Sister!.Unit;
    return true;
  }

  /// <summary>
  /// Sets up gate events and travel ability.
  /// </summary>
  public static void Setup(int waygateUnitTypeId, int travelAbilityId)
  {
    PlayerUnitEvents.Register(UnitTypeEvent.IsCreated, OnWaygateCreated, waygateUnitTypeId);
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesBeingConstructed, OnWaygateConstructed, waygateUnitTypeId);
    PlayerUnitEvents.Register(UnitTypeEvent.CancelsBeingConstructed, OnWaygateConstructionCancelled, waygateUnitTypeId);
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnWaygateDied, waygateUnitTypeId);
    SpellRegistry.Register(new WaygateTravelSpell(travelAbilityId));
  }
}
