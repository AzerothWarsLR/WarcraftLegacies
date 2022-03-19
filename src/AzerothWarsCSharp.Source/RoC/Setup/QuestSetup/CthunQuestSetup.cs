using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.RoC.Quests.Cthun;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public static class CthunQuestSetup
  {
    public static void Setup()
    {
      FACTION_CTHUN.StartingQuest = FACTION_CTHUN.AddQuest(new QuestTitanJailors());
      FACTION_CTHUN.AddQuest(new QuestAwakenCthun(PreplacedUnitSystem.GetUnitByUnitType(FourCC("U00R"))));
      FACTION_CTHUN.AddQuest(new QuestEndlessRanks());
      FACTION_CTHUN.AddQuest(new QuestGatesofAhnqiraj());
      FACTION_CTHUN.AddQuest(new QuestDragonSoul());
      FACTION_CTHUN.AddQuest(new QuestWyrmrestTemple());
    }
  }
}