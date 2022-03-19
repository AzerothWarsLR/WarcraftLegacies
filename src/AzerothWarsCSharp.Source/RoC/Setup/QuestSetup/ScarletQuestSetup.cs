using AzerothWarsCSharp.Source.RoC.Quests.Scarlet;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class ScarletQuestSetup{

    public static void Setup( ){
      //Early duel
      FACTION_SCARLET.StartingQuest = FACTION_SCARLET.AddQuest(QuestTownWatch.create());
      FACTION_SCARLET.AddQuest(QuestMonastery.create());
      FACTION_SCARLET.AddQuest(QuestArgentDawn.create());
      FACTION_SCARLET.AddQuest(QuestArathiVolunteers.create());
      FACTION_SCARLET.AddQuest(QuestTyr.create());
      FACTION_SCARLET.AddQuest(QuestLiberateLordaeron.create());
    }


  }
}
