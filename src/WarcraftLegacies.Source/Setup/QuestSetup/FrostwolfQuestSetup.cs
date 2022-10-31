using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Frostwolf;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FrostwolfQuestSetup
  {
    public static void Setup()
    {
      var frostwolf = FrostwolfSetup.Frostwolf;

      QuestData newQuest = frostwolf.AddQuest(new QuestSeaWitch(Regions.EchoUnlock));
      frostwolf.StartingQuest = newQuest;
      frostwolf.AddQuest(new QuestThunderBluff(Regions.ThunderBluff.Rect));
      frostwolf.AddQuest(new QuestStonemaul(Regions.StonemaulKeep));
      frostwolf.AddQuest(new QuestDrektharsSpellbook());
      frostwolf.AddQuest(new QuestRoyalPlunder(Regions.HighBourne));
      frostwolf.AddQuest(new QuestFreeNerzhul());
    }
  }
}