using MacroTools;
using WarcraftLegacies.Source.Quests.Dragonmaw;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

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

      if (dragonmaw != null)
      {
        dragonmaw.StartingQuest = dragonmaw.AddQuest(new QuestOrgrimmarPortal)
          PreplacedUnitSystem.GetDestructable(FourCC("ATg4"), new Point(17851.9f, -1816.1f)),
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07E_PORTAL_GREEN_NAZJATAR, Regions.OrgrimmarPortal.Center),
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07E_PORTAL_GREEN_NAZJATAR, Regions.DragonmawPortal.Center)));
        dragonmaw.AddQuest(new QuestDragonmawPort());
        dragonmaw.AddQuest(new QuestGrimBatol());
      }
    }
  }
}