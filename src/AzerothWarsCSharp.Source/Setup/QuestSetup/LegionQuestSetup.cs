using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Legion;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class LegionQuestSetup
  {
    public static void Setup()
    {
      //Early duel
      QuestData newQuest = LegionSetup.Legion.AddQuest(new QuestArgusControl());
      LegionSetup.Legion.StartingQuest = newQuest;
      LegionSetup.Legion.AddQuest(new QuestEmbassy());
      LegionSetup.Legion.AddQuest(new QuestLegionCaptureSunwell());
      LegionSetup.Legion.AddQuest(new QuestLegionKillLordaeron());
      //Misc
      LegionSetup.Legion.AddQuest(new QuestSummonLegion(Regions.TwistingNether,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N03C_DEMON_PORTAL_NETHER)));
      LegionSetup.Legion.AddQuest(new QuestConsumeTree());
      LegionSetup.Legion.AddQuest(new QuestDreadlordInsurgent());
    }
  }
}