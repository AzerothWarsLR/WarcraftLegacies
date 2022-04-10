using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Ironforge;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class IronforgeQuestSetup{

    public static void Setup( )
    {
      var ironforge = IronforgeSetup.FACTION_IRONFORGE;
      
      //Setup
      QuestData newQuest = ironforge.AddQuest(new QuestThelsamar());
      ironforge.StartingQuest = newQuest;
      //Early duel
      ironforge.AddQuest(new QuestDunMorogh());
      ironforge.AddQuest(new QuestDominion());
      ironforge.AddQuest(new QuestGnomeregan());
      ironforge.AddQuest(new QuestDarkIron());
      ironforge.AddQuest(new QuestWildhammer());
      //Misc
    }

  }
}
