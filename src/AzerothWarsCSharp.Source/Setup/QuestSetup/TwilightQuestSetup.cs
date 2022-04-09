using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Twilight;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class TwilightQuestSetup{

    public static void Setup( )
    {
      var twilight = TwilightSetup.FACTION_TWILIGHT;
      twilight.StartingQuest = twilight.AddQuest(new QuestDragonmawPort());
      twilight.AddQuest(new QuestGrimBatol(
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_GRIM_BATOL_TUNNELS),
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_GRIM_BATOL_TUNNELS),
        PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_GRIM_BATOL_CREEP)));
      twilight.AddQuest(new QuestSpreadTheWord());
      twilight.AddQuest(new QuestThunderfury());
      twilight.AddQuest(new QuestFeludius());
      twilight.AddQuest(new QuestIgnacious());
      twilight.AddQuest(new QuestCataclysm());
    }

  }
}
