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

      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_R062_PATH_OF_REDEMPTION_NAGA,
        Constants.UPGRADE_R063_PATH_OF_EXILE_NAGA, Constants.UPGRADE_R065_PATH_OF_MADNESS_NAGA);
      
      ResearchManager.RegisterIncompatibleSet(Constants.UPGRADE_ROBF_DEMONIC_FLUX_FEL_HORDE, 
        Constants.UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE);
    }
  }
}