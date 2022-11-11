using MacroTools;
using MacroTools.Mechanics.TwilightHammer;
using WarcraftLegacies.Source.Quests.Twilight;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class TwilightQuestSetup
  {
    public static void Setup()
    {
      var twilight = TwilightSetup.TwilightsHammer;
      twilight.StartingQuest = twilight.AddQuest(new QuestDragonmawPort(Regions.DragonmawUnlock));
      twilight.AddQuest(new QuestGrimBatol(Regions.Grim_Batol,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16562, -2766)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16756, -2473)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H01Z_GRIM_BATOL_CREEP)));
      twilight.AddQuest(new QuestSpreadTheWord());
      twilight.AddQuest(new QuestThunderfury());
      twilight.AddQuest(new QuestFeludius());
      twilight.AddQuest(new QuestIgnacious());
      twilight.AddQuest(new QuestCataclysm(twilight.GetPowerByType<PowerCorruptWorker>()));
    }
  }
}