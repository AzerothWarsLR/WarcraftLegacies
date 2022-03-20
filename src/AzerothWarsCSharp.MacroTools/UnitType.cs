using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  /// Contains extra Azeroth Wars specific information about Warcraft 3 unit types.
  /// </summary>
  public class UnitType{
    int UNITCATEGORY_TOWNHALL = 1;
    int UNITCATEGORY_KEEP = 2;
    int UNITCATEGORY_CASTLE = 3;
    int UNITCATEGORY_UNITPRODUCTION_A = 4;
    int UNITCATEGORY_UNITPRODUCTION_B = 5;
    int UNITCATEGORY_UNITPRODUCTION_C = 6;
    int UNITCATEGORY_UNITPRODUCTION_D = 7;
    int UNITCATEGORY_SHIPYARD = 8;
    int UNITCATEGORY_FARM = 9;
    int UNITCATEGORY_ALTAR = 10;
    int UNITCATEGORY_SHOP = 11;
    int UNITCATEGORY_BASICTOWER = 12;
    int UNITCATEGORY_UPGRADEDTOWER_A = 13;
    int UNITCATEGORY_UPGRADEDTOWER_B = 14;
    int UNITCATEGORY_BLACKSMITH = 15;
    int UNITCATEGORY_SPECIAL = 16; //Lumber Mill, for instance
    int UNITCATEGORY_UPGRADEDTOWER2_A = 13; //Tower that)s been upgraded twice
    int UNITCATEGORY_UPGRADEDTOWER2_B = 14; //Tower that)s been upgraded twice

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
    public static UnitType GetFromHandle(unit whichUnit ){
      return ById[GetUnitTypeId(whichUnit)];
    }

    /// <summary>
    /// Returns the UnitType representation of a particular UnitTypeId.
    /// </summary>
    public static UnitType GetFromId(int id){
      return ById[id];
    }

    public UnitType(int unitId ){
      this._unitId = unitId;
      ById[unitId] = this;
    }
  }
}
