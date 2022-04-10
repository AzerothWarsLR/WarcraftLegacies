using AzerothWarsCSharp.Source.Quests.Forsaken;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class ForsakenQuestSetup{

    public static void Setup( )
    {
      var forsaken = ForsakenSetup.FACTION_FORSAKEN;
      
      forsaken.StartingQuest = forsaken.AddQuest(new QuestScholomanceBuild());
      forsaken.AddQuest(new QuestReanimateSylvanas());
      forsaken.AddQuest(new QuestUndercity(null, null));
      forsaken.AddQuest(new QuestThePlaguelands());
      forsaken.AddQuest(new QuestRetakeSunwell());
      forsaken.AddQuest(new QuestTheNine());
      forsaken.AddQuest(new QuestTakeRevenge());


    }

  }
}
