using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Legion;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class LegionQuestSetup{

    public static void Setup( ){
      //Early duel
      QuestData newQuest = LegionSetup.FactionLegion.AddQuest(QuestArgusControl.create());
      LegionSetup.FactionLegion.StartingQuest = newQuest;
      LegionSetup.FactionLegion.AddQuest(QuestEmbassy.create());
      LegionSetup.FactionLegion.AddQuest(QuestLegionCaptureSunwell.create());
      LegionSetup.FactionLegion.AddQuest(QuestLegionKillLordaeron.create());
      //Misc
      LegionSetup.FactionLegion.AddQuest(QuestSummonLegion.create());
      LegionSetup.FactionLegion.AddQuest(QuestConsumeTree.create());
      LegionSetup.FactionLegion.AddQuest(QuestDreadlordInsurgent.create());
    }

  }
}
