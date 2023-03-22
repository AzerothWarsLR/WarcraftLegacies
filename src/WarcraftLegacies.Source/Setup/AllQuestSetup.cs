using MacroTools;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      QuelthalasQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      DalaranQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      DruidsQuestSetup.Setup(artifactSetup, allLegendSetup);
      FelHordeQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      FrostwolfQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      IronforgeQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      LegionQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      LordaeronQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      ScourgeQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      SentinelsQuestSetup.Setup(artifactSetup, allLegendSetup);
      StormwindQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      WarsongQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      NagaQuestSetup.Setup(artifactSetup, allLegendSetup);
      KultirasQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      GoblinQuestSetup.Setup(allLegendSetup);
      DraeneiQuestSetup.Setup(preplacedUnitSystem, allLegendSetup);
      SharedQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup);
      
    }
  }
}