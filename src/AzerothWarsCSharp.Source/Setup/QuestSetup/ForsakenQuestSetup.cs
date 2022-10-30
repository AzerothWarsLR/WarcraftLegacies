using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Forsaken;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class ForsakenQuestSetup
  {
    public static void Setup(QuestData questPlague)
    {
      var forsaken = ForsakenSetup.Forsaken;

      forsaken.StartingQuest = forsaken.AddQuest(new QuestScholomanceBuild());
      forsaken.AddQuest(new QuestReanimateSylvanas());
      forsaken.AddQuest(new QuestUndercity(Regions.UndercityUnlock,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Undercity_Interior_1.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Undercity_Interior_2.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08F_UNDERCITY_ENTRANCE, Regions.Undercity_Exterior_1.Center),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08F_UNDERCITY_ENTRANCE, Regions.Undercity_Exterior_2.Center)
        )
      );
      forsaken.AddQuest(new QuestThePlaguelands());
      forsaken.AddQuest(new QuestOpenScholomance(questPlague));
    }
  }
}