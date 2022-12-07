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
    private static readonly string[] StructureModels =
    {
      "buildings\\Orc\\GreatHall\\GreatHall.mdx",
      "buildings\\Orc\\WarMill\\WarMill.mdx",
      "buildings\\Orc\\AltarofStorms\\AltarofStorms.mdx",
      "buildings\\Orc\\OrcBarracks\\OrcBarracks.mdx"
    };
    private static readonly int[] BuildAbilitys =
    {
      Constants.ABILITY_A00O_UNPACK_GREAT_HALL_PACK_KODO,
      Constants.ABILITY_A0D9_UNPACK_WAR_MILL_PACK_KODO,
      Constants.ABILITY_A0E4_UNPACK_ALTAR_OF_STORMS_PACK_KODO,
      Constants.ABILITY_A02U_UNPACK_WAR_CAMP_PACK_KODO
    };

    /// <summary>
    /// Adds the build ability and special effect to one of the preplaced Kodos 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="packedUnit"></param>
    private static void KodoSetup(int index, unit packedUnit)
    {
      var packable = new StructurePacking.PackableStructure
      {
        PackedUnitId = Constants.UNIT_OOSC_PACK_KODO_FROSTWOLF,
        BuildAbility = BuildAbilitys[index],
        StructureModel = StructureModels[index],
        StructureId = Buildings[index]
      };
      packable.PackUnitSetup(packedUnit);
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