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
      DemonGateBuff.Setup(ABILITY_A05V_TOGGLE_SUMMONING_FEL_HORDE_DEMON_GATE, BUFF_B08B_TOGGLE_SUMMONING_FEL_HORDE_DEMON_GATE);
      
      PassiveAbilityManager.Register(new FocalDemonGate(UNIT_N0AP_FOCAL_DEMON_GATE_FEL_HORDE_SIEGE));

      // Red - Fel Hound
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N000_FEL_HOUND_DEMON_GATE_T1_HOUNDS, UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 80, 1));
      // Green - Eredar Witch
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N04I_EREDAR_WITCH_DEMON_GATE_T1_SUCCUBUS, UNIT_NDQN_SUCCUBUS_FEL_HORDE_PORTAL, 90, 1));
      // Blue - Void Gates
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N05F_VOIDWALKER_DEMON_GATE_T1_VOIDWALKER, UNIT_NVDL_VOIDWALKER_FEL_HORDE_PORTAL, 60, 1));

      // Red - Fel Hound
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N05I_FEL_HOUND_PACK_DEMON_GATE_T2_HOUNDS_PACK, UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 80, 6));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N05R_FELGUARD_DEMON_GATE_T2_BLOODFIEND, UNIT_N05B_FELGUARD_FEL_HORDE_PORTAL, 85, 2));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N06H_PIT_FIEND_DEMON_GATE_T2_PITFIEND, UNIT_O015_PIT_FIEND_FEL_HORDE_PORTAL, 90, 1));

      // Green - Eredar Witch
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N05S_COVENANT_OF_WITCH_DEMON_GATE_T2_SISTER, UNIT_NDQN_SUCCUBUS_FEL_HORDE_PORTAL, 80, 3));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N07B_QUEEN_OF_SUFFERING_DEMON_GATE_T3_QUEEN_SUFFERING, UNIT_NDQS_QUEEN_OF_SUFFERING_FEL_HORDE_PORTAL, 120, 1));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N07D_MAIDEN_OF_DOMINANCE_DEMON_GATE_T3_MAIDEN, UNIT_NDQP_MAIDEN_OF_DOMINANCE_FEL_HORDE_PORTAL_EYE_OF_SARGERAS, 100, 1));

      // Blue - Void Gates
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N06G_VOIDCRUSHER_DEMON_GATE_T2_VOIDCRUSHER, UNIT_N08C_VOIDCRUSHER_FEL_HORDE_PORTAL, 80, 1));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N07M_VOIDLORD_DEMON_GATE_T3_VOIDLORD, UNIT_N088_VOIDLORD_FEL_HORDE_PORTAL, 130, 1));
      PassiveAbilityManager.Register(new DemonGateType(UNIT_N07O_TERRORGUARD_DEMON_GATE_T3_TERROR_GUARD, UNIT_O014_TERRORGUARD_FEL_HORDE_PORTAL, 240, 1));
    }
  }
}