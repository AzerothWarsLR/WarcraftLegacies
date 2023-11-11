using MacroTools.Mechanics.DemonGates;
using MacroTools.PassiveAbilitySystem;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for registering all <see cref="DemonGateType"/>s.
  /// </summary>
  public static class DemonGateSetup
  {
    /// <summary>
    /// Registers all <see cref="DemonGateType"/>s.
    /// </summary>
    public static void Setup()
    {
      DemonGateBuff.Setup(Constants.ABILITY_A05V_TOGGLE_SUMMONING_FEL_HORDE_DEMON_GATE, Constants.BUFF_B08B_TOGGLE_SUMMONING_FEL_HORDE_DEMON_GATE);
      
      PassiveAbilityManager.Register(new FocalDemonGate(Constants.UNIT_N0AP_FOCAL_DEMON_GATE_FEL_HORDE_SIEGE));
      
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N000_FEL_HOUND_DEMON_GATE_T1_HOUNDS,
        Constants.UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 80, 2));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N04I_EREDAR_WITCH_DEMON_GATE_T1_SUCCUBUS,
        Constants.UNIT_NDQN_SUCCUBUS_FEL_HORDE_PORTAL, 90, 1));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N05F_VOIDWALKER_DEMON_GATE_T1_VOIDWALKER,
        Constants.UNIT_NVDL_VOIDWALKER_FEL_HORDE_PORTAL, 60, 1));

      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N05I_FEL_HOUND_PACK_DEMON_GATE_T2_HOUNDS_PACK,
        Constants.UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 80, 6));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N05R_FELGUARD_DEMON_GATE_T2_BLOODFIEND,
        Constants.UNIT_N05B_FELGUARD_FEL_HORDE_PORTAL, 85, 2));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N06H_PIT_FIEND_DEMON_GATE_T2_PITFIEND,
        Constants.UNIT_O015_PIT_FIEND_FEL_HORDE_PORTAL, 90, 1));

      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N05S_COVENANT_OF_WITCH_DEMON_GATE_T2_SISTER,
        Constants.UNIT_NDQN_SUCCUBUS_FEL_HORDE_PORTAL, 80, 3));
      PassiveAbilityManager.Register(new DemonGateType(
        Constants.UNIT_N07B_QUEEN_OF_SUFFERING_DEMON_GATE_T3_QUEEN_SUFFERING,
        Constants.UNIT_NDQS_QUEEN_OF_SUFFERING_FEL_HORDE_PORTAL, 120, 1));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N07D_MAIDEN_OF_DOMINANCE_DEMON_GATE_T3_MAIDEN,
        Constants.UNIT_NDQP_MAIDEN_OF_DOMINANCE_FEL_HORDE_PORTAL_EYE_OF_SARGERAS, 100, 1));

      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N06G_VOIDCRUSHER_DEMON_GATE_T2_VOIDCRUSHER,
        Constants.UNIT_N08C_VOIDCRUSHER_FEL_HORDE_PORTAL, 80, 1));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N07M_VOIDLORD_DEMON_GATE_T3_VOIDLORD,
        Constants.UNIT_N088_VOIDLORD_FEL_HORDE_PORTAL, 130, 1));
      PassiveAbilityManager.Register(new DemonGateType(Constants.UNIT_N07O_TERRORGUARD_DEMON_GATE_T3_TERROR_GUARD,
        Constants.UNIT_O014_TERRORGUARD_FEL_HORDE_PORTAL, 240, 1));
    }
  }
}