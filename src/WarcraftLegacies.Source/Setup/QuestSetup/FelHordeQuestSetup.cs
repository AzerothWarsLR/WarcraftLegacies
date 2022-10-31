using System.Collections.Generic;
using WarcraftLegacies.MacroTools;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      QuestData newQuest = FelHorde.AddQuest(new QuestKillDraenei());
      FelHorde.StartingQuest = newQuest;
      FelHorde.AddQuest(new QuestKilsorrow(Regions.KilsorrowUnlock,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_O017_KIL_SORROW_FORTRESS)));
      FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock, new List<unit>
      {
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, Regions.DemonGate3.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, Regions.Demongate_1.Center)
      }));
      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FelHorde.AddQuest(new QuestFelHordeKillStormwind());
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}