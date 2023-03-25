using MacroTools;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using static War3Api.Common;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DraeneiQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var draenei = DraeneiSetup.Draenei;
      if (draenei == null) 
        return;
      var questRepairHull = new QuestRepairExodarHull(Regions.ExodarBaseUnlock, allLegendSetup.Draenei.LegendExodar);
      draenei.StartingQuest = questRepairHull;
      draenei.AddQuest(questRepairHull);
      draenei.AddQuest(new QuestRebuildCivilisation(Regions.AzuremystAmbient));
      draenei.AddQuest(new QuestShipArgus(
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center),
        allLegendSetup.Draenei.Velen
      ));
      var questRepairGenerator = new QuestRepairGenerator(allLegendSetup.Draenei.LegendExodarGenerator, new List<unit>
      {
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10895, -25846)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -26098)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10230, -26110)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25856)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-9973, -25460)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10235, -25187)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10625, -25218)),
        preplacedUnitSystem.GetUnit(Constants.UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, new Point(-10896, -25456))
      });
      draenei.AddQuest(questRepairGenerator);
      draenei.AddQuest(new QuestTriumvirate(allLegendSetup.Draenei.Velen));
      var questDimensionalShip = new QuestDimensionalShip(Regions.ExodarBaseUnlock,
        new List<QuestData> { questRepairHull, questRepairGenerator }, allLegendSetup.Draenei.LegendExodarGenerator);
      draenei.AddQuest(questDimensionalShip);
    }
  }
}