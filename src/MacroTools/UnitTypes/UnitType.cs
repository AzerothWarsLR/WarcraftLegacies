using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MacroTools.Shared;

namespace MacroTools.UnitTypes;

/// <summary>
/// Contains extra Warcraft Legacies-specific information about Warcraft 3 unit types.
/// </summary>
public sealed class UnitType
{
  private static readonly List<UnitType> _all = new();
  private static readonly Dictionary<int, UnitType> _byId = new();

  /// <summary>
  /// The Warcraft 3 unit type ID for the <see cref="UnitType"/> wrapper.
  /// </summary>
  public int Id { get; }

  /// <summary>
  /// Returns all registered <see cref="UnitType"/>s.
  /// </summary>
  public static IEnumerable<UnitType> GetAll() => _all.AsReadOnly();

  /// <summary>
  /// How much gold the UnitType costs to train or build.
  /// </summary>
  public int GoldCost => unit.GoldCostOf(Id);

  /// <summary>
  /// If true, this unit should never be deleted.
  /// </summary>
  public bool NeverDelete { internal get; init; }

  /// <summary>
  /// Arbitrary categories, like "Shipyard" or "Shop".
  /// </summary>
  public List<UnitCategory> Categories { get; init; } = new();

  /// <summary>
  /// Gets the <see cref="UnitType"/> of the provided unit.
  /// </summary>
  /// <param name="whichUnit">The unit to get the type of.</param>
  /// <param name="unitType">The <see cref="UnitType"/> of the unit if it has one, and null otherwise.</param>
  /// <returns>True if the unit has a <see cref="UnitType"/>.</returns>
  public static bool TryGetFromHandle(unit whichUnit, [NotNullWhen(true)] out UnitType? unitType)
  {
    return _byId.TryGetValue(whichUnit.UnitType, out unitType);
  }

  /// <summary>
  /// Returns the UnitType representation of a unit on the map.
  /// </summary>
  public static UnitType GetFromHandle(unit whichUnit) =>
    _byId.TryGetValue(whichUnit.UnitType, out var unitType) ? unitType : new UnitType(whichUnit.UnitType);

  /// <summary>
  /// Returns the UnitType representation of a particular UnitTypeId.
  /// </summary>
  public static UnitType GetFromId(int id) => _byId[id];

  /// <summary>
  /// Registers a <see cref="UnitType"/> to the system.
  /// </summary>
  public static void Register(UnitType unitType)
  {
    _byId[unitType.Id] = unitType;
    _all.Add(unitType);
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="UnitType"/> class.
  /// </summary>
  /// <param name="unitId">The Warcraft 3 unit type ID you want to record extra information about.</param>
  public UnitType(int unitId)
  {
    Id = unitId;
  }
}
