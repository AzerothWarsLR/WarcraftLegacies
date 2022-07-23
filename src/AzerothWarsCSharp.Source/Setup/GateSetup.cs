using AzerothWarsCSharp.MacroTools.Gates;

namespace AzerothWarsCSharp.Source.Setup
{
  public static class GateSetup
  {
    public static void Setup()
    {
      var gateService = new GateService(Constants.ABILITY_A036_OPEN_GATE, Constants.ABILITY_A01L_CLOSE_GATE);
      gateService.RegisterGate(new Gate(Constants.UNIT_H00L_HORIZONTAL_WOODEN_GATE_OPEN,
        Constants.UNIT_H00K_HORIZONTAL_WOODEN_GATE_CLOSED, Constants.UNIT_H00M_HORIZONTAL_WOODEN_GATE_DEAD));
      gateService.RegisterGate(new Gate(Constants.UNIT_H01X_GATE_OF_SILVERMOON_OPEN,
        Constants.UNIT_H01W_GATE_OF_SILVERMOON_CLOSED, Constants.UNIT_H01Y_GATE_OF_SILVERMOON_DEAD));
      gateService.RegisterGate(new Gate(Constants.UNIT_H02J_STORMWIND_HARBOUR_GATE_OPEN,
        Constants.UNIT_H02H_STORMWIND_HARBOUR_GATE_CLOSED, Constants.UNIT_H02I_STORMWIND_HARBOUR_GATE_DEAD));
      gateService.RegisterGate(new Gate(Constants.UNIT_H02S_GATES_OF_AHN_QIRAJ_OPEN,
        Constants.UNIT_H02U_GATES_OF_AHN_QIRAJ_CLOSED, Constants.UNIT_H02T_GATES_OF_AHN_QIRAJ_DEAD));
      gateService.RegisterGate(new Gate(Constants.UNIT_H04R_ULDUM_GATE_OPEN, Constants.UNIT_H04S_ULDUM_GATE_CLOSED,
        Constants.UNIT_H04T_ULDUM_GATE_DEAD));
      gateService.RegisterGate(new Gate(Constants.UNIT_H02M_GREYMANE_S_GATE_OPEN,
        Constants.UNIT_H02K_GREYMANE_S_GATE_CLOSED, Constants.UNIT_H02L_GREYMANE_S_GATE_DEAD));
    }
  }
}