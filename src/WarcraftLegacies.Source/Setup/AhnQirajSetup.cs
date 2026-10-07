using MacroTools.PreplacedWidgets;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Setup;

public static class AhnQirajSetup
{
  public static void Setup()
  {
    AllPreplacedWidgets.Units.Get(UNIT_H02U_GATES_OF_AHN_QIRAJ_GATE_CLOSED).IsInvulnerable = true;

    if (AllLegends.Neutral.CThun.Unit != null)
    {
      AllLegends.Neutral.CThun.Unit.IsInvulnerable = true;
    }
  }
}
