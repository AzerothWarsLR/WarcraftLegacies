using AzerothWarsCSharp.Source.Quests.Zandalar;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class TrollQuestSetup{

    public static void Setup( )
    {
      var zandalar = TrollSetup.FACTION_TROLL;
      
      zandalar.StartingQuest = zandalar.AddQuest(new QuestZandalar());
      zandalar.AddQuest(new QuestConquerKul());
      zandalar.AddQuest(new QuestZulfarrak());
      zandalar.AddQuest(new QuestZulgurub());
      zandalar.AddQuest(new QuestGundrak());
      zandalar.AddQuest(new QuestJinthaAlor());
      zandalar.AddQuest(new QuestHakkar());

    }

  }
}
