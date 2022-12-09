using WarcraftLegacies.Source.Quests.Forsaken;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ForsakenQuestSetup
  {
    public static void Setup()
    {
      var forsaken = ForsakenSetup.Forsaken;

      forsaken.StartingQuest = forsaken.AddQuest(new QuestScholomanceBuild());
      forsaken.AddQuest(new QuestReanimateSylvanas());
      forsaken.AddQuest(new QuestThePlaguelands());
    }
  }
}