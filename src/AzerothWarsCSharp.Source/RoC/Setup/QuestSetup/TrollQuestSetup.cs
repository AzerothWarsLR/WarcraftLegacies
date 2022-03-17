using AzerothWarsCSharp.Source.RoC.Quests.Zandalar;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class TrollQuestSetup{

    public static void OnInit( ){

      FACTION_TROLL.StartingQuest = FACTION_TROLL.AddQuest(QuestZandalar.create());
      //call FACTION_TROLL.AddQuest(QuestGoldenFleet.create())
      FACTION_TROLL.AddQuest(QuestConquerKul.create());
      FACTION_TROLL.AddQuest(QuestZulfarrak.create());
      FACTION_TROLL.AddQuest(QuestZulgurub.create());
      FACTION_TROLL.AddQuest(QuestGundrak.create());
      FACTION_TROLL.AddQuest(QuestJinthaAlor.create());
      FACTION_TROLL.AddQuest(QuestHakkar.create());

    }

  }
}
