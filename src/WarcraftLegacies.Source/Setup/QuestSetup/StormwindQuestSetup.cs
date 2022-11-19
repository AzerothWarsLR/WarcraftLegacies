using MacroTools;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Stormwind;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class StormwindQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      var stormwind = StormwindSetup.Stormwind;
      QuestData newQuest =
        stormwind.AddQuest(new QuestDarkshire(preplacedUnitSystem.GetUnit(FourCC("ngnv"), Regions.DarkshireUnlock.Center)));
      stormwind.StartingQuest = newQuest;
      stormwind.AddQuest(new QuestLakeshire(Regions.LakeshireUnlock,
        preplacedUnitSystem.GetUnit(FourCC("nogl"), Regions.LakeshireUnlock.Center)));
      stormwind.AddQuest(new QuestGoldshire(Regions.ElwinForestAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N021_HOGGER)));
      stormwind.AddQuest(new QuestStormwindCity(Regions.StormwindUnlock));
      stormwind.AddQuest(new QuestNethergarde());
      stormwind.AddQuest(new QuestStromgarde(Regions.Stromgarde));
      stormwind.AddQuest(new QuestHonorHold(Regions.HonorHold));
      stormwind.AddQuest(new QuestKhadgar());
      stormwind.AddQuest(new QuestClosePortal(preplacedUnitSystem));
      stormwind.AddQuest(new QuestConstructionSites(new[]
      {
        preplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
      }));
    }
  }
}