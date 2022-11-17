using WarcraftLegacies.Source.Quests.Ironforge;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class IronforgeQuestSetup
  {
    public static void Setup()
    {
      var ironforge = IronforgeSetup.Ironforge;
      var newQuest = ironforge.AddQuest(new QuestThelsamar(Regions.ThelUnlock));
      ironforge.StartingQuest = newQuest;
      ironforge.AddQuest(new QuestGrimBatolOffensive());
      ironforge.AddQuest(new QuestTheAccursedCoast());
      ironforge.AddQuest(new QuestDunMorogh());
      ironforge.AddQuest(new QuestDominion(Regions.IronforgeAmbient));
      ironforge.AddQuest(new QuestGnomeregan(Regions.Gnomergan));
      ironforge.AddQuest(new QuestDarkIron(Regions.Shadowforge_City));
      ironforge.AddQuest(new QuestWildhammer());
    }
  }
}