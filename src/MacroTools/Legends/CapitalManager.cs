using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MacroTools.TurnBasedHitPoints;
using WCSharp.Events;

namespace MacroTools.Legends;

/// <summary>
/// Responsible for managing all <see cref="Capital"/>s.
/// </summary>
public static class CapitalManager
{
  private static readonly Dictionary<unit, Capital> _byUnit = new();
  private static readonly List<Capital> _allCapitals = new();

  /// <summary>Capitals will gain this many hit points, as a percentage of their maximum, per turn.</summary>
  public const float HitPointPercentagePerTurn = 0.02f;

  /// <summary>
  /// Invoked when any <see cref="Capital"/> is destroyed.
  /// </summary>
  public static event EventHandler<Capital>? CapitalDestroyed;

  /// <summary>
  /// Registers a <see cref="Capital"/> to the <see cref="CapitalManager"/>.
  /// </summary>
  public static void Register(Capital capital)
  {
    if (capital.Unit == null)
    {
      return;
    }

    if (_byUnit.ContainsKey(capital.Unit))
    {
      throw new Exception($"Tried to register {nameof(Capital)} {capital.Name} but it is already registered.");
    }

    _byUnit.Add(capital.Unit, capital);
    _allCapitals.Add(capital);
    PlayerUnitEvents.Register(UnitEvent.Dies, () => { CapitalDestroyed?.Invoke(capital, capital); }, capital.Unit);
    TurnBasedHitpointsManager.Register(capital.Unit, HitPointPercentagePerTurn);
  }

  /// <summary>
  /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
  /// Returns null if there is no match.
  /// </summary>
  public static Capital? GetFromUnit(unit whichUnit)
  {
    _byUnit.TryGetValue(whichUnit, out var capital);
    return capital;
  }

  /// <summary>
  ///   Whether or not the given unit is a <see cref="Capital" />.
  /// </summary>
  public static bool UnitIsCapital(unit unit) => _byUnit.ContainsKey(unit);

  /// <summary>
  ///   Whether or not the given unit is a <see cref="Protector" />.
  /// </summary>
  public static bool UnitIsProtector(unit unit)
  {
    foreach (var capital in _allCapitals)
    {
      if (capital.ProtectorsByUnit.ContainsKey(unit))
      {
        return true;
      }
    }
    return false;
  }

  /// <summary>
  /// Returns all registered <see cref="Capital"/>s.
  /// </summary>
  public static ReadOnlyCollection<Capital> GetAll() => _allCapitals.AsReadOnly();
}
