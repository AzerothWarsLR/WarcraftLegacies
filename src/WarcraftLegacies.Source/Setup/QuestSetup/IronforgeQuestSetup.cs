using MacroTools;
using WarcraftLegacies.Source.Quests.Ironforge;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class IronforgeQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var ironforge = IronforgeSetup.Ironforge;
      var newQuest = ironforge.AddQuest(new QuestThelsamar(preplacedUnitSystem, Regions.ThelUnlock));
      ironforge.StartingQuest = newQuest;
      ironforge.AddQuest(new QuestGrimBatolOffensive());
      ironforge.AddQuest(new QuestTheAccursedCoast());
      ironforge.AddQuest(new QuestDunMorogh(preplacedUnitSystem));
      ironforge.AddQuest(new QuestDominion(Regions.IronforgeAmbient));
      ironforge.AddQuest(new QuestGnomeregan(Regions.Gnomergan, preplacedUnitSystem));
      ironforge.AddQuest(new QuestDarkIron(Regions.Shadowforge_City));
      ironforge.AddQuest(new QuestWildhammer());
    }
  }
}