using AzerothWarsCSharp.Source.RoC.Quests.Forsaken;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class ForsakenQuestSetup{

    public static void OnInit( ){

      FACTION_FORSAKEN.StartingQuest = FACTION_FORSAKEN.AddQuest(QuestScholomanceBuild.create());
      FACTION_FORSAKEN.AddQuest(QuestReanimateSylvanas.create());
      FACTION_FORSAKEN.AddQuest(QuestUndercity.create());
      FACTION_FORSAKEN.AddQuest(QuestThePlaguelands.create());
      FACTION_FORSAKEN.AddQuest(QuestRetakeSunwell.create());
      FACTION_FORSAKEN.AddQuest(QuestTheNine.create());
      FACTION_FORSAKEN.AddQuest(QuestTakeRevenge.create());


    }

  }
}
