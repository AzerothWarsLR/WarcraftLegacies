using MacroTools;
using WarcraftLegacies.Source.Quests.Zandalar;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ZandalarQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var zandalar = ZandalarSetup.Zandalar;
      zandalar.AddQuest(new QuestZulfarrak(Regions.Zulfarrak, allLegendSetup.Neutral.Zulfarrak, allLegendSetup.Troll.Zul));
    }
  }
}
