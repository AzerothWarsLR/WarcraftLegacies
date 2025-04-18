using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup
{
  public static class TurnResearchSetup
  {
    public static void Setup()
    {
      TurnResearch.Register(new TurnResearch(UPGRADE_R08I_TURN_25_HAS_PASSED, 25));
      TurnResearch.Register(new TurnResearch(UPGRADE_R067_TURN_7_HAS_PASSED, 6));
      TurnResearch.Register(new TurnResearch(UPGRADE_R04J_TURN_18_HAS_PASSED, 18));
      TurnResearch.Register(new TurnResearch(UPGRADE_R04N_TURN_3_HAS_PASSED, 3));
      TurnResearch.Register(new TurnResearch(UPGRADE_R08C_TURN_10_HAS_PASSED, 10));
    }
  }
}