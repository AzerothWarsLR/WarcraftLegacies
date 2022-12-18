using System.Collections.Generic;
using MacroTools;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DraeneiQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var draenei = DraeneiSetup.Draenei;

      draenei.AddQuest(new QuestSurvivorsShattrah());
      draenei.AddQuest(new QuestBrokenOne());
      draenei.AddQuest(new QuestShipArgus(
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center)
        ));
      draenei.AddQuest(new QuestTriumvirate());
    }
  }
}