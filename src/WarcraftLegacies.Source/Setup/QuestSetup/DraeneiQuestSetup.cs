using System.Collections.Generic;
using MacroTools;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Draenei;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class DraeneiQuestSetup
  {
    public static void Setup()
    {
      var draenei = DraeneiSetup.Draenei;

      var questExiled = new QuestExiled
      {
        GoldMine = PreplacedUnitSystem.GetUnit(FourCC("ngol"), Regions.TempestKeep.Center),
        KilledOnFail = new List<unit>
        {
          PreplacedUnitSystem.GetUnit(Constants.UNIT_O02P_CRYSTAL_HALL_DRAENEI)
        },
        TheExodar = PreplacedUnitSystem.GetUnit(Constants.UNIT_H09W_THE_EXODAR)
      };
      draenei.StartingQuest = draenei.AddQuest(questExiled);
      draenei.AddQuest(new QuestWarnBase(Regions.Halaar, "Halaar", "ReplaceableTextures\\CommandButtons\\BTNCallToArms.blp"));
      draenei.AddQuest(new QuestWarnBase(Regions.Shattrah, "Shattrah", "ReplaceableTextures\\CommandButtons\\BTNCallToArms.blp"));
      draenei.AddQuest(new QuestWarnBase(Regions.Farahlon, "Farahlon", "ReplaceableTextures\\CommandButtons\\BTNCallToArms.blp"));
      draenei.AddQuest(new QuestSurvivorsShattrah());
      draenei.AddQuest(new QuestFirstWave());
      draenei.AddQuest(new QuestBrokenOne());
      draenei.AddQuest(new QuestShipArgus(
        questExiled,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.OutlandToArgus.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.TempestKeepSpawn.Center)
        ));
      draenei.AddQuest(new QuestTriumvirate());
    }
  }
}