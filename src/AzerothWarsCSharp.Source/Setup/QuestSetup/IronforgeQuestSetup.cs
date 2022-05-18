using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Ironforge;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class IronforgeQuestSetup
  {
    public static void Setup()
    {
      var ironforge = IronforgeSetup.FACTION_IRONFORGE;
      QuestData newQuest = ironforge.AddQuest(new QuestThelsamar(Regions.ThelUnlock));
      ironforge.StartingQuest = newQuest;
      ironforge.AddQuest(new QuestDunMorogh());
      ironforge.AddQuest(new QuestDominion(Regions.IronforgeAmbient));
      ironforge.AddQuest(new QuestGnomeregan(Regions.Gnomergan));
      ironforge.AddQuest(new QuestDarkIron());
      ironforge.AddQuest(new QuestWildhammer());
    }
  }
}