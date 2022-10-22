using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Draenei;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class DraeneiQuestSetup
  {
    public static QuestData SHIP_ARGUS { get; private set; }

    public static void Setup()
    {
      var draenei = DraeneiSetup.Draenei;

      var questExiled = new QuestExiled
      {
        GoldMine = PreplacedUnitSystem.GetUnit(FourCC("ngol"), Regions.Draenei_Invulnerable.Center),
        KilledOnFail = new List<unit>
        {
          PreplacedUnitSystem.GetUnit(FourCC("o02P")),
          PreplacedUnitSystem.GetUnit(FourCC("o02P"))
        },
        TheExodar = PreplacedUnitSystem.GetUnit(Constants.UNIT_H09W_THE_EXODAR)
      };
      draenei.AddQuest(questExiled);
      draenei.StartingQuest = questExiled;
      draenei.AddQuest(new QuestFirstWave());
      draenei.AddQuest(new QuestSurvivorsShattrah());
      draenei.AddQuest(new QuestBrokenOne());
      draenei.AddQuest(new QuestTriumvirate());

      SHIP_ARGUS = new QuestShipArgus();
    }
  }
}