using MacroTools;
using WarcraftLegacies.Source.Quests.Stormwind;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class StormwindQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      var stormwind = StormwindSetup.Stormwind;
      var newQuest =
        stormwind.AddQuest(new QuestDarkshire(preplacedUnitSystem.GetUnit(FourCC("ngnv"), Regions.DarkshireUnlock.Center)));
      stormwind.StartingQuest = newQuest;
      stormwind.AddQuest(new QuestLakeshire(Regions.LakeshireUnlock,
        preplacedUnitSystem.GetUnit(FourCC("nogl"), new Point(14288, -14063))));
      stormwind.AddQuest(new QuestGoldshire(Regions.ElwinForestAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N021_HOGGER)));
      stormwind.AddQuest(new QuestStormwindCity(Regions.StormwindUnlock));
      stormwind.AddQuest(new QuestNethergarde(preplacedUnitSystem, allLegendSetup.Stormwind.Varian));
      stormwind.AddQuest(new QuestStromgarde(Regions.Stromgarde));
      stormwind.AddQuest(new QuestHonorHold(Regions.HonorHold, allLegendSetup.FelHorde.HellfireCitadel));
      stormwind.AddQuest(new QuestKhadgar(allLegendSetup.FelHorde.BlackTemple));
      stormwind.AddQuest(new QuestClosePortal(preplacedUnitSystem, allLegendSetup.Stormwind.Khadgar));
      stormwind.AddQuest(new QuestConstructionSites(new[]
      {
        preplacedUnitSystem.GetUnit(Constants.UNIT_H053_CONSTRUCTION_SITE_STORMWIND_WIZARD_S_SANCTUM),
        preplacedUnitSystem.GetUnit(Constants.UNIT_H055_CONSTRUCTION_SITE_STORMWIND_CHAMPION_S_HALL)
      }));
      stormwind.AddQuest(new QuestKingdomOfManStormwind(artifactSetup.CrownOfLordaeron, artifactSetup.CrownOfStormwind,
        allLegendSetup.Stormwind.Varian));
    }
  }
}