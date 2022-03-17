using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.RoC.Quests.Stormwind;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class StormwindQuestSetup{

    public static void OnInit( ){
      //Setup
      QuestData newQuest = FACTION_STORMWIND.AddQuest(QuestDarkshire.create());
      FACTION_STORMWIND.StartingQuest = newQuest;
      //Early duel
      FACTION_STORMWIND.AddQuest(QuestLakeshire.create());
      FACTION_STORMWIND.AddQuest(QuestGoldshire.create());
      FACTION_STORMWIND.AddQuest(QuestStormwindCity.create());
      FACTION_STORMWIND.AddQuest(QuestNethergarde.create());
      //Misc
      FACTION_STORMWIND.AddQuest(QuestStromgarde.create());
      FACTION_STORMWIND.AddQuest(QuestHonorHold.create());
      FACTION_STORMWIND.AddQuest(QuestKhadgar.create());
      FACTION_STORMWIND.AddQuest(QuestClosePortal.create());
    }

  }
}
