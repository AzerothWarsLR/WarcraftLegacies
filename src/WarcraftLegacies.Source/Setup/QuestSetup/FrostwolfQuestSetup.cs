using MacroTools;
using WarcraftLegacies.Source.Quests.Frostwolf;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FrostwolfQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var frostwolf = FrostwolfSetup.Frostwolf;
      if (frostwolf != null)
      {
        frostwolf.AddQuest(new QuestThunderBluff(preplacedUnitSystem, Regions.ThunderBluff));
        frostwolf.AddQuest(new QuestStonemaul(preplacedUnitSystem, Regions.StonemaulKeep));
        frostwolf.AddQuest(new QuestDarkspear());
        frostwolf.AddQuest(new QuestDrektharsSpellbook(allLegendSetup.Druids.Nordrassil, allLegendSetup.Frostwolf.Thrall));
        frostwolf.AddQuest(new QuestFreeNerzhul(allLegendSetup.Scourge.TheFrozenThrone, allLegendSetup.Frostwolf.Thrall));
        frostwolf.AddQuest(new QuestWorldShaman(allLegendSetup.Frostwolf.Thrall));
      }
    }
  }
}