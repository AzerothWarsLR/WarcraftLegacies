using MacroTools;
using WarcraftLegacies.Source.Quests.Dragonmaw;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  /// <summary>
  /// Responsible for setting up all Dragonmaw quests.
  /// </summary>
  public static class DragonmawQuestSetup
  {
    /// <summary>
    /// Sets up all Dragonmaw quests.
    /// </summary>
    public static void Setup()
    {
      var dragonmaw = DragonmawSetup.Dragonmaw;

      if (dragonmaw == null)
        return;
      dragonmaw.StartingQuest = dragonmaw.AddQuest(new QuestOrgrimmarPortal(PreplacedUnitSystem.GetUnit(Constants.UNIT_N07E_PORTAL_GREEN_NAZJATAR, Regions.DragonmawPortal.Center)));
      dragonmaw.AddQuest(new QuestDragonmawPort(Regions.DragonmawUnlock));
      dragonmaw.AddQuest(new QuestGrimBatol(Regions.Grim_Batol,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_H01Z_GRIM_BATOL_CREEP),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16562, -2766)),
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N08R_GRIM_BATOL_TUNNELS, new Point(16756, -2473))
      ));
      dragonmaw.AddQuest(new QuestStonemaul(Regions.StonemaulKeep));
    }
  }
}