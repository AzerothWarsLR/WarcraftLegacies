using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Cthun;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class CthunQuestSetup
  {
    public static void Setup()
    {
      var cthun = CthunSetup.FactionCthun;
      cthun.StartingQuest = cthun.AddQuest(new QuestTitanJailors(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H03V_ENTRANCE_PORTAL)));
      cthun.AddQuest(new QuestAwakenCthun(PreplacedUnitSystem.GetUnitByUnitType(FourCC("U00R"))));
      cthun.AddQuest(new QuestEndlessRanks());
      cthun.AddQuest(new QuestGatesofAhnqiraj(
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H03V_ENTRANCE_PORTAL),
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H03V_ENTRANCE_PORTAL),
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H02U_GATES_OF_AHN_QIRAJ_CLOSED)));
      cthun.AddQuest(new QuestDragonSoul());
      cthun.AddQuest(new QuestWyrmrestTemple());
    }
  }
}