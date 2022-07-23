using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Frostwolf;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
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