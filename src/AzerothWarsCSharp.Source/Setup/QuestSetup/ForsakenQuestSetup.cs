using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Forsaken;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class ForsakenQuestSetup
  {
    public static void Setup(QuestData questPlague)
    {
      var forsaken = ForsakenSetup.Forsaken;

      forsaken.StartingQuest = forsaken.AddQuest(new QuestScholomanceBuild());
      forsaken.AddQuest(new QuestReanimateSylvanas());
      forsaken.AddQuest(new QuestUndercity(Regions.UndercityUnlock, null, null));
      forsaken.AddQuest(new QuestThePlaguelands());
      forsaken.AddQuest(new QuestOpenScholomance(questPlague));
    }
  }
}