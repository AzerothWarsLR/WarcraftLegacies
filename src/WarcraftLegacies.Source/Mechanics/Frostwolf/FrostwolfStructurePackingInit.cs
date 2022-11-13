using MacroTools.Mechanics;
using MacroTools.Wrappers;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Mechanics.Frostwolf
{
  /// <summary>
  /// Setup file adding the structure packing mechanic to preplaced units
  /// </summary>
  public static class FrostwolfStructurePackingInit
  {
    private static readonly int[] Buildings =
    {
      Constants.UNIT_OGRE_GREAT_HALL_FROSTWOLF,
      Constants.UNIT_OFOR_WAR_MILL_FROSTWOLF,
      Constants.UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF,
      Constants.UNIT_OBAR_WAR_CAMP_FROSTWOLF
    };
    
    /// <summary>
    /// Adds the build ability and special effect to one of the preplaced Kodos 
    /// </summary>
    /// <param name="buildingIndex"></param>
    /// <param name="packedUnit"></param>
    private static void KodoSetup(int buildingIndex, unit packedUnit)
    {
      StructurePacking.PackableStructure.GetPackableStructureById(Buildings[buildingIndex]).PackUnitSetup(packedUnit);
    }
    
    /// <summary>
    /// Gets all units in the CairneStart rect, checks if that unit is a Kodo and if it is sets up the packing mechanic for that unit
    /// </summary>
    public static void Setup()
    {
      var index = 0;
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(Regions.CairneStart.Rect).EmptyToList())
      {
        if (GetUnitTypeId(unit) != Constants.UNIT_OOSC_PACK_KODO_FROSTWOLF) continue;
        KodoSetup(index,unit);
        index++;
      }
    }
  }
}