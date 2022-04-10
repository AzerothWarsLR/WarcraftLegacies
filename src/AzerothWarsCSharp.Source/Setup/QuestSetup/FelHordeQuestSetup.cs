using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Fel_Horde;
using static AzerothWarsCSharp.Source.Setup.FactionSetup.FelHordeSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      QuestData newQuest = FactionFelHorde.AddQuest(new QuestKillDraenei());
      FactionFelHorde.StartingQuest = newQuest;
      FactionFelHorde.AddQuest(new QuestKilsorrow(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_O017_KIL_SORROW_FORTRESS)));
      FactionFelHorde.AddQuest(new QuestHellfire(new List<unit>
      {
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0),
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0)
      }));
      FactionFelHorde.AddQuest(new QuestBlackrock());
      FactionFelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FactionFelHorde.AddQuest(new QuestFelHordeKillStormwind());
      FactionFelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}