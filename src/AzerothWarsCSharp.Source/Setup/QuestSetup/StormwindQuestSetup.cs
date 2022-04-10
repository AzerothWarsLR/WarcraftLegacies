using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Stormwind;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class StormwindQuestSetup
  {
    public static void Setup()
    {
      var stormwind = StormwindSetup.Stormwind;

      //Setup
      QuestData newQuest =
        stormwind.AddQuest(new QuestDarkshire(PreplacedUnitSystem.GetUnitByUnitType(FourCC("ngnv"))));
      stormwind.StartingQuest = newQuest;
      //Early duel
      stormwind.AddQuest(new QuestLakeshire(PreplacedUnitSystem.GetUnitByUnitType(FourCC("nogl"))));
      stormwind.AddQuest(new QuestGoldshire(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_N021_HOGGER)));
      stormwind.AddQuest(new QuestStormwindCity());
      stormwind.AddQuest(new QuestNethergarde());
      //Misc
      stormwind.AddQuest(new QuestStromgarde());
      stormwind.AddQuest(new QuestHonorHold(
        new List<unit>
        {
          PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H05Z_HONOR_HOLD_ARATHOR),
          PreplacedUnitSystem.GetUnitByUnitType(FourCC("hbla")),
          PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_H03W_DANATH_TROLLBANE_ARATHOR_DEMI),
          PreplacedUnitSystem.GetUnitByUnitType(FourCC("hgtw")),
          PreplacedUnitSystem.GetUnitByUnitType(FourCC("hars"))
        }
        ));
      stormwind.AddQuest(new QuestKhadgar());
      stormwind.AddQuest(new QuestClosePortal());
    }
  }
}