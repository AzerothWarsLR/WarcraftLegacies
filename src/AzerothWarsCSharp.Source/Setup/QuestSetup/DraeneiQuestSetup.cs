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
        GoldMine = PreplacedUnitSystem.GetUnitByUnitType(FourCC("ngol")),
        KilledOnFail = new List<unit>
        {
          PreplacedUnitSystem.GetUnitByUnitType(FourCC("o02P")),
          PreplacedUnitSystem.GetUnitByUnitType(FourCC("o02P"))
        },
        TheExodar = PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H09W_THE_EXODAR)
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