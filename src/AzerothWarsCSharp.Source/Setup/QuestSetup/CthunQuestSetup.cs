using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Cthun;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class CthunQuestSetup
  {
    public static void Setup()
    {
      var cthun = CthunSetup.FactionCthun;
      cthun.StartingQuest = cthun.AddQuest(new QuestTitanJailors(Regions.TunnelUnlock,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Silithus_Stone_Exterior.Center)));
      cthun.AddQuest(new QuestAwakenCthun());
      cthun.AddQuest(new QuestEndlessRanks());
      cthun.AddQuest(new QuestGatesofAhnqiraj(
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.WorldTunnelExit.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.WorldTunnelEntrance.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H02U_GATES_OF_AHN_QIRAJ_CLOSED)));
      cthun.AddQuest(new QuestDragonSoul());
      cthun.AddQuest(new QuestWyrmrestTemple());
    }
  }
}