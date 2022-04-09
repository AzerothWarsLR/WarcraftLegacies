using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Naga;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup{
    public static QuestData EXILE_PATH { get; private set; }
    public static QuestData MADNESS_PATH { get; private set; }
    public static QuestData REDEMPTION_PATH { get; private set; }
    public static QuestData CONQUER_BLACK_TEMPLE { get; private set; }
    public static QuestData KILL_FROZEN_THRONE { get; private set; }
    
    public static void Setup( ){
      //Early duel

      QuestData chapterThree = new QuestIllidanChapterThree(PreplacedUnitSystem.GetUnitByUnitType(FourCC("n045")));
      QuestData chapterTwo = QuestIllidanChapterTwo.create(chapterThree);
      QuestData chapterOne = QuestIllidanChapterOne.create(chapterTwo);
      NagaSetup.FactionNaga.AddQuest(chapterOne);
      NagaSetup.FactionNaga.AddQuest(chapterTwo);
      NagaSetup.FactionNaga.AddQuest(chapterThree);

      EXILE_PATH = QuestExilePath.create();
      MADNESS_PATH = QuestMadnessPath.create();
      REDEMPTION_PATH = QuestRedemptionPath.create();
      CONQUER_BLACK_TEMPLE = QuestBlackTemple.create();
      KILL_FROZEN_THRONE = QuestFrozenThrone.create();

      chapterTwo.Progress = QUEST_PROGRESS_UNDISCOVERED;
      chapterThree.Progress = QUEST_PROGRESS_UNDISCOVERED;

      NagaSetup.FactionNaga.StartingQuest = chapterOne;
    }

  }
}
