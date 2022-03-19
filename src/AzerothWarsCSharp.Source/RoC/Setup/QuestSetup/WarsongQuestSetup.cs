using AzerothWarsCSharp.Source.RoC.Quests.Warsong;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class WarsongQuestSetup{

    public static void Setup( ){
      //Setup
      FACTION_WARSONG.StartingQuest = FACTION_WARSONG.AddQuest(QuestLumberQuota.create());
      FACTION_WARSONG.AddQuest(QuestCrossroads.create());
      FACTION_WARSONG.AddQuest(QuestChenStormstout.create());
      FACTION_WARSONG.AddQuest(QuestFountainOfBlood.create());
      //Early duel
      FACTION_WARSONG.AddQuest(QuestWarsongKillDruids.create());
      FACTION_WARSONG.AddQuest(QuestMoreWyverns.create());
      //Misc
      FACTION_WARSONG.AddQuest(QuestWarsongHold.create());

    }

  }
}
