using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.RoC.Quests.Quelthalas;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class QuelthalasQuestSetup{

    public static void Setup( ){
      //Setup
      QuestData newQuest = FACTION_QUELTHALAS.AddQuest(QuestSilvermoon.create());
      QuestData tempestKeep = QuestTempestKeep.create();

      FACTION_QUELTHALAS.StartingQuest = newQuest;
      //Early duel
      FACTION_QUELTHALAS.AddQuest(QuestTheBloodElves.create());
      FACTION_QUELTHALAS.AddQuest(QuestQueldanil.create());

      FACTION_QUELTHALAS.AddQuest(tempestKeep);
      tempestKeep.Progress = QUEST_PROGRESS_UNDISCOVERED;

      SUMMON_KIL = QuestSummonKil.create();
      GREAT_TREACHERY = QuestGreatTreachery.create();
      STAY_LOYAL = QuestStayLoyal.create();
    }

  }
}
