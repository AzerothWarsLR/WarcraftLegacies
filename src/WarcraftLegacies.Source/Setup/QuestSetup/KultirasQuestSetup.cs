using MacroTools;
using WarcraftLegacies.Source.Quests.KulTiras;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class KultirasQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var kultiras = KultirasSetup.Kultiras;

      kultiras.StartingQuest = kultiras.AddQuest(new QuestBoralus(Regions.Kultiras, preplacedUnitSystem));
      kultiras.AddQuest(new QuestUnlockShip(Regions.ShipAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS), allLegendSetup.Kultiras.LegendBoralus, allLegendSetup.Kultiras.LegendAdmiral));
      kultiras.AddQuest(new QuestWestfallOutpost(Regions.SentinelTowerAmbient));
      kultiras.AddQuest(new QuestEliminatePiracy(Regions.HighbankUnlock));
      kultiras.AddQuest(new QuestTheramore(Regions.Theramore));
      kultiras.AddQuest(new QuestBeyondPortal(allLegendSetup.FelHorde.HellfireCitadel, allLegendSetup.FelHorde.KilsorrowFortress));
    }
  }
}