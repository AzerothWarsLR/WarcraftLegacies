using System.Collections.Generic;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// Contains extra Warcraft Legacies-specific information about Warcraft 3 unit types.
  /// </summary>
  public sealed class UnitType
  {
    private static readonly List<UnitType> All = new();
    private static readonly Dictionary<int, UnitType> ById = new();
    private readonly int _unitId;

    public static IReadOnlyCollection<UnitType> GetAll()
    {
      return All.AsReadOnly();
    }

    /// <summary>
    /// How much gold the UnitType costs to train or build.
    /// </summary>
    public int GoldCost => GetUnitGoldCost(_unitId);

    /// <summary>
    /// How much lumber the UnitType costs to train or build.
    /// </summary>
    public int LumberCost => GetUnitWoodCost(_unitId);

    /// <summary>
    /// Whether or not the unit should be deleted without refund when the player leaves.
    /// </summary>
    public bool Meta { get; init; }

    /// <summary>
    /// An arbitrary category, like "Shipyard" or "Shop".
    /// </summary>
    public UnitCategory Category { get; init; }

    /// <summary>
    /// Returns the UnitType representation of a unit on the map.
    /// </summary>
    public static UnitType GetFromHandle(unit whichUnit)
    {
      return ById.TryGetValue(GetUnitTypeId(whichUnit), out var unitType) ? unitType : new UnitType(GetUnitTypeId(whichUnit));
    }

    /// <summary>
    /// Returns the UnitType representation of a particular UnitTypeId.
    /// </summary>
    public static UnitType GetFromId(int id)
    {
      return ById[id];
    }

    public static void Register(UnitType unitType)
    {
      ById[unitType._unitId] = unitType;
      All.Add(unitType);
    }
    
    public UnitType(int unitId)
    {
      _unitId = unitId;
    }
  }
}