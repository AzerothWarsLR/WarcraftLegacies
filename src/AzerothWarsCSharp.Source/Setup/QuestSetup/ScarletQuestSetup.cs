using AzerothWarsCSharp.Source.Quests.Scarlet;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class ScarletQuestSetup{

    public static void Setup( ){
      //Early duel
      ScarletSetup.FactionScarlet.StartingQuest = ScarletSetup.FactionScarlet.AddQuest(QuestTownWatch.create());
      ScarletSetup.FactionScarlet.AddQuest(QuestMonastery.create());
      ScarletSetup.FactionScarlet.AddQuest(QuestArgentDawn.create());
      ScarletSetup.FactionScarlet.AddQuest(QuestArathiVolunteers.create());
      ScarletSetup.FactionScarlet.AddQuest(QuestTyr.create());
      ScarletSetup.FactionScarlet.AddQuest(QuestLiberateLordaeron.create());
    }


  }
}
