using MacroTools;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Forsaken;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ForsakenQuestSetup
  {
    public static void Setup(QuestData questPlague, PreplacedUnitSystem preplacedUnitSystem)
    {
      var forsaken = ForsakenSetup.Forsaken;

      forsaken.StartingQuest = forsaken.AddQuest(new QuestScholomanceBuild());
      forsaken.AddQuest(new QuestReanimateSylvanas());
      forsaken.AddQuest(new QuestUndercity(Regions.UndercityUnlock,
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Undercity_Interior_1.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, Regions.Undercity_Interior_2.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N08F_UNDERCITY_ENTRANCE, Regions.Undercity_Exterior_1.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N08F_UNDERCITY_ENTRANCE, Regions.Undercity_Exterior_2.Center)
        )
      );
      forsaken.AddQuest(new QuestThePlaguelands());
      forsaken.AddQuest(new QuestOpenScholomance(preplacedUnitSystem, questPlague));
    }
  }
}