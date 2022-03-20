using AzerothWarsCSharp.MacroTools.QuestSystem;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class GilneasQuestSetup{

    public static void Setup( ){
      //Early duel
      QuestData ChapterOne = FACTION_GILNEAS.AddQuest(QuestGilneasChapterOne.create());
      QuestData ChapterTwo = FACTION_GILNEAS.AddQuest(QuestGilneasChapterTwo.create());
      QuestData ChapterThree = FACTION_GILNEAS.AddQuest(QuestGilneasChapterThree.create());

      FACTION_GILNEAS.StartingQuest = ChapterOne;

      ChapterTwo.Progress = QUEST_PROGRESS_UNDISCOVERED;
      ChapterThree.Progress = QUEST_PROGRESS_UNDISCOVERED;

      GOLDRINNELVE_PATH = QuestGoldrinnElvePath.create();
      //set GOLDRINNHUMAN_PATH = QuestGoldrinnHumanPath.create()

    }

  }
}
