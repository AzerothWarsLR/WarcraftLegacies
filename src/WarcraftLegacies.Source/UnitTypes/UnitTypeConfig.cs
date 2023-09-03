using MacroTools;

namespace WarcraftLegacies.Source.UnitTypes
{
  public static class UnitTypeConfig
  {
    public static void Setup()
    {
      SubSetupA();
      SubSetupB();
    }

    private static void SubSetupA()
    {
      UnitType.Register(new UnitType(Constants.UNIT_HSHY_SHIPYARD_LORDAERON_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H076_SHIPYARD_DALARAN_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H07W_SHIPYARD_KUL_TIRAS_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H077_SHIPYARD_QUEL_THALAS_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H03H_SHIPYARD_GILNEAS_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H06D_ROYAL_HARBOUR_STORMWIND_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_H07D_SHIPYARD_IRONFORGE_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_OSHY_HORDE_PIER_FROSTWOLF_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_O032_SHIPYARD_FEL_HORDE_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });
    }

    private static void SubSetupB()
    {
      UnitType.Register(new UnitType(Constants.UNIT_O03I_SHIPYARD_TWILIGHT_DOCK)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_O049_GOLDEN_DOCK_ZANDALARI_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_O03V_BILGEWATER_HARBOR_GOBLIN_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_USHP_HAUNTED_HARBOR_SCOURGE)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_U009_SHIPYARD_LEGION_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_U01A_SHIPYARD_FORSAKEN_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_ESHY_KALDOREI_DOCKS)
      {
        Category = UnitCategory.Shipyard
      });

      UnitType.Register(new UnitType(Constants.UNIT_E011_KALDOREI_DOCKS_SENTINEL_SHIPYARD)
      {
        Category = UnitCategory.Shipyard
      });
    }
  }
}