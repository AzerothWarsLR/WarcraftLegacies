using MacroTools;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var questHellfireCitadel = FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
      FelHorde.AddQuest(new QuestRuinsofShadowmoon(Regions.ShadowmoonBaseUnlock));
      FelHorde.AddQuest(new QuestDarkPortal(
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_1.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_2.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Entrance_3.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_1.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_2.Center),
        preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL_WAYGATE, Regions.Dark_Portal_Exit_3.Center)));
      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, Regions.DarkPortalUnlock, new[] { questHellfireCitadel }));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge(allLegendSetup.Ironforge.GreatForge));
      FelHorde.AddQuest(new QuestFelHordeKillStormwind(allLegendSetup.Stormwind.StormwindKeep));
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}