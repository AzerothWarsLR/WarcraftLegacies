using MacroTools;
using WarcraftLegacies.Source.Setup.QuestSetup;

namespace WarcraftLegacies.Source.Setup
{
  public static class AllQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup, AllLegendSetup allLegendSetup)
    {
      QuelthalasQuestSetup.Setup(preplacedUnitSystem);
      DalaranQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      DruidsQuestSetup.Setup(artifactSetup, allLegendSetup.Druids);
      FelHordeQuestSetup.Setup();
      FrostwolfQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      IronforgeQuestSetup.Setup(preplacedUnitSystem);
      LegionQuestSetup.Setup(preplacedUnitSystem);
      LordaeronQuestSetup.Setup(preplacedUnitSystem, artifactSetup, allLegendSetup.Lordaeron);
      ScourgeQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      SentinelsQuestSetup.Setup(artifactSetup);
      StormwindQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      WarsongQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      NagaQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
      GilneasQuestSetup.Setup(artifactSetup);
      KultirasQuestSetup.Setup(preplacedUnitSystem);
      ScarletQuestSetup.Setup();
      TrollQuestSetup.Setup(artifactSetup);
      ForsakenQuestSetup.Setup();
      GoblinQuestSetup.Setup();
      DraeneiQuestSetup.Setup(preplacedUnitSystem);
      DragonmawQuestSetup.Setup(preplacedUnitSystem);
      SharedQuestSetup.Setup(preplacedUnitSystem, artifactSetup);
    }
  }
}