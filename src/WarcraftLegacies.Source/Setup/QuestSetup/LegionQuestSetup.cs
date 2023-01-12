using MacroTools;
using WarcraftLegacies.Source.Quests.Legion;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class LegionQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      //Early duel
      var newQuest = LegionSetup.Legion.AddQuest(new QuestArgusControl(preplacedUnitSystem));
      LegionSetup.Legion.StartingQuest = newQuest;
      LegionSetup.Legion.AddQuest(new QuestEmbassy(Regions.Northrend_Ambiance, Regions.AlteracAmbient));
      LegionSetup.Legion.AddQuest(new QuestAlteracBase(Regions.AlteracAmbient, preplacedUnitSystem));
      LegionSetup.Legion.AddQuest(new QuestLegionCaptureSunwell());
      LegionSetup.Legion.AddQuest(new QuestLegionKillLordaeron());
      //Misc
      LegionSetup.Legion.AddQuest(new QuestSummonLegion(Regions.TwistingNether,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N03C_DEMON_PORTAL_NETHER)));
      LegionSetup.Legion.AddQuest(new QuestConsumeTree());
    }
  }
}