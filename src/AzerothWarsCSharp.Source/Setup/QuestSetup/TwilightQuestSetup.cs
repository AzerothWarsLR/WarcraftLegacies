using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Twilight;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class TwilightQuestSetup
  {
    public static void Setup()
    {
      var twilight = TwilightSetup.FACTION_TWILIGHT;
      twilight.StartingQuest = twilight.AddQuest(new QuestDragonmawPort(Regions.DragonmawUnlock));
      twilight.AddQuest(new QuestGrimBatol(Regions.Grim_Batol,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16562, -2766)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16756, -2473)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H01Z_GRIM_BATOL_CREEP)));
      twilight.AddQuest(new QuestSpreadTheWord());
      twilight.AddQuest(new QuestThunderfury());
      twilight.AddQuest(new QuestFeludius());
      twilight.AddQuest(new QuestIgnacious());
      twilight.AddQuest(new QuestCataclysm());
    }
  }
}