using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Cthun;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class CthunQuestSetup
  {
    public static void Setup()
    {
      var cthun = CthunSetup.factionCthun;
      cthun.StartingQuest = cthun.AddQuest(new QuestTitanJailors());
      cthun.AddQuest(new QuestAwakenCthun(PreplacedUnitSystem.GetUnitByUnitType(FourCC("U00R"))));
      cthun.AddQuest(new QuestEndlessRanks());
      cthun.AddQuest(new QuestGatesofAhnqiraj());
      cthun.AddQuest(new QuestDragonSoul());
      cthun.AddQuest(new QuestWyrmrestTemple());
    }
  }
}