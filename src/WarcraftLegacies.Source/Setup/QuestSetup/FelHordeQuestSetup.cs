using System.Collections.Generic;
using MacroTools;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup()
    {
      var questKilsorrow = FelHorde.AddQuest(new QuestKilsorrow(Regions.KilsorrowUnlock,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_O017_KIL_SORROW_FORTRESS),
        PreplacedUnitSystem.GetUnit(FourCC("ngol"), Regions.KilsorrowUnlock.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, new Point(-506.6f, -24855.8f))));
      
      var shattrahMassacre = FelHorde.AddQuest(new QuestKillDraenei());
      FelHorde.StartingQuest = shattrahMassacre;
      
      var questHellfireCitadel = FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock, new List<unit>
      {
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, Regions.DemonGate3.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N081_UNFOCUSED_DEMON_GATE_T0, Regions.Demongate_1.Center)
      }, new[] { shattrahMassacre }));

      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, new[] { questKilsorrow, questHellfireCitadel }));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FelHorde.AddQuest(new QuestFelHordeKillStormwind());
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}