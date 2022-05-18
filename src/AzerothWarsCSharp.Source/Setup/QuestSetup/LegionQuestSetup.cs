using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Legion;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class LegionQuestSetup{

    public static void Setup( ){
      //Early duel
      QuestData newQuest = LegionSetup.FactionLegion.AddQuest(new QuestArgusControl());
      LegionSetup.FactionLegion.StartingQuest = newQuest;
      LegionSetup.FactionLegion.AddQuest(new QuestEmbassy());
      LegionSetup.FactionLegion.AddQuest(new QuestLegionCaptureSunwell());
      LegionSetup.FactionLegion.AddQuest(new QuestLegionKillLordaeron());
      //Misc
      LegionSetup.FactionLegion.AddQuest(new QuestSummonLegion());
      LegionSetup.FactionLegion.AddQuest(new QuestConsumeTree());
      LegionSetup.FactionLegion.AddQuest(new QuestDreadlordInsurgent());
    }

  }
}
