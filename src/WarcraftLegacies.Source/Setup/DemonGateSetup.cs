using MacroTools.Mechanics.DemonGates;
using MacroTools.PassiveAbilitySystem;

namespace WarcraftLegacies.Source.Setup;

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

    // Red
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N000_FEL_HOUND_DEMON_GATE_T1_HOUNDS, UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 30, 1, 12));
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N05F_VOIDWALKER_DEMON_GATE_T1_VOIDWALKER, UNIT_NVDL_VOIDWALKER_FEL_HORDE_PORTAL, 30, 1, 12));

    // Fel Gates
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N05I_FEL_HOUND_PACK_DEMON_GATE_T2_HOUNDS_PACK, UNIT_N059_FEL_HOUND_FEL_HORDE_PORTAL, 30, 3, 12));
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N05R_FELGUARD_DEMON_GATE_T2_BLOODFIEND, UNIT_N05B_FELGUARD_FEL_HORDE_PORTAL, 60, 2, 12));
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N06H_PIT_FIEND_DEMON_GATE_T2_PITFIEND, UNIT_O015_PIT_FIEND_FEL_HORDE_PORTAL, 60, 1, 6));

    // Void Gates
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N06G_NETHER_DRAKE_DEMON_GATE_T2_NETHER_DRAKE, UNIT_N070_NETHER_DRAKE_FEL_HORDE_PORTAL, 60, 1, 6));
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N07M_VOIDLORD_DEMON_GATE_T2_VOIDLORD, UNIT_N088_VOIDLORD_FEL_HORDE_PORTAL, 60, 1, 6));
    PassiveAbilityManager.Register(new DemonGateType(UNIT_N07O_TERRORGUARD_DEMON_GATE_T2_TERROR_GUARD, UNIT_O014_TERRORGUARD_FEL_HORDE_PORTAL, 90, 1, 6));
  }
}
