using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;

namespace WarcraftLegacies.Source.Setup
{
  public static class GateSetup
  {
    public static void Setup()
    {
      PassiveAbilityManager.Register(new Gate(UNIT_H00L_HORIZONTAL_WOODEN_GATE_OPEN,
        UNIT_H00K_HORIZONTAL_WOODEN_GATE_CLOSED, UNIT_H00M_HORIZONTAL_WOODEN_GATE_DEAD));
      PassiveAbilityManager.Register(new Gate(UNIT_H01X_ELVEN_GATE_OPEN,
        UNIT_H01W_ELVEN_GATE_CLOSED, UNIT_H01Y_ELVEN_GATE_DEAD));
      PassiveAbilityManager.Register(new Gate(UNIT_H02J_STORMWIND_HARBOUR_GATE_OPEN,
        UNIT_H02H_STORMWIND_HARBOUR_GATE_CLOSED, UNIT_H02I_STORMWIND_HARBOUR_GATE_DEAD));
      PassiveAbilityManager.Register(new Gate(UNIT_H02S_GATES_OF_AHN_QIRAJ_OPEN,
        UNIT_H02U_GATES_OF_AHN_QIRAJ_CLOSED, UNIT_H02T_GATES_OF_AHN_QIRAJ_DEAD));
      PassiveAbilityManager.Register(new Gate(UNIT_H02M_GREYMANE_S_GATE_OPEN,
        UNIT_H02K_GREYMANE_S_GATE_CLOSED, UNIT_H02L_GREYMANE_S_GATE_DEAD));
      PassiveAbilityManager.Register(new Gate(UNIT_H04R_DIAGONAL_WOODEN_GATE_OPEN,
        UNIT_H04S_DIAGONAL_WOODEN_GATE_CLOSED, UNIT_H04T_DIAGONAL_WOODEN_GATE_DEAD));
    }
  }
}