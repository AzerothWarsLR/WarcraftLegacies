using MacroTools;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DraeneiQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var draenei = DraeneiSetup.Draenei;
      if (draenei != null)
      {
        var questDimensionalShip = new QuestDimensionalShip(Regions.Exodar_Interior_All, preplacedUnitSystem);
        var questRepairHull = new QuestRepairExodarHull(Regions.Exodar_Interior_All, questDimensionalShip);
        draenei.StartingQuest = questRepairHull;
        draenei.AddQuest(questRepairHull);
        draenei.AddQuest(new QuestRebuildCivilisation(Regions.AzuremystAmbient));
        draenei.AddQuest(new QuestBrokenOne());
        draenei.AddQuest(new QuestShipArgus(
          preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
          preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center)
          ));
        draenei.AddQuest(new QuestTriumvirate());
        draenei.AddQuest(questDimensionalShip);
      }
    }
  }
}