using MacroTools.UnitTypes;
using WarcraftLegacies.Shared;

namespace WarcraftLegacies.Source.Setup;

public static class UnitTypeSetup
{
  public static void Setup()
  {
    SubSetupFactionConfig();
    SubSetupPortals();
    SubSetupTrader();
    SubSetupGatesA();
    SubSetupGatesB();
    SubSetupGoblinMerchant();
  }

  private static void SubSetupFactionConfig()
  {
    var objectInfoRepository = new ObjectInfoRepository();
    foreach (var objectInfo in objectInfoRepository.GetAllObjectInfo())
    {
      UnitType.Register(new UnitType(objectInfo.ObjectTypeId)
      {
        Categories = objectInfo.Categories
      });
    }
  }

  private static void SubSetupPortals()
  {
    UnitType.Register(new UnitType(UNIT_N036_DARK_PORTAL_WAYGATE)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS)
    {
      NeverDelete = true
    });
  }

  private static void SubSetupTrader()
  {
    UnitType.Register(new UnitType(UNIT_H014_TRADING_POST_SEA)
    {
      NeverDelete = true
    });
  }

  private static void SubSetupGatesA()
  {
    UnitType.Register(new UnitType(UNIT_H00L_HORIZONTAL_WOODEN_GATE_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H00K_HORIZONTAL_WOODEN_GATE_GATE_CLOSED)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H00M_HORIZONTAL_WOODEN_GATE_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H01X_ELVEN_GATE_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H01W_ELVEN_GATE_GATE_CLOSED)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H01Y_ELVEN_GATE_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02J_STORMWIND_HARBOUR_GATE_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02H_STORMWIND_HARBOUR_GATE_GATE_CLOSED)
    {
      NeverDelete = true
    });
  }

  private static void SubSetupGatesB()
  {
    UnitType.Register(new UnitType(UNIT_H02I_STORMWIND_HARBOUR_GATE_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02S_GATES_OF_AHN_QIRAJ_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02U_GATES_OF_AHN_QIRAJ_GATE_CLOSED)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02T_GATES_OF_AHN_QIRAJ_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02M_GREYMANE_S_GATE_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02K_GREYMANE_S_GATE_GATE_CLOSED)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H02L_GREYMANE_S_GATE_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H04R_DIAGONAL_WOODEN_GATE_GATE_OPEN)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H04T_DIAGONAL_WOODEN_GATE_GATE_DEAD)
    {
      NeverDelete = true
    });

    UnitType.Register(new UnitType(UNIT_H04S_DIAGONAL_WOODEN_GATE_GATE_CLOSED)
    {
      NeverDelete = true
    });
  }

  private static void SubSetupGoblinMerchant()
  {
    UnitType.Register(new UnitType(FourCC("ngol"))
    {
      NeverDelete = true
    });
  }
}
