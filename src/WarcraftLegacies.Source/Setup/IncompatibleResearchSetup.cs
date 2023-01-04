using MacroTools.ResearchSystems;

namespace WarcraftLegacies.Source.Setup
{
  /// <summary>
  /// Responsible for registering all incompatible researches.
  /// </summary>
  public static class IncompatibleResearchSetup
  {
    /// <summary>
    /// Registers all incompatible researches
    /// </summary>
    public static void Setup()
    {
      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R02Y_BATTLE_TACTICS_ARATHOR_T1,
        Constants.UPGRADE_R03D_VETERAN_GUARD_ARATHOR_T1);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R03T_ELECTRIC_STRIKE_RITUAL_ARATHOR_T1,
        Constants.UPGRADE_R03U_SOLAR_FLARE_RITUAL_ARATHOR_T1);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R03B_EXPLOIT_WEAKNESS_ARATHOR_T2,
        Constants.UPGRADE_R02Z_REFLECTIVE_PLATING_ARATHOR_T2);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R03V_MAGES_OF_STROMGARDE_ARATHOR_T2,
        Constants.UPGRADE_R03W_KNOWLEDGE_OF_HONOR_HOLD_ARATHOR_T2);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R030_CODE_OF_CHIVALRY_ARATHOR_T3,
        Constants.UPGRADE_R031_EXPEDITION_SURVIVORS_ARATHOR_T3);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R03X_CONJURERS_ARATHOR_T3,
        Constants.UPGRADE_R03Y_KATRANA_PRESTOR_AID_ARATHOR_T3);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R062_PATH_OF_REDEMPTION_NAGA,
        Constants.UPGRADE_R063_PATH_OF_EXILE_NAGA, Constants.UPGRADE_R065_PATH_OF_MADNESS_NAGA);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R088_RAYS_OF_A_NEW_DAWN_SCARLET_CRUSADE,
        Constants.UPGRADE_R03P_UNLEASH_THE_CRUSADE_SCARLET_CRUSADE);

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R08F_GARITHOS_MIND_CONTROL_LORDAERON,
        Constants.UPGRADE_R08E_JOIN_THE_CRUSADE_LORDAERON);
      
      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_ROBF_DEMONIC_FLUX_FEL_HORDE, 
        Constants.UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE);
    }
  }
}