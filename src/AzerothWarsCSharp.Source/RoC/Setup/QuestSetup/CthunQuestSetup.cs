using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.RoC.Quests.Cthun;
using AzerothWarsCSharp.Source.RoC.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public static class CthunQuestSetup
  {
    public static void Setup()
    {
      var cthun = CthunSetup.FACTION_CTHUN;
      cthun.StartingQuest = cthun.AddQuest(new QuestTitanJailors());
      cthun.AddQuest(new QuestAwakenCthun(PreplacedUnitSystem.GetUnitByUnitType(FourCC("U00R"))));
      cthun.AddQuest(new QuestEndlessRanks());
      cthun.AddQuest(new QuestGatesofAhnqiraj());
      cthun.AddQuest(new QuestDragonSoul());
      cthun.AddQuest(new QuestWyrmrestTemple());
    }
  }
}