using AzerothWarsCSharp.MacroTools;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.UnitTypes
{
  public static class UnitTypeConfig
  {

    public static void Setup()
    {
      UnitType.Register(new UnitType(Constants.UNIT_NCOP_TAVERN_SELECTOR)
      {
        Meta = true
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_HSHY_ALLIANCE_SHIPYARD_LORDAERON)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H076_ALLIANCE_SHIPYARD_DALARAN)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H07W_SHIPYARD_KUL_TIRAS)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H077_ALLIANCE_SHIPYARD_HIGH_ELVES)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H03H_SHIPYARD_GILNEAS)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H06D_ROYAL_HARBOUR_STORMWIND)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_H07D_SHIPYARD_IRONFORGE)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_OSHY_HORDE_PIER_FROSTWOLF)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O02T_HORDE_PIER_WARSONG)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O032_HORDE_PIER_FEL_HORDE)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O03I_TWILIGHT_DOCK_TWILIGHT)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O049_GOLDEN_DOCK_ZANDALAR)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O03V_GOBLIN_DOCK_GOBLIN)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_USHP_HAUNTED_HARBOR)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_U009_HAUNTED_HARBOR_LEGION)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_U01A_HAUNTED_HARBOR_FORSAKEN)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_ESHY_KALDOREI_DOCKS)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_E011_KALDOREI_DOCKS_SENTINEL)
      {
        Category = UnitCategory.Shipyard
      });
      
      UnitType.Register(new UnitType(Constants.UNIT_O04R_OIL_PLATFORM_GOBLIN)
      {
        Category = UnitCategory.Shipyard
      });
    }
  }
}