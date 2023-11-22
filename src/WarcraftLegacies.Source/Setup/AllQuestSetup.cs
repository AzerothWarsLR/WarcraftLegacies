using MacroTools;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      DruidsQuestSetup.Setup(artifactSetup, allLegendSetup);
      FelHordeQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      IronforgeQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      LordaeronQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      SentinelsQuestSetup.Setup(artifactSetup, allLegendSetup);
      StormwindQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      WarsongQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      NagaQuestSetup.Setup(artifactSetup, allLegendSetup);
      GoblinQuestSetup.Setup(allLegendSetup);
      DraeneiQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      ZandalarQuestSetup.Setup(artifactSetup, preplacedUnitSystem, allLegendSetup);
      SunfuryQuestSetup.Setup(artifactSetup, preplacedUnitSystem, allLegendSetup);
      SharedQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
    }
  }
}