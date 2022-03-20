using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// Contains extra Azeroth Wars specific information about Warcraft 3 unit types.
  /// </summary>
  public sealed class UnitType
  {
    private static readonly Dictionary<int, UnitType> ById = new();
    private readonly int _unitId;

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
    public bool Meta { get; set; }

    /// <summary>
    /// Whether or not the unit should be refunded when the player leaves.
    /// </summary>
    public bool Refund { get; set; }

    /// <summary>
    /// An arbitrary category, like "Shipyard" or "Shop".
    /// </summary>
    public int UnitCategory { get; set; }

    /// <summary>
    /// Returns the UnitType representation of a unit on the map.
    /// </summary>
    public static UnitType GetFromHandle(unit whichUnit)
    {
      return ById[GetUnitTypeId(whichUnit)];
    }

    /// <summary>
    /// Returns the UnitType representation of a particular UnitTypeId.
    /// </summary>
    public static UnitType GetFromId(int id)
    {
      return ById[id];
    }

    public UnitType(int unitId)
    {
      this._unitId = unitId;
      ById[unitId] = this;
    }
  }
}