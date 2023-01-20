using MacroTools;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DraeneiQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var draenei = DraeneiSetup.Draenei;
      if (draenei == null) 
        return;
      var questRepairHull = new QuestRepairExodarHull(Regions.Exodar_Interior_All, allLegendSetup.Draenei.LegendExodar,
        allLegendSetup.Draenei.LegendExodarGenerator);
      draenei.StartingQuest = questRepairHull;
      draenei.AddQuest(questRepairHull);
      draenei.AddQuest(new QuestRebuildCivilisation(Regions.AzuremystAmbient));
      draenei.AddQuest(new QuestBrokenOne(allLegendSetup.Draenei.LegendVelen));
      draenei.AddQuest(new QuestShipArgus(
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center),
        allLegendSetup.Draenei.LegendVelen
      ));
      var questRepairGenerator = new QuestRepairGenerator(allLegendSetup.Draenei.LegendExodarGenerator);
      draenei.AddQuest(questRepairGenerator);
      draenei.AddQuest(new QuestTriumvirate(allLegendSetup.Draenei.LegendVelen));
      var questDimensionalShip = new QuestDimensionalShip(Regions.Exodar_Interior_All,
        new List<QuestData> { questRepairHull, questRepairGenerator }, allLegendSetup.Draenei.LegendExodarGenerator);
      draenei.AddQuest(questDimensionalShip);
    }
  }
}