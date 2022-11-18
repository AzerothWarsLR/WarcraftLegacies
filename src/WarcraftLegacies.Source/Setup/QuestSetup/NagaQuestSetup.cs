using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class NagaQuestSetup
  {
    public static QuestData EXILE_PATH { get; private set; }
    public static QuestData MADNESS_PATH { get; private set; }
    public static QuestData REDEMPTION_PATH { get; private set; }
    public static QuestData CONQUER_BLACK_TEMPLE { get; private set; }
    public static QuestData KILL_FROZEN_THRONE { get; private set; }

    public static void Setup()
    {
      // //Early duel
      //
      // QuestData chapterThree = new QuestIllidanChapterThree(preplacedUnitSystem.GetUnitByUnitType(FourCC("n045")), Regions.NagaUnlock1, Regions.NagaUnlock2);
      // QuestData chapterTwo = new QuestIllidanChapterTwo(chapterThree);
      // QuestData chapterOne = new QuestIllidanChapterOne(chapterTwo);
      // NagaSetup.FactionNaga.AddQuest(chapterOne);
      // NagaSetup.FactionNaga.AddQuest(chapterTwo);
      // NagaSetup.FactionNaga.AddQuest(chapterThree);
      //
      // //EXILE_PATH = new QuestExilePath();
      // //REDEMPTION_PATH = new QuestRedemptionPath();
      // CONQUER_BLACK_TEMPLE = new QuestBlackTemple();
      // KILL_FROZEN_THRONE = new QuestFrozenThrone();
      //
      // chapterTwo.Progress = QuestProgress.Undiscovered;
      // chapterThree.Progress = QuestProgress.Undiscovered;
      //
      // NagaSetup.FactionNaga.StartingQuest = chapterOne;
    }
  }
}